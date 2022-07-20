using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace TestEditor
{

    public class TestHeart
    {
        private Image image;
        private Heart heart;

        [SetUp]
        public void BeforeEveryTest()
        {
            image = new GameObject().AddComponent<Image>();
            heart = new Heart(image);
        }

        public class TheCurrentNumberOfHeartPiecesProperty : TestHeart
        {
            [Test]
            public void _1_image_fill_is_0_heart_pieces()
            {
                image.fillAmount = 0f;

                Assert.AreEqual(0, heart.CurrentNumberOfHeartPieces);
            }

            [Test]
            public void _2_image_fill_25_percent_is_1_heart_pieces()
            {
                image.fillAmount = .25f;

                Assert.AreEqual(1, heart.CurrentNumberOfHeartPieces);
            }

            [Test]
            public void _3_image_fill_50_percent_is_2_heart_pieces()
            {
                image.fillAmount = .5f;

                Assert.AreEqual(2, heart.CurrentNumberOfHeartPieces);
            }

            [Test]
            public void _4_image_fill_75_percent_is_3_heart_pieces()
            {
                image.fillAmount = .75f;

                Assert.AreEqual(3, heart.CurrentNumberOfHeartPieces);
            }

            [Test]
            public void _5_image_fill_100_percent_is_4_heart_pieces()
            {
                image.fillAmount = 1f;

                Assert.AreEqual(4, heart.CurrentNumberOfHeartPieces);
            }
        }

        public class TheReplenishMethods : TestHeart
        {
            [Test]
            public void _1_set_image_with_0_fill_to_0_percent_fill()
            {
                image.fillAmount = 0f;
                heart.Replenish(0);

                Assert.AreEqual(0f, image.fillAmount);
            }

            [Test]
            public void _2_set_image_with_0_fill_to_25_percent_fill()
            {
                image.fillAmount = 0f;
                heart.Replenish(1);

                Assert.AreEqual(0.25f, image.fillAmount);
            }

            [Test]
            public void _3_set_image_with_25_fill_to_50_percent_fill()
            {
                image.fillAmount = 0.25f;
                heart.Replenish(1);

                Assert.AreEqual(0.5f, image.fillAmount);
            }

            [Test]
            public void _4_set_image_with_50_fill_to_75_percent_fill()
            {
                image.fillAmount = 0.5f;
                heart.Replenish(1);

                Assert.AreEqual(0.75f, image.fillAmount);
            }

            [Test]
            public void _5_set_image_with_75_fill_to_100_percent_fill()
            {
                image.fillAmount = 0.75f;
                heart.Replenish(1);

                Assert.AreEqual(1f, image.fillAmount);
            }

            [Test]
            public void _6_throw_exception_for_negative_number_of_heart_pieces()
            {
                Assert.Throws<ArgumentException>(() => heart.Replenish(-1));
            }
        }

        public class TheDepleteMethods : TestHeart
        {
            [Test]
            public void _1_set_image_with_100_fill_to_100_percent_fill()
            {
                image.fillAmount = 1f;
                heart.Deplete(0);

                Assert.AreEqual(1f, image.fillAmount);
            }

            [Test]
            public void _2_set_image_with_100_fill_to_75_percent_fill()
            {
                image.fillAmount = 1f;
                heart.Deplete(1);

                Assert.AreEqual(.75f, image.fillAmount);
            }

            [Test]
            public void _3_set_image_with_75_fill_to_50_percent_fill()
            {
                image.fillAmount = .75f;
                heart.Deplete(1);

                Assert.AreEqual(.5f, image.fillAmount);
            }

            [Test]
            public void _4_set_image_with_50_fill_to_25_percent_fill()
            {
                image.fillAmount = .5f;
                heart.Deplete(1);

                Assert.AreEqual(.25f, image.fillAmount);
            }

            [Test]
            public void _5_set_image_with_25_fill_to_0_percent_fill()
            {
                image.fillAmount = .25f;
                heart.Deplete(1);

                Assert.AreEqual(0f, image.fillAmount);
            }

            [Test]
            public void _6_throw_exception_for_negative_number_of_heart_pieces()
            {
                Assert.Throws<ArgumentException>(() => heart.Deplete(-1));
            }
        }


    }

}