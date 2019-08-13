using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColorConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ColorConverter.Tests
{
    [TestClass()]
    public class PresenterTests
    {
        private Model model;
        private Presenter presenter;
        private View view;
        [TestInitialize]
        public void TestInit()
        {
            model = new Model();
            presenter = new Presenter(model);
            view = new View(presenter);

            presenter.SetView(view);
        }
        [TestMethod()]
        public void RegexHex()
        {
            string[] inputs = { "#FF00FF", "HEX(FF00FF)", "HEX 0F0F0F" };
            string[][] groups = { new string[] { "#FF00FF", "#", "FF", "00", "FF" }, new string[] { "HEX(FF00FF)", "HEX", "FF", "00", "FF" }, new string[] { "HEX 0F0F0F", "HEX", "0F", "0F", "0F" } };

            for (int i = 0; i < inputs.Length; i++)
            {
                MatchCollection matches = model.Regex.Matches(inputs[i]);
                Match match = matches[0];

                Assert.AreEqual(match.Groups[1].Value, groups[i][0]);
                Assert.AreEqual(match.Groups[2].Value, groups[i][1]);
                Assert.AreEqual(match.Groups[3].Value, groups[i][2]);
                Assert.AreEqual(match.Groups[4].Value, groups[i][3]);
                Assert.AreEqual(match.Groups[5].Value, groups[i][4]);
            }
        }

        [TestMethod()]
        public void RegexRGBandHSL()
        {
            string[] inputs = { "RGB(225,29,30)", "RGB(100%,90%,80%)", "HSL(10, 20%, 30%)", "HSL(10°, 20%, 30%)" };
            string[][] groups = { new string[] { "RGB(225,29,30)", "RGB", "225", "29", "30" }, new string[] { "RGB(100%,90%,80%)", "RGB", "100%", "90%", "80%" }, new string[] { "HSL(10, 20%, 30%)", "HSL", "10", "20%", "30%" }, new string[] { "HSL(10°, 20%, 30%)", "HSL", "10°", "20%", "30%" } };

            for (int i = 0; i < inputs.Length; i++)
            {
                MatchCollection matches = model.Regex.Matches(inputs[i]);
                Match match = matches[0];

                Assert.AreEqual(match.Groups[6].Value, groups[i][0]);
                Assert.AreEqual(match.Groups[7].Value, groups[i][1]);
                Assert.AreEqual(match.Groups[8].Value, groups[i][2]);
                Assert.AreEqual(match.Groups[9].Value, groups[i][3]);
                Assert.AreEqual(match.Groups[10].Value, groups[i][4]);
            }
        }
        [TestMethod()]
        public void TestRegexReturnsCorrectColor()
        {
            string[] inputs = { "Hex(D5B8EE)", "RGB(225,29,30)", "RGB(100%,90%,80%)", "RGBA 255 128 0 128", "RGBA 255 128 0 0.5", "RGBA 255 128 0 0,5", "RGBA 255,128,0,0,5", "HSL(10, 20, 20)", "HSL(20, 20%, 20%)", "HSL(30°, 30%, 30%)" };
            Color[] colors = new Color[] {Color.FromArgb(255, 213, 184, 238), Color.FromArgb(255, 225, 29, 30), Color.FromArgb(255, 255, 229, 204), Color.FromArgb(128, 255, 128, 0), Color.FromArgb(127, 255, 128, 0), Color.FromArgb(127, 255, 128, 0), Color.FromArgb(127, 255, 128, 0), Color.FromArgb(255, 61, 44, 41), Color.FromArgb(255, 61, 48, 41), Color.FromArgb(255, 99, 77, 54) };

            for (int i = 0; i < inputs.Length; i++)
            {
                Color inputColor = presenter.TestRegex(inputs[i]);
                Assert.AreEqual(colors[i], inputColor);
            }
        }
        [TestMethod()]
        public void CreateColorFromHsl_ReturnsCorrectColor()
        {
            Color expected = Color.FromArgb(255, 59, 46, 43);
            Color returned = presenter.CreateColorFromHsl(10.0f, 0.15f, 0.20f);

            Assert.AreEqual(returned.R, expected.R);
            Assert.AreEqual(returned.G, expected.G);
            Assert.AreEqual(returned.B, expected.B);
        }
        [TestMethod()]
        public void CreateColorFromHsl_ThrowsArgumentHOver()
        {
            Assert.ThrowsException<System.ArgumentException>(() => presenter.CreateColorFromHsl(361.0f, 0.15f, 0.20f));
        }
        [TestMethod()]
        public void CreateColorFromHsl_ThrowsArgumentHUnder()
        {
            Assert.ThrowsException<System.ArgumentException>(() => presenter.CreateColorFromHsl(-0.1f, 0.15f, 0.20f));
        }
        [TestMethod()]
        public void CreateColorFromHsl_ThrowsArgumentSOver()
        {
            Assert.ThrowsException<System.ArgumentException>(() => presenter.CreateColorFromHsl(10.0f, 1.1f, 0.20f));
        }
        [TestMethod()]
        public void CreateColorFromHsl_ThrowsArgumentSUnder()
        {
            Assert.ThrowsException<System.ArgumentException>(() => presenter.CreateColorFromHsl(10.0f, -0.1f, 0.20f));
        }
        [TestMethod()]
        public void CreateColorFromHsl_ThrowsArgumentLOver()
        {
            Assert.ThrowsException<System.ArgumentException>(() => presenter.CreateColorFromHsl(10.0f, 0.15f, 1.1f));
        }
        [TestMethod()]
        public void CreateColorFromHsl_ThrowsArgumentLUnder()
        {
            Assert.ThrowsException<System.ArgumentException>(() => presenter.CreateColorFromHsl(10.0f, 0.15f, -0.1f));
        }

        [TestMethod()]
        public void CreateWebsafeFromRgb_ReturnsCorrectColor()
        {
            Color expected = Color.FromArgb(255, 51, 51, 51);
            Color returned = presenter.CreateWebsafeFromRgb(59, 46, 43);

            Assert.AreEqual(returned.R, expected.R);
            Assert.AreEqual(returned.G, expected.G);
            Assert.AreEqual(returned.B, expected.B);
        }
        [TestMethod()]
        public void CreateWebsafeFromRgb_ThrowsArgumentROver()
        {
            Assert.ThrowsException<System.ArgumentException>(() => presenter.CreateWebsafeFromRgb(256, 46, 43));
        }
        [TestMethod()]
        public void CreateWebsafeFromRgb_ThrowsArgumentRUnder()
        {
            Assert.ThrowsException<System.ArgumentException>(() => presenter.CreateWebsafeFromRgb(-1, 46, 43));
        }
        [TestMethod()]
        public void CreateWebsafeFromRgb_ThrowsArgumentGOver()
        {
            Assert.ThrowsException<System.ArgumentException>(() => presenter.CreateWebsafeFromRgb(59, 256, 43));
        }
        [TestMethod()]
        public void CreateWebsafeFromRgb_ThrowsArgumentGUnder()
        {
            Assert.ThrowsException<System.ArgumentException>(() => presenter.CreateWebsafeFromRgb(59, -1, 43));
        }
        [TestMethod()]
        public void CreateWebsafeFromRgb_ThrowsArgumentBOver()
        {
            Assert.ThrowsException<System.ArgumentException>(() => presenter.CreateWebsafeFromRgb(59, 46, 256));
        }
        [TestMethod()]
        public void CreateWebsafeFromRgb_ThrowsArgumentBUnder()
        {
            Assert.ThrowsException<System.ArgumentException>(() => presenter.CreateWebsafeFromRgb(59, 46, -1));
        }
    }
}