using System;
using UnityEngine;
using UnityEngine.UI;

public class Heart
{
    public const int PIECES_PER_HEART = 4;
    public const float FILL_PER_HEART_PIECE = 1.0f / PIECES_PER_HEART;
    private readonly Image image;
    private readonly int heartId;

    public Heart(Image image)
    {
        this.image = image;
    }

    public int FilledHeartPieces
    {
        get => CalculateFilledHeartPieces();
    }

    public int EmptyHeartPieces
    {
        get => PIECES_PER_HEART - CalculateFilledHeartPieces();
    }

    private int CalculateFilledHeartPieces() => (int)(image.fillAmount * PIECES_PER_HEART);

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