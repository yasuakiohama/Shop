using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowItemData : MonoBehaviour
{
    private ItemData itemData;
    public Image image;
    public Text itemName;
    public Text price;

    public void SetItemData(int id)
    {
        itemData = ItemMasterData.GetValue (id);
        image.sprite = itemData.sprite;
        itemName.text = itemData.name;
        price.text = itemData.prise.ToString ();
    }

    public int GetPrice {
        get {
            return itemData.prise;
        }
    }
}
