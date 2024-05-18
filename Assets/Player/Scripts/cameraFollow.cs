using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float zOffset, yOffset;

    // Update is called once per frame
    void Update()
    {
        // Pasunorin camera sa character
        Vector3 follow = new Vector3(target.position.x, target.position.y - yOffset, zOffset);
        transform.position = follow;
    }
}
