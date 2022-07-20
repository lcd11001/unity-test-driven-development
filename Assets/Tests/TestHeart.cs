using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TestHeart
{
    [Test]
    public void _0_set_image_with_0_fill_to_0_percent_fill()
    {
        var image = new GameObject().AddComponent<Image>();
        image.fillAmount = 0f;

        var heart = new Heart(image);
        heart.Replenish(0);
        
        Assert.AreEqual(0f, image.fillAmount);
    }

    [Test]
    public void _1_set_image_with_0_fill_to_25_percent_fill()
    {
        var image = new GameObject().AddComponent<Image>();
        image.fillAmount = 0f;

        var heart = new Heart(image);
        heart.Replenish(1);
        
        Assert.AreEqual(0.25f, image.fillAmount);
    }

    [Test]
    public void _3_set_image_with_25_fill_to_50_percent_fill()
    {
        var image = new GameObject().AddComponent<Image>();
        image.fillAmount = 0.25f;

        var heart = new Heart(image);
        heart.Replenish(1);
        
        Assert.AreEqual(0.5f, image.fillAmount);
    }

    [Test]
    public void _4_set_image_with_50_fill_to_75_percent_fill()
    {
        var image = new GameObject().AddComponent<Image>();
        image.fillAmount = 0.5f;

        var heart = new Heart(image);
        heart.Replenish(1);
        
        Assert.AreEqual(0.75f, image.fillAmount);
    }

    [Test]
    public void _5_set_image_with_75_fill_to_100_percent_fill()
    {
        var image = new GameObject().AddComponent<Image>();
        image.fillAmount = 0.75f;

        var heart = new Heart(image);
        heart.Replenish(1);
        
        Assert.AreEqual(1f, image.fillAmount);
    }
}
