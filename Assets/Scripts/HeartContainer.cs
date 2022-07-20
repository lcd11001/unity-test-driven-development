using System;
using System.Collections.Generic;
using System.Linq;
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
        // left to right
        foreach (var heart in hearts)
        {
            int pieces = Math.Min(numberOfHeartPieces, heart.EmptyHeartPieces);
            heart.Replenish(pieces);
            numberOfHeartPieces -= pieces;

            if (numberOfHeartPieces <= 0) break;
        }
    }

    public void Deplete(int numberOfHeartPieces)
    {
        // right to left
        // Must use System.Linq
        foreach (var heart in hearts.AsEnumerable().Reverse())
        {
            int pieces = Math.Min(numberOfHeartPieces, heart.FilledHeartPieces);
            heart.Deplete(pieces);
            numberOfHeartPieces -= pieces;

            if (numberOfHeartPieces <= 0) break;
        }
    }

    public Heart this[int index]
    {
        get => hearts[index];
    }
}