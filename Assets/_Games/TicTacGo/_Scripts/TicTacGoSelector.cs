using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TicTacGoSelector : MonoBehaviour
{
    [SerializeField] private TicTacGoManager manage;
    [SerializeField] private TicTacGoOpponent opponent;
    [SerializeField] private TicTacGoItem[] toggles;

    [HideInInspector] public int value = 1;
    private int mult = -1;

    private int[] xCount = { 2, 2, 2 };
    private int[] oCount = { 2, 2, 2 };

    private void OnValidate()
    {
        toggles = new TicTacGoItem[transform.childCount];
        for (int i = 0; i < toggles.Length; i++)
            toggles[i] = transform.GetChild(i).GetComponent<TicTacGoItem>();
    }

    private void Awake()
    {
        for (int i = 0; i < toggles.Length; i++)
            toggles[i].toggle.onValueChanged.AddListener(Toggle_OnClick);
    }

    public void Toggle_OnClick(bool b)
    {
        for(int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].toggle.isOn)
            {
                value = (i + 1) * mult;
                return;
            }
        }
    }

    public void UpdatePlayer(Sprite[] sprites, Sprite[] oppSprites)
    {
        mult *= -1;
        for(int i = 0; i < sprites.Length; i++)
        {
            toggles[i].toggle.interactable = (mult > 0 ? xCount[i] > 0 : oCount[i] > 0) && manage.turn > i;
            toggles[i].image.sprite = sprites[i];
            toggles[i].text.text = mult > 0 ? xCount[i].ToString() : oCount[i].ToString();

            value = mult * value;
        }

        opponent.UpdatePlayer(oppSprites, mult > 0 ? oCount : xCount);
    }

    public Sprite PlaceSprite()
    {
        if (mult > 0)
            xCount[Mathf.Abs(value) - 1]--;
        else
            oCount[Mathf.Abs(value) - 1]--;

        return toggles[Mathf.Abs(value) - 1].image.sprite;
    }

    public bool Check()
    {
        return !toggles[Mathf.Abs(value) - 1].toggle.interactable;
    }
}
