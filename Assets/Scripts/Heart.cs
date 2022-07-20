using System;
using UnityEngine.UI;

public class Heart
{
    private const float FILL_PER_HEART_PIECE = 0.25f;
    private readonly Image image;

    public Heart(Image image)
    {
        this.image = image;
    }

    public void Replenish(int numberOfHeartPieces)
    {
        image.fillAmount += numberOfHeartPieces * FILL_PER_HEART_PIECE;
    }
}