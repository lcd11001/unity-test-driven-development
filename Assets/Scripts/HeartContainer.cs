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
        int numberOfHeartPiecesRemaining = numberOfHeartPieces;
        foreach (var heart in hearts)
        {
            numberOfHeartPiecesRemaining -= (Heart.PIECES_PER_HEART - heart.CurrentNumberOfHeartPieces);
            heart.Replenish(numberOfHeartPieces);
            if (numberOfHeartPiecesRemaining <= 0) break;
        }
    }

    public void Deplete(int numberOfHeartPieces)
    {
        foreach (var heart in hearts)
        {
            heart.Deplete(numberOfHeartPieces);
        }
    }
}