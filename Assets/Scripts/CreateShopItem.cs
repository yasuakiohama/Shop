using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class CreateShopItem : MonoBehaviour
{
    public int[] itemIds;
    public GameObject yesNoCanvas;
    public Transform shopContent;
    public Text itemText;
    private Dictionary<int,ItemData> itemDictionary;

    void Start ()
    {
        CreateItemKeyValue ();

        foreach (int itemId in itemIds) {
            var item = Instantiate (Resources.Load ("Prefabs/ItemButton")) as GameObject;
            item.name = "ItemButton";
            item.transform.SetParent (shopContent, false);
            item.transform.FindChild ("Image").GetComponent<Image> ().sprite = itemDictionary [itemId].sprite;
            item.transform.FindChild ("Name").GetComponent<Text> ().text = itemDictionary [itemId].name;
            item.transform.FindChild ("Prise").GetComponent<Text> ().text = itemDictionary [itemId].prise.ToString ();

            Button.ButtonClickedEvent buttonClickedEvent = item.transform.FindChild ("Button").GetComponent<Button> ().onClick;
            UnityEditor.Events.UnityEventTools.AddPersistentListener (buttonClickedEvent, OnClick);

            Button.ButtonClickedEvent panelClickedEvent = item.transform.GetComponent<Button> ().onClick;
            UnityEditor.Events.UnityEventTools.AddIntPersistentListener (panelClickedEvent, OnClick, itemId);
        }

        if (itemDictionary.Count > 0 && itemIds.Length > 0) {
            itemText.text = itemDictionary [itemIds [0]].text;
        } else {
            itemText.text = "品切れです";
        }
    }

    void OnClick(int id)
    {
        itemText.text = itemDictionary [id].text;
    }

    void OnClick()
    {
        yesNoCanvas.SetActive (true);
    }

    public void CreateItemKeyValue()
    {
        ItemMasterData itemMasterData = Resources.Load ("ItemMasterData") as ItemMasterData;
        itemDictionary = new Dictionary<int, ItemData> ();
        foreach (ItemData data in itemMasterData.data) {
            itemDictionary.Add (data.id, data);
        }
    }
}
