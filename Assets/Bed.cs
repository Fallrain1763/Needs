using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bed : MonoBehaviour
{
    // Start is called before the first frame update
    public InteractArrow arrow;
    void Start()
    {
        arrow = GetComponentInChildren<InteractArrow>();
        arrow.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player")){
            arrow.gameObject.SetActive(true);
            collider.GetComponent<Player>().inBed = true; 
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player")){
            arrow.gameObject.SetActive(false);
            collider.GetComponent<Player>().inBed = false;
        }
    }
}
