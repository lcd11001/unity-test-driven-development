using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace TestEditor
{
    public class TestPlayer
    {
        public class TheCurrentHealthProperty
        {
            [Test]
            public void health_default_to_0()
            {
                var player = new Player(0);

                Assert.AreEqual(0, player.CurrentHealth);
            }

            [Test]
            public void throws_exception_when_current_health_is_less_than_0()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new Player(-1));
            }

            [Test]
            public void throws_exception_when_current_health_is_greater_than_maximum()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new Player(101, 100));
            }
        }

        public class TheHealMethod
        {
            [Test]
            public void zero_heal_does_nothing()
            {
                var player = new Player(0);

                player.Heal(0);

                Assert.AreEqual(0, player.CurrentHealth);
            }

            [Test]
            public void one_health_increment_current_health()
            {
                var player = new Player(0);

                player.Heal(1);

                Assert.AreEqual(1, player.CurrentHealth);
            }

            [Test]
            public void overhealing_is_ignored()
            {
                var player = new Player(0);

                player.Heal(12);

                Assert.AreEqual(10, player.CurrentHealth);
            }

            [Test]
            public void overkill_is_ignored()
            {
                var player = new Player(5);

                player.Damage(12);

                Assert.AreEqual(0, player.CurrentHealth);
            }
        }

        public class TheHealedEvent
        {
            [Test]
            public void raises_event_on_heal()
            {
                var amount = -1;
                var player = new Player(1);
                player.OnHealed += (sender, args) =>
                {
                    amount = args.Amount;
                };

                player.Heal(0);

                Assert.AreEqual(0, amount);
            }

            [Test]
            public void overhealing_is_ignored_event()
            {
                var amount = -1;
                var player = new Player(1, 1);
                player.OnHealed += (sender, args) =>
                {
                    amount = args.Amount;
                };

                player.Heal(1);

                Assert.AreEqual(0, amount);
            }
        }

        public class TheDamagedEvent
        {
            [Test]
            public void raises_event_on_damage()
            {
                var amount = -1;
                var player = new Player(1);
                player.OnDamaged += (sender, args) =>
                {
                    amount = args.Amount;
                };

                player.Damage(0);

                Assert.AreEqual(0, amount);
            }

            [Test]
            public void overkill_is_ignored_event()
            {
                var amount = -1;
                var player = new Player(0, 1);
                player.OnDamaged += (sender, args) =>
                {
                    amount = args.Amount;
                };

                player.Damage(1);

                Assert.AreEqual(0, amount);
            }
        }
    }
}
