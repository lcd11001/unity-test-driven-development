using System;
using UnityEngine.UI;

public class Heart
{
    private const int PIECES_PER_HEART = 4;
    private const float FILL_PER_HEART_PIECE = 1.0f / PIECES_PER_HEART;
    private readonly Image image;

    public Heart(Image image)
    {
        this.image = image;
    }

    public int CurrentNumberOfHeartPieces => (int)(image.fillAmount * PIECES_PER_HEART);

    public void Replenish(int numberOfHeartPieces)
    {
        if (numberOfHeartPieces < 0)
        {
            throw new ArgumentException("don't accept negative value", "numberOfHeartPieces");
        }
        image.fillAmount += numberOfHeartPieces * FILL_PER_HEART_PIECE;
    }

    public void Deplete(int numberOfHeartPieces)
    {
        if (numberOfHeartPieces < 0)
        {
            throw new ArgumentException("don't accept negative value", "numberOfHeartPieces");
        }
        image.fillAmount -= numberOfHeartPieces * FILL_PER_HEART_PIECE;
    }
}