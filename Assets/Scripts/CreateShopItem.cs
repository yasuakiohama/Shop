using UnityEngine;
using System.Collections;

public class CreateShopItem : MonoBehaviour
{
    public int num;

    void Start ()
    {
        for (int i = 0, n = num; i < n; i++) {
            var item = Instantiate (Resources.Load ("Prefabs/ItemButton")) as GameObject;
            item.name = "ItemButton";
            item.transform.SetParent (transform, false);
        }
    }
}
