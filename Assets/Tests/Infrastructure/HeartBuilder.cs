using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestEditor.Infrastructure
{
    public class HeartBuilder
    {
        private Image image;
        public HeartBuilder(Image image)
        {
            // x = y ?? z;
            // mean
            // x = (y != null ? y : z);
            this.image = image ?? Builder.Image();
        }

        public HeartBuilder() : this(Builder.Image())
        {
        }

        public HeartBuilder WithImage(Image image)
        {
            this.image = image;
            return this;
        }

        public Heart Build()
        {
            return new Heart(image);
        }

        public static implicit operator Heart(HeartBuilder heartBuilder)
        {
            return heartBuilder.Build();
        }
    }
}
