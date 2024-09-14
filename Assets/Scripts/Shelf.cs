using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private ItemData item;

    public void updateSprite(ItemData item_)
    {
        item = item_;
        spriteRenderer.sprite = item.ItemSprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerMovement>().CheckItenID(item.ItemID))
            {
                SFXManager.instance.DropSound();

                Debug.Log("Item : " + item.ItemName + " Delivered");
                // Item Delivered

                level.instance.SpawnItem();
            }
        }
    }
}
