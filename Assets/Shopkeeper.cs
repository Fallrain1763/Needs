using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    // Start is called before the first frame update
  public InteractArrow arrow;

  public bool inRange = false;

  public Dialogue dialogue;
   void Start()
    {
        arrow = GetComponentInChildren<InteractArrow>();
        arrow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player")){
            arrow.gameObject.SetActive(true);
            collider.GetComponent<Player>().inShop = true; 
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player")){
            arrow.gameObject.SetActive(false);
            collider.GetComponent<Player>().inShop = false;
            dialogue.StopDialogue();
        }
    }
}
