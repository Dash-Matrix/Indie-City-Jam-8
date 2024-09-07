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

        SFXManager.instance.StartGamePlayThemeMusic();
        Timer timer = GameObject.Find("Timer BG").GetComponent<Timer>();
        timer.StartTimer(50);
    }
    void Update()
    {

        if(!holding)
        {
            int randomIndex = Random.Range(0, gameObjects.Count);
            Debug.Log("hi");
            SFXManager.instance.SpawnSound();
            GameObject temp = Instantiate(gameObjects[randomIndex], placementPoint.transform.position, Quaternion.identity);
            holding = true;
        }
        // Example: Remove objects from the list or perform operations with them
    }
}