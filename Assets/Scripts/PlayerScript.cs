using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    CharacterController Controller;
    public float speed = 25f;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = transform.forward * speed * Time.deltaTime;
        Controller.Move(move);
    }
}
