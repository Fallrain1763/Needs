using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform targetPlayer;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = targetPlayer.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y,-10);
    }
}
