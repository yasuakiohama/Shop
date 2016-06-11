using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class CreateShopItem : MonoBehaviour
{
    public int num;
    public GameObject yesNoCanvas;
    public Transform shopContent;

    void Start ()
    {
        for (int i = 0, n = num; i < n; i++) {
            var item = Instantiate (Resources.Load ("Prefabs/ItemButton")) as GameObject;
            item.name = "ItemButton";
            item.transform.SetParent (shopContent, false);

            Button.ButtonClickedEvent buttonClickedEvent = item.transform.FindChild ("Button").GetComponent<Button> ().onClick;
            buttonClickedEvent.AddListener (() => {
                yesNoCanvas.SetActive (true);
            });

            UnityEditor.Events.UnityEventTools.AddObjectPersistentListener<GameObject> (buttonClickedEvent, OnClick, gameObject);
        }
    }

    void OnClick(GameObject obj)
    {
        Debug.Log (obj.name);
    }
}
