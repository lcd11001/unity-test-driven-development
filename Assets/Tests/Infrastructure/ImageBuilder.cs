using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestEditor.Infrastructure
{
    public class ImageBuilder : DataBuilder<Image>
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

        public override Image Build()
        {
            var image = new GameObject().AddComponent<Image>();
            image.fillAmount = fillAmount;
            return image;
        }
    }
}
