using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System;
using System.Reflection;

public class CoinManager : MonoBehaviour
{
    private const string COIN_KEY = "Coin";
    private Action<int> onChangeCoin = (coin) => {};
    [SerializeField]
    private GameObject yesNoCanvas;
    [SerializeField]
    private Text coinText;

    public void Init(Action<int> onChangeCoin)
    {
        this.onChangeCoin += onChangeCoin;
        this.onChangeCoin += (coin) => {
            coinText.text = coin.ToString ();
        };

        yesNoCanvas.transform.FindChild ("YesNoPanel/Yes").GetComponent<Button> ().onClick.AddListener (() => {
            SubCoin (yesNoCanvas.GetComponent<ShowItemData> ().GetPrice);
        });

        this.onChangeCoin (LoadCoin ());
    }

    private int LoadCoin()
    {
        return PlayerPrefs.GetInt (COIN_KEY, 0);
    }

    private void ChangeCoin(int coin)
    {
        PlayerPrefs.SetInt (COIN_KEY, coin);
        PlayerPrefs.Save ();
        onChangeCoin (PlayerPrefs.GetInt (COIN_KEY, 0));
    }

    private void AddCoin(int coin)
    {
        if (coin < 0) {
            return;
        }
        ChangeCoin (LoadCoin () + coin);
    }

    private void SubCoin(int coin)
    {
        if (coin < 0) {
            return;
        }

        if (LoadCoin () - coin < 0) {
            return;
        }

        ChangeCoin (LoadCoin () - coin);
    }
}
