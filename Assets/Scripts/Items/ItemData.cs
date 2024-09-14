using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]

public class ItemData : ScriptableObject
{
    public int ItemID;
    public string ItemName;
    public Sprite ItemSprite;
}