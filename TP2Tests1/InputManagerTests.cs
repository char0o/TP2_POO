using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Tests
{
    [TestClass()]
    public class InputManagerTests
    {
        private enum TestEnum
        {
            OPTION1,
            OPTION2,
            OPTION3
        }
        private enum TestEnum2
        {
            OPTION1 = 1,
            OPTION2,
            OPTION3
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PrintFormattedColoredTextDifferentSizesOfArraysTest()
        {
            string[] strings = new string[] { "Hello", "World" };
            ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red };
            InputManager.PrintFormattedColoredText("", strings, colors);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PrintFormattedColoredTextDifferentFormatTest()
        {
            string format = "{0,-10}{1,-5}{2,-10}";
            string[] strings = new string[] { "Hello", "World" };
            ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red };
            InputManager.PrintFormattedColoredText(format, strings, colors);
        }
        [TestMethod()]
        public void PrintFormattedColoredTextEvenArgsTest()
        {
            string format = "{0,-10}{1,-5}";
            string EXPECTED = "Hello     World";
            string[] strings = new string[] { "Hello", "World" };
            ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.White };
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                InputManager.PrintFormattedColoredText(format, strings, colors);
                string result = sw.ToString();
                Assert.AreEqual(EXPECTED, result);
            }
        }

        [TestMethod()]
        public void PrintFormattedColoredTextOddArgsTest()
        {
            string format = "{0,-10}{1,-7}{2, -8}";
            string EXPECTED = "Hello     World  Hamster ";
            string[] strings = new string[] { "Hello", "World", "Hamster" };
            ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.White, ConsoleColor.White };
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                InputManager.PrintFormattedColoredText(format, strings, colors);
                string result = sw.ToString();
                Assert.AreEqual(EXPECTED, result);
            }
        }

        [TestMethod()]
        public void CreateMenuFromEnumTest()
        {
            string EXPECTED = "0. OPTION1\n1. OPTION2\n2. OPTION3";

            string menu = InputManager.CreateMenuFromEnum<TestEnum>(new string[] { "OPTION1", "OPTION2", "OPTION3" });
            Assert.AreEqual(EXPECTED, menu);
        }
        [TestMethod()]
        public void CreateMenuFromEnumStartingFrom1Test()
        {
            string EXPECTED = "1. OPTION1\n2. OPTION2\n3. OPTION3";

            string menu = InputManager.CreateMenuFromEnum<TestEnum2>(new string[] { "OPTION1", "OPTION2", "OPTION3" });
            Assert.AreEqual(EXPECTED, menu);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateMenuFromEnumSimilarArgsTest()
        {
            string EXPECTED = "1. OPTION1\n2. OPTION2\n3. OPTION3";

            string menu = InputManager.CreateMenuFromEnum<TestEnum2>(new string[] { "OPTION1", "OPTION2" });
        }

    }
}