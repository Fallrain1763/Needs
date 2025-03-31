using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractArrow : MonoBehaviour
{

    public float movementSpeed;

    public float movementRange;
    public GameObject player;
    // Start is called before the first frame update

    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        float yOpffset = Mathf.PingPong(Time.time * movementSpeed, movementRange);
        //Debug.Log(y);
        transform.position = new Vector3(startPos.x, startPos.y+yOpffset, startPos.z);
    }
}
