using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

public class CreateShopItem : MonoBehaviour
{
    [SerializeField]
    private int[] itemIds;
    [SerializeField]
    private GameObject yesNoCanvas;
    [SerializeField]
    private Transform shopContent;
    [SerializeField]
    private Text itemText;

    public Action<int> Init()
    {
        Action<int> onChangeCoin = (coin) => { };

        foreach (int id in itemIds) {
            var item = (Instantiate (Resources.Load ("Prefabs/ItemButton")) as GameObject).transform;
            item.SetParent (shopContent, false);
            item.GetComponent<ShowItemData> ().SetItemData (id);

            Button button = item.FindChild ("Button").GetComponent<Button> ();
            Button panel = item.GetComponent<Button> ();

            int key = id;

            button.onClick.AddListener (() => {
                OnClickSendYesNoWindow (key);
            });

            panel.onClick.AddListener (() => {
                OnClickButton (key);
            });

            onChangeCoin += (coin) => {
                bool canBuy = coin >= ItemMasterData.GetValue (key).prise;
                button.interactable = canBuy;
                panel.interactable = canBuy;
            };
        }

        ItemTextInit ();

        return onChangeCoin;
    }

    private void ItemTextInit()
    {
        if (ItemMasterData.GetLength () > 0 && itemIds.Length > 0) {
            itemText.text = ItemMasterData.GetValue (itemIds [0]).text;
        } else {
            itemText.text = "品切れです";
        }
    }

    private void OnClickButton(int id)
    {
        itemText.text = ItemMasterData.GetValue (id).text;
    }

    private void OnClickSendYesNoWindow(int id)
    {
        itemText.text = ItemMasterData.GetValue (id).text;
        yesNoCanvas.SetActive (true);
        yesNoCanvas.GetComponent<ShowItemData> ().SetItemData (id);
    }
}
