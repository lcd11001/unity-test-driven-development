using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestEditor.Infrastructure
{
    public class HeartContainerBuilder : DataBuilder<HeartContainer>
    {
        private List<Heart> hearts;
        public HeartContainerBuilder(List<Heart> hearts)
        {
            this.hearts = hearts;
        }

        public HeartContainerBuilder() : this(new List<Heart>())
        {
        }

        public HeartContainerBuilder WithHeart(params Heart[] hearts)
        {
            this.hearts.AddRange(hearts);
            return this;
        }

        public override HeartContainer Build()
        {
            return new HeartContainer(hearts);
        }
    }
}
