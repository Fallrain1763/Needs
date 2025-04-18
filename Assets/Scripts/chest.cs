using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    private InteractArrow arrow;
    // Start is called before the first frame update
    void Start()
    {
        arrow = GetComponentInChildren<InteractArrow>();
        arrow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            arrow.gameObject.SetActive(true);    
    
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            arrow.gameObject.SetActive(false);    
        }
    }
}
