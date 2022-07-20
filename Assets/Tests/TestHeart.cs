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