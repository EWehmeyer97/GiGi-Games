using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacGoManager : MonoBehaviour
{
    [SerializeField] private Sprite[] oPieces;
    [SerializeField] private Sprite[] xPieces;

    [SerializeField] private TicTacGoSelector select;
    int mult = 1;

    [System.NonSerialized] public int turn = 1;

    private void Start()
    {
        SwitchPlayer();
    }

    public void SwitchPlayer()
    {
        if (mult > 0)
            select.UpdatePlayer(xPieces, oPieces);
        else
            select.UpdatePlayer(oPieces, xPieces);

        turn++;
        mult *= -1;
    }

    public void EndGame(int game)
    {
        if (game > 0)
            turn++;
        else if (game < 0)
            turn++;
        else
            turn++;
    }
}
