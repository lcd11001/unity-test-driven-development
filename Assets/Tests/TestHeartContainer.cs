using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TestEditor.Infrastructure;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace TestEditor
{

    public class TestHeartContainer
    {
        private Image target;
        private float targetFill;

        private HeartContainer heartContainer;

        [SetUp]
        public virtual void BeforeEveryTest()
        {
            target = Builder.Image().WithFillAmount(targetFill);
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
                heartContainer = Builder
                    .HeartContainer()
                    .WithHeart(
                        Builder.Heart().WithImage(target)
                    );

                heartContainer.Replenish(1);

                Assert.AreEqual(0.25f, target.fillAmount);
            }

            [Test]
            public void _2_hearts_are_replenished_in_order()
            {
                heartContainer = Builder
                    .HeartContainer()
                    .WithHeart(
                        Builder.Heart().WithImage(target),
                        Builder.Heart()
                    );


                heartContainer.Replenish(1);

                Assert.AreEqual(0.25f, target.fillAmount);
                Assert.AreEqual(0, heartContainer[1].FilledHeartPieces);
            }

            [Test]
            public void _3_hearts_are_replenished_with_5_pieces()
            {
                heartContainer = Builder
                    .HeartContainer()
                    .WithHeart(
                        Builder.Heart(),
                        Builder.Heart()
                    );

                heartContainer.Replenish(5);

                Assert.AreEqual(4, heartContainer[0].FilledHeartPieces);
                Assert.AreEqual(1, heartContainer[1].FilledHeartPieces);
            }

            [Test]
            public void _4_hearts_are_replenished_with_10_pieces_from_0_index()
            {
                heartContainer = Builder
                    .HeartContainer()
                    .WithHeart(
                        Builder.Heart(),
                        Builder.Heart(),
                        Builder.Heart()
                    );

                heartContainer.Replenish(10);

                Assert.AreEqual(4, heartContainer[0].FilledHeartPieces);
                Assert.AreEqual(4, heartContainer[1].FilledHeartPieces);
                Assert.AreEqual(2, heartContainer[2].FilledHeartPieces);
            }

            [Test]
            public void _5_hearts_are_replenished_with_10_pieces_from_1_index()
            {
                heartContainer = Builder
                    .HeartContainer()
                    .WithHeart(
                        Builder.Heart().WithImage(Builder.Image().WithFillAmount(1)),
                        Builder.Heart(),
                        Builder.Heart(),
                        Builder.Heart()
                    );

                heartContainer.Replenish(10);

                Assert.AreEqual(4, heartContainer[0].FilledHeartPieces);
                Assert.AreEqual(4, heartContainer[1].FilledHeartPieces);
                Assert.AreEqual(4, heartContainer[2].FilledHeartPieces);
                Assert.AreEqual(2, heartContainer[3].FilledHeartPieces);
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
                heartContainer = Builder
                    .HeartContainer()
                    .WithHeart(
                        Builder.Heart().WithImage(target)
                    );

                heartContainer.Deplete(1);

                Assert.AreEqual(0.75f, target.fillAmount);
            }

            [Test]
            public void _2_hearts_are_depleted_in_order()
            {
                heartContainer = Builder
                    .HeartContainer()
                    .WithHeart(
                        Builder.Heart().WithImage(target),
                        Builder.Heart().WithImage(Builder.Image().WithFillAmount(1))
                    );

                heartContainer.Deplete(1);

                Assert.AreEqual(1f, target.fillAmount);
                Assert.AreEqual(3, heartContainer[1].FilledHeartPieces);
            }

            [Test]
            public void _3_hearts_are_depleted_with_5_pieces()
            {
                heartContainer = Builder
                    .HeartContainer()
                    .WithHeart(
                        Builder.Heart().WithImage(Builder.Image().WithFillAmount(1)),
                        Builder.Heart().WithImage(Builder.Image().WithFillAmount(1)),
                        Builder.Heart().WithImage(Builder.Image().WithFillAmount(1))
                    );

                heartContainer.Deplete(5);

                Assert.AreEqual(0, heartContainer[2].FilledHeartPieces);
                Assert.AreEqual(3, heartContainer[1].FilledHeartPieces);
            }

            [Test]
            public void _4_hearts_are_depleted_with_10_pieces_from_last_index()
            {
                heartContainer = Builder
                    .HeartContainer()
                    .WithHeart(
                        Builder.Heart().WithImage(Builder.Image().WithFillAmount(1)),
                        Builder.Heart().WithImage(Builder.Image().WithFillAmount(1)),
                        Builder.Heart().WithImage(Builder.Image().WithFillAmount(1))
                    );

                heartContainer.Deplete(10);

                Assert.AreEqual(0, heartContainer[2].FilledHeartPieces);
                Assert.AreEqual(0, heartContainer[1].FilledHeartPieces);
                Assert.AreEqual(2, heartContainer[0].FilledHeartPieces);
            }

            [Test]
            public void _5_hearts_are_depleted_with_10_pieces_from_last1_index()
            {
                heartContainer = Builder
                    .HeartContainer()
                    .WithHeart(
                        Builder.Heart().WithImage(Builder.Image().WithFillAmount(1)),
                        Builder.Heart().WithImage(Builder.Image().WithFillAmount(1)),
                        Builder.Heart().WithImage(Builder.Image().WithFillAmount(1)),
                        Builder.Heart().WithImage(Builder.Image().WithFillAmount(0))
                    );

                heartContainer.Deplete(10);

                Assert.AreEqual(0, heartContainer[3].FilledHeartPieces);
                Assert.AreEqual(0, heartContainer[2].FilledHeartPieces);
                Assert.AreEqual(0, heartContainer[1].FilledHeartPieces);
                Assert.AreEqual(2, heartContainer[0].FilledHeartPieces);
            }

            [Test]
            public void _6_throw_exception_for_negative_number_of_heart_pieces()
            {
                Assert.Throws<ArgumentException>(() => heartContainer.Deplete(-1));
            }
        }


    }

}