using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColorConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace ColorConverter.Tests
{
    [TestClass()]
    public class ModelTests
    {
        private Model model;
        [TestInitialize()]
        public void InitModel()
        {
            model = new Model();
        }
        [TestMethod()]
        public void ModelTestWebsafeGetBeforeSetReturnsEmpty()
        {
            Color emptyColor = new Color();
            Color blackColor = Color.FromArgb(0, 0, 0);

            Assert.IsTrue(model.WebsafeColor.IsEmpty);
            Assert.AreEqual(emptyColor, model.WebsafeColor);

            model.WebsafeColor = blackColor;

            Color tempColor = model.WebsafeColor;
            Assert.AreEqual(blackColor, tempColor);
        }
        [TestMethod()]
        public void ModelTestInputGetBeforeSetReturnsEmpty()
        {
            Color emptyColor = new Color();
            Color blackColor = Color.FromArgb(0, 0, 0);

            Assert.IsTrue(model.InputColor.IsEmpty);
            Assert.AreEqual(emptyColor, model.InputColor);

            model.InputColor = blackColor;

            Color tempColor = model.InputColor;
            Assert.AreEqual(blackColor, tempColor);
        }
        [TestMethod()]
        public void ModelTestComplementGetBeforeSetReturnsEmpty()
        {
            Color emptyColor = new Color();
            Color blackColor = Color.FromArgb(0, 0, 0);

            Assert.IsTrue(model.ComplementColor.IsEmpty);
            Assert.AreEqual(emptyColor, model.ComplementColor);

            model.ComplementColor = blackColor;

            Color tempColor = model.ComplementColor;
            Assert.AreEqual(blackColor, tempColor);
        }
        [TestMethod()]
        public void ModelTestHarmonyGetAndSetWorks()
        {
            Color emptyColor = new Color();
            Color blackColor = Color.FromArgb(0, 0, 0);

            Assert.IsTrue(model.HarmonyColors[0].IsEmpty);
            Assert.IsTrue(model.HarmonyColors[1].IsEmpty);
            Assert.IsTrue(model.HarmonyColors[2].IsEmpty);
            Assert.IsTrue(model.HarmonyColors[3].IsEmpty);

            // I''ll assume all of them are like this then, as they should and otherwise it will create a large amount of unneeded asserts
            Assert.AreEqual(emptyColor, model.HarmonyColors[0]);

            model.HarmonyColors[0] = blackColor;

            Color tempColor = model.HarmonyColors[0];
            Assert.AreEqual(blackColor, tempColor);
        }

    }
}