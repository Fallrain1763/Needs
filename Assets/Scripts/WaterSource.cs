using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSource : MonoBehaviour
{
    private InteractArrow arrow;

    void Start()
    {
        arrow = GetComponentInChildren<InteractArrow>();
        arrow.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player")){
            arrow.gameObject.SetActive(true);
            collider.GetComponent<Player>().drinkingWater = true; 
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player")){
            arrow.gameObject.SetActive(false);
            collider.GetComponent<Player>().drinkingWater = false;
        }
    }
}
