using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    public static level instance;

    [SerializeField] private ShelfManager shelfManager;
    [SerializeField] private SpawnManager spawnManager;

    private ItemData[] items;

    public void UpdateShelf(ItemData[] items_)
    {
        // Shuffle the input array
        ShuffleItems(items_);

        // Assign the shuffled array to the 'items' field
        items = items_;

        shelfManager.updateShelves(items);
        spawnManager.SpawnItem();
    }
    public void SpawnItem()
    {
        spawnManager.SpawnItem();
    }

    private void ShuffleItems(ItemData[] items_)
    {
        // Fisher-Yates shuffle algorithm
        for (int i = items_.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1); // Get a random index
                                                      // Swap items
            ItemData temp = items_[i]; // Store current item
            items_[i] = items_[randomIndex]; // Replace current item with a random one
            items_[randomIndex] = temp; // Assign the stored item to the random position
        }
    }

    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
}
