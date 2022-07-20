using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeartContainer
{
    private List<Heart> hearts;
    public HeartContainer(List<Heart> hearts)
    {
        this.hearts = hearts;
    }

    public void Replenish(int numberOfHeartPieces)
    {
        for (int i = 0, len = hearts.Count; i < len; i++)
        {
            var heart = hearts[i];
            
            heart.Replenish(numberOfHeartPieces);
            numberOfHeartPieces -= (heart.FilledHeartPieces);
            
            if (numberOfHeartPieces <= 0) break;
        }
    }

    public void Deplete(int numberOfHeartPieces)
    {
        for (int i = hearts.Count - 1; i > -1; i--)
        {
            var heart = hearts[i];
            
            heart.Deplete(numberOfHeartPieces);
            numberOfHeartPieces -= heart.EmptyHeartPieces;
            
            if (numberOfHeartPieces <= 0) break;
        }
    }

    public Heart this[int index]
    {
        get => hearts[index];
    }
}