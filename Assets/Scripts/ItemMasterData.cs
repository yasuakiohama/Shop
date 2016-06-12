using UnityEngine;
using System.Collections;

[CreateAssetMenu()]
public class ItemMasterData : ScriptableObject 
{
    public ItemData[] data;
}

[System.Serializable]
public class ItemData
{
    public int id;
    public string name;
    public int prise;
    public string text;
    public Sprite sprite;
}