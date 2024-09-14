using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    [SerializeField] private Shelf[] shelves;

    public void updateShelves(ItemData[] sprites)
    {
        for(int i = 0; i < shelves.Length; i++)
        {
            shelves[i].updateSprite(sprites[i]);
        }
    }
}
