using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestEditor.Infrastructure
{
    public class ImageBuilder
    {
        private float fillAmount;
        public ImageBuilder(float fillAmount)
        {
            this.fillAmount = fillAmount;
        }

        public ImageBuilder() : this(0)
        {
        }

        public ImageBuilder WithFillAmount(float fillAmount)
        {
            this.fillAmount = fillAmount;
            return this;
        }

        public Image Build()
        {
            var image = new GameObject().AddComponent<Image>();
            image.fillAmount = fillAmount;
            return image;
        }

        public static implicit operator Image(ImageBuilder imageBuilder)
        {
            // make code cleaner
            // var target = An.Image(targetFill).Build();
            // to
            // Image target = An.Image(targetFill);
            return imageBuilder.Build();
        }
    }
}
