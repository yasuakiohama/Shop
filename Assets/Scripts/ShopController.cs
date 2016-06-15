using UnityEngine;
using System.Collections;

public class ShopController : MonoBehaviour
{
    private void Start ()
    {
        CoinManager coinManager = GetComponent<CoinManager> ();
        CreateShopItem createShopItem = GetComponent<CreateShopItem> ();

        coinManager.Init (createShopItem.Init ());
    }
}
