using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class ItemSpawnerData
    {
        public ItemData itemData;
        public int spawns;
    }

    [SerializeField] private ItemSpawnerData[] itemData;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private int itemSpawnedID;
    private bool itemSpawned;

    public void SpawnItem()
    {
        SpawnItems();
    }

    private void SpawnItems()
    {
        int num = Random.Range(0, itemData.Length);

        if (itemData[num].spawns > 0)
        {
            SFXManager.instance.SpawnSound();

            spriteRenderer.sprite = itemData[num].itemData.ItemSprite;
            itemData[num].spawns--;
            itemSpawnedID = num;
            itemSpawned= true;
        }
        else
        {
            for(int i = 0; i < itemData.Length; i++)
            {
                if (itemData[i].spawns > 0)
                {
                    SFXManager.instance.SpawnSound();

                    spriteRenderer.sprite = itemData[i].itemData.ItemSprite;
                    itemData[i].spawns--;
                    itemSpawnedID = i;
                    itemSpawned= true;

                    break;
                }
                if(i == itemData.Length - 1)
                {
                    // Items Empty
                    Debug.Log("No more Items to spawn");

                    GameManager.instance.Won();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (itemSpawned)
            {
                SFXManager.instance.PickSound();

                Debug.Log("Item : " + itemData[itemSpawnedID].itemData.ItemName + " Handed");
                // Item Handed

                collision.GetComponent<PlayerMovement>().SetItem(itemData[itemSpawnedID].itemData);
                spriteRenderer.sprite = null;
                itemSpawned = false;
            }
        }
    }
}
