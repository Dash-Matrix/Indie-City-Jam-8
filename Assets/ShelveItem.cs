using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelveItem : MonoBehaviour
{
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerScript = collision.gameObject.GetComponent<PlayerMovement>();
            if(playerScript.currentHolding != null)
            {
                string baseName = playerScript.currentHolding.name.Replace("(Clone)", "").Trim();
                if (baseName.Equals(this.name))
                {
                    Manager.holding = false;
                }
            }
            
        }
    }

}
