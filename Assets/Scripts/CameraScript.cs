using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, 0);
    void Start()
    {
        
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
