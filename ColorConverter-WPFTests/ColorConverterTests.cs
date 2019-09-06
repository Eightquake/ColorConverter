using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColorConverter_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorConverter_WPF.Tests
{
    [TestClass()]
    public class ColorConverterTests
    {
        [TestMethod()]
        public void ConvertFromHexStringTestHandleSemiTransparentColor()
        {
            /* Will test if ConvertFromHexString can handle a normal color that is semi-transparent */
            string inputR = "AA", inputG = "BB", inputB = "CC", inputA = "7F";
            Color expected = Color.FromArgb(127, 170, 187, 204);

            Color result = ColorConverter.ConvertFromHexString(inputR, inputG, inputB, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromHexStringTestHandleEmptyAlphaString()
        {
            /* Will test if ConvertFromHexString can handle a normal color without alpha defined */
            string inputR = "AA", inputG = "BB", inputB = "CC", inputA = "";
            Color expected = Color.FromArgb(255, 170, 187, 204);

            Color result = ColorConverter.ConvertFromHexString(inputR, inputG, inputB, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromHexStringTestThrowsExceptionIfNotHex()
        {
            /* Will test if ConvertFromHexString will throw an exception if the input isn't in hex */
            string inputR = "GG", inputG = "HH", inputB = "II", inputA = "";

            Assert.ThrowsException<System.FormatException>(() => ColorConverter.ConvertFromHexString(inputR, inputG, inputB, inputA));
        }

        [TestMethod()]
        public void ConvertFromRGBStringTestHandleSemiTransparentColor()
        {
            /* Will test if ConvertFromRGBString can handle a normal color that is semi-transparent */
            string inputR = "125", inputG = "70", inputB = "246", inputA = "127";
            Color expected = Color.FromArgb(127, 125, 70, 246);

            Color result = ColorConverter.ConvertFromRGBString(inputR, inputG, inputB, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromRGBStringTestHandleEmptyAlphaString()
        {
            /* Will test if ConvertFromRGBString can handle a normal color without alpha defined */
            string inputR = "125", inputG = "70", inputB = "246", inputA = "";
            Color expected = Color.FromArgb(255, 125, 70, 246);

            Color result = ColorConverter.ConvertFromRGBString(inputR, inputG, inputB, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromRGBStringTestHandleAlphaStringWithComma()
        {
            /* Will test if ConvertFromRGBString can handle a normal color with alpha as a decimal with a comma */
            string inputR = "125", inputG = "70", inputB = "246", inputA = "0,5";
            Color expected = Color.FromArgb(127, 125, 70, 246);

            Color result = ColorConverter.ConvertFromRGBString(inputR, inputG, inputB, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromRGBStringTestHandleAlphaStringWithDot()
        {
            /* Will test if ConvertFromRGBString can handle a normal color with alpha as a decimal with a dot */
            string inputR = "125", inputG = "70", inputB = "246", inputA = "0.5";
            Color expected = Color.FromArgb(127, 125, 70, 246);

            Color result = ColorConverter.ConvertFromRGBString(inputR, inputG, inputB, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromRGBStringTestHandlePercentages()
        {
            /* Will test if ConvertFromRGBString can handle a normal color with the channels in percentages */
            string inputR = "51%", inputG = "72%", inputB = "6%", inputA = "255";
            Color expected = Color.FromArgb(255, 131, 184, 15);

            Color result = ColorConverter.ConvertFromRGBString(inputR, inputG, inputB, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromHSLStringTestHandleSemiTransparentColor()
        {
            /* Will test if ConvertFromHSLString can handle a normal color that is semi-transparent */
            string inputH = "224", inputS = "43", inputL = "45", inputA = "127";
            Color expected = Color.FromArgb(127, 65, 91, 164);

            Color result = ColorConverter.ConvertFromHSLString(inputH, inputS, inputL, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromHSLStringTestHandleEmptyAlphaString()
        {
            /* Will test if ConvertFromHSLString can handle a normal color without alpha defined */
            string inputH = "326", inputS = "60", inputL = "37", inputA = "";
            Color expected = Color.FromArgb(255, 150, 37, 101);

            Color result = ColorConverter.ConvertFromHSLString(inputH, inputS, inputL, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromHSLStringTestHandleAlphaStringWithComma()
        {
            /* Will test if ConvertFromHSLString can handle a normal color with alpha as a decimal with a comma */
            string inputH = "316", inputS = "70", inputL = "57", inputA = "0,5";
            Color expected = Color.FromArgb(127, 222, 68, 181);

            Color result = ColorConverter.ConvertFromHSLString(inputH, inputS, inputL, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromHSLStringTestHandleAlphaStringWithDot()
        {
            /* Will test if ConvertFromHSLString can handle a normal color with alpha as a decimal with a dot */
            string inputH = "210", inputS = "25", inputL = "73", inputA = "0.5";
            Color expected = Color.FromArgb(127, 168, 186, 203);

            Color result = ColorConverter.ConvertFromHSLString(inputH, inputS, inputL, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromHSLStringTestDegreesAndPercentageSymbols()
        {
             /* Will test if ConvertFromHSLString can handle a normal color with degree and percentages symbols */
            string inputH = "92°", inputS = "83%", inputL = "53%", inputA = "255";
            Color expected = Color.FromArgb(255, 128, 234, 35);

            Color result = ColorConverter.ConvertFromHSLString(inputH, inputS, inputL, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromHSVStringTestHandleSemiTransparentColor()
        {
            /* Will test if ConvertFromHSVString can handle a normal color that is semi-transparent */
            string inputH = "224", inputS = "60", inputL = "64", inputA = "127";
            Color expected = Color.FromArgb(127, 65, 91, 163);

            Color result = ColorConverter.ConvertFromHSVString(inputH, inputS, inputL, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromHSVStringTestHandleEmptyAlphaString()
        {
            /* Will test if ConvertFromHSVString can handle a normal color without alpha defined */
            string inputH = "326", inputS = "75", inputL = "59", inputA = "";
            Color expected = Color.FromArgb(255, 150, 37, 101);

            Color result = ColorConverter.ConvertFromHSVString(inputH, inputS, inputL, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromHSVStringTestHandleAlphaStringWithComma()
        {
            /* Will test if ConvertFromHSVString can handle a normal color with alpha as a decimal with a comma */
            string inputH = "316", inputS = "69", inputL = "87", inputA = "0,5";
            Color expected = Color.FromArgb(127, 221, 68, 181);

            Color result = ColorConverter.ConvertFromHSVString(inputH, inputS, inputL, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromHSVStringTestHandleAlphaStringWithDot()
        {
            /* Will test if ConvertFromHSVString can handle a normal color with alpha as a decimal with a dot */
            string inputH = "210", inputS = "17", inputL = "80", inputA = "0.5";
            Color expected = Color.FromArgb(127, 169, 186, 204);

            Color result = ColorConverter.ConvertFromHSVString(inputH, inputS, inputL, inputA);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertFromHSVStringTestDegreesAndPercentageSymbols()
        {
            /* Will test if ConvertFromHSVString can handle a normal color with degree and percentages symbols */
            string inputH = "92°", inputS = "85%", inputL = "93%", inputA = "255";
            Color expected = Color.FromArgb(255, 129, 237, 35);

            Color result = ColorConverter.ConvertFromHSVString(inputH, inputS, inputL, inputA);
            Assert.AreEqual(expected, result);
        }
    }
}