using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacGoBoard : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private TicTacGoManager manage;
    [SerializeField] private TicTacGoSelector select;

    private int[][] board = new int[3][];

    private void OnValidate()
    {
        images = new Image[transform.childCount];
        for(int i = 0; i < images.Length; i++)
        {
            images[i] = transform.GetChild(i).GetComponent<Image>();
            int j = i;
            transform.GetChild(i).GetComponent<Button>().onClick.AddListener(() => Board_OnClick(j));
        }
    }

    private void Awake()
    {
        for (int i = 0; i < images.Length; i++)
        {
            int j = i;
            images[i].GetComponent<Button>().onClick.AddListener(() => Board_OnClick(j));
        }

        for (int i = 0; i < board.Length; i++)
        {
            board[i] = new int[3];
            for (int j = 0; j < board[i].Length; j++)
                board[i][j] = 0;
        }
    }

    public void Board_OnClick(int i)
    {
        if (Mathf.Abs(board[i / 3][i % 3]) >= Mathf.Abs(select.value) || select.Check())
            return;

        board[i / 3][i % 3] = select.value;
        images[i].sprite = select.PlaceSprite();
        images[i].color = Color.white;

        int game = GameOver(out bool b);

        if (!b)
            manage.SwitchPlayer();
        else
            manage.EndGame(game);
    }

    private int GameOver(out bool b)
    {


        b = false;
        return 0;
    }
}
