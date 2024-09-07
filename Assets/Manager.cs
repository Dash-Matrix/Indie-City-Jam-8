using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public GameObject[] shelveItems = new GameObject[10];
    public static bool isDelievered = false;
    public static bool holding = false;
    public Transform placementPoint;


    private void Start()
    { 
      

    }
    void Update()
    {

        if(!holding)
        {
            int randomIndex = Random.Range(0, gameObjects.Count);

            GameObject temp = Instantiate(gameObjects[randomIndex], placementPoint.transform.position, Quaternion.identity);
            holding = true;
        }
        // Example: Remove objects from the list or perform operations with them
    }
}