using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace TestEditor
{

    public class TestHeartContainer
    {
        private List<Heart> hearts = new List<Heart>();
        private float targetFill;
        private const int NUMBER_OF_HEART = 4;

        private Image targetHead, targetTail;

        private HeartContainer heartContainer;

        [SetUp]
        public virtual void BeforeEveryTest()
        {
            hearts.Clear();

            for (int i = 0; i < NUMBER_OF_HEART; i++)
            {
                var target = new GameObject().AddComponent<Image>();
                target.fillAmount = targetFill;

                if (i == 0) targetHead = target;
                else if (i == NUMBER_OF_HEART - 1) targetTail = target;

                var heart = new Heart(target);
                hearts.Add(heart);
            }

            heartContainer = new HeartContainer(hearts);
        }

        public class TheReplenishMethods : TestHeartContainer
        {
            [SetUp]
            public override void BeforeEveryTest()
            {
                targetFill = 0;
                base.BeforeEveryTest();
            }

            [Test]
            public void _1_empty_hearts_are_replenished()
            {
                heartContainer.Replenish(1);

                Assert.AreEqual(0.25f, targetHead.fillAmount);
            }

            [Test]
            public void _2_hearts_are_replenished_in_order()
            {
                heartContainer.Replenish(1);

                Assert.AreEqual(0.25f, targetHead.fillAmount);
                Assert.AreEqual(0f, targetTail.fillAmount);
            }

            [Test]
            public void _3_hearts_are_replenished_with_5_pieces()
            {
                heartContainer.Replenish(5);

                Assert.AreEqual(4, hearts[0].CurrentNumberOfHeartPieces);
                Assert.AreEqual(1, hearts[1].CurrentNumberOfHeartPieces);
            }

            [Test]
            public void _4_hearts_are_replenished_with_10_pieces()
            {
                heartContainer.Replenish(10);

                Assert.AreEqual(4, hearts[0].CurrentNumberOfHeartPieces);
                Assert.AreEqual(4, hearts[1].CurrentNumberOfHeartPieces);
                Assert.AreEqual(2, hearts[2].CurrentNumberOfHeartPieces);
            }

            [Test]
            public void _6_throw_exception_for_negative_number_of_heart_pieces()
            {
                Assert.Throws<ArgumentException>(() => heartContainer.Replenish(-1));
            }
        }

        public class TheDepleteMethods : TestHeartContainer
        {
            [SetUp]
            public override void BeforeEveryTest()
            {
                targetFill = 1;
                base.BeforeEveryTest();
            }

            [Test]
            public void _1_full_hearts_are_depleted()
            {
                heartContainer.Deplete(1);

                Assert.AreEqual(0.75f, targetTail.fillAmount);
            }

            [Test]
            public void _2_hearts_are_depleted_in_order()
            {
                heartContainer.Deplete(1);

                Assert.AreEqual(1f, targetHead.fillAmount);
                Assert.AreEqual(0.75f, targetTail.fillAmount);
            }

            [Test]
            public void _3_hearts_are_depleted_with_5_pieces()
            {
                heartContainer.Deplete(5);

                Assert.AreEqual(0, hearts[NUMBER_OF_HEART - 1].CurrentNumberOfHeartPieces);
                Assert.AreEqual(3, hearts[NUMBER_OF_HEART - 2].CurrentNumberOfHeartPieces);
            }

            [Test]
            public void _4_hearts_are_depleted_with_10_pieces()
            {
                heartContainer.Deplete(10);

                Assert.AreEqual(0, hearts[NUMBER_OF_HEART - 1].CurrentNumberOfHeartPieces);
                Assert.AreEqual(0, hearts[NUMBER_OF_HEART - 2].CurrentNumberOfHeartPieces);
                Assert.AreEqual(2, hearts[NUMBER_OF_HEART - 3].CurrentNumberOfHeartPieces);
            }

            [Test]
            public void _6_throw_exception_for_negative_number_of_heart_pieces()
            {
                Assert.Throws<ArgumentException>(() => heartContainer.Deplete(-1));
            }
        }


    }

}