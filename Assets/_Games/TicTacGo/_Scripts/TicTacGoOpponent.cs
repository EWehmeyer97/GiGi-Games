using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacGoOpponent : MonoBehaviour
{
    [SerializeField] private TicTacGoItem[] toggles;

    private void OnValidate()
    {
        toggles = new TicTacGoItem[transform.childCount];
        for (int i = 0; i < toggles.Length; i++)
            toggles[i] = transform.GetChild(i).GetComponent<TicTacGoItem>();
    }

    public void UpdatePlayer(Sprite[] sprites, int[] vs)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            toggles[i].image.sprite = sprites[i];
            toggles[i].text.text = vs[i].ToString();
        }
    }
}
