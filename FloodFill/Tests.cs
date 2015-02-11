using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodFill
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void Flood_Given3x3Image_FillCorretly()
        {
            string image = "+++" +
                            "+-+" +
                            "+++";
            string expectedImage = "+++" +
                                    "+@+" +
                                    "+++";
            FloodFill floodFill = new FloodFill(3, 3, image);
            string result = floodFill.Fill(1, 1, '@');
            Assert.That(result, Is.EqualTo(expectedImage));
        }

        [Test]
        public void Flood_Given4x4Image_FillCorretly()
        {
            string image = "++++" +
                            "+--+" +
                            "++++";
            string expectedImage = "++++" +
                                    "+@@+" +
                                    "++++";
            FloodFill floodFill = new FloodFill(4, 3, image);
            string result = floodFill.Fill(1, 1, '@');
            Assert.That(result, Is.EqualTo(expectedImage));
        }

        [Test]
        public void Flood_GivenBigImage_FillCorrectly()
        {
            string image = 
            "----------------" +
            "-++++++++++++++-" +
            "-+------------+-" +
            "-++++++++++++-+-" +
            "-+------------+-" +
            "-+-++++++++++++-" +
            "-+------------+-" +
            "-++++++++++++-+-" +
            "-+------------+-" +
            "-+-++++++++++++-" +
            "-+------------+-" +
            "-++++++++++++++-" +
            "-+------------+-" +
            "-++++++++++++++-" +
            "----------------";
            FloodFill floodFill = new FloodFill(16, 15, image);
            string result = floodFill.Fill(2, 2, '@');

            string expectedImage =
                "----------------" +
                "-++++++++++++++-" +
                "-+@@@@@@@@@@@@+-" +
                "-++++++++++++@+-" +
                "-+@@@@@@@@@@@@+-" +
                "-+@++++++++++++-" +
                "-+@@@@@@@@@@@@+-" +
                "-++++++++++++@+-" +
                "-+@@@@@@@@@@@@+-" +
                "-+@++++++++++++-" +
                "-+@@@@@@@@@@@@+-" +
                "-++++++++++++++-" +
                "-+------------+-" +
                "-++++++++++++++-" +
                "----------------";

            Assert.That(result, Is.EqualTo(expectedImage));
        }

        [Test]
        public void Flood_GivenBigImageWithDifferentSigns_FillCorrectly()
        {
            string image =
            "aaaaaaaaa" +
            "aaadefaaa" +
            "abcdafgha" +
            "abcdafgha" +
            "abcdafgha" +
            "abcdafgha" +
            "aacdafgaa" +
            "aaadafaaa" +
            "aaaaaaaaa";


            FloodFill floodFill = new FloodFill(9, 9, image);
            string result = floodFill.Fill(8, 3, ',');

            string expectedImage =
                ",,,,,,,,," +
                ",,,def,,," +
                ",bcd,fgh," +
                ",bcd,fgh," +
                ",bcd,fgh," +
                ",bcd,fgh," +
                ",,cd,fg,," +
                ",,,d,f,,," +
                ",,,,,,,,,";

            Assert.That(result, Is.EqualTo(expectedImage));
        }

        

        

    }
}
