using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    private CharacterController Controller;
    public float Speed = 25f;
    public float JumpHeight = 10f;
    public float Gravity = 15f;
    private Vector3 MoveDirection = Vector3.zero;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(0, 1, 0);
        move = transform.forward * Speed * Time.deltaTime;
        Controller.Move(move);

        float moveX = 0;
        if (Input.GetKey(KeyCode.A)) moveX = -1;
        if (Input.GetKey(KeyCode.D)) moveX = 1;

        move = transform.right * moveX * Speed;

        if (Controller.isGrounded)
        {
            MoveDirection = move;
            MoveDirection.y = -2f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                MoveDirection.y = JumpHeight;
            }
        }
        else
        {
            MoveDirection.x = move.x;
            MoveDirection.z = move.z;
            MoveDirection.y -= Gravity * Time.deltaTime;
        }

        Controller.Move(MoveDirection * Time.deltaTime);
        Debug.Log("Grounded: " + Controller.isGrounded);
        Debug.Log(MoveDirection);

        //if (Controller.isGrounded)
        //{
        //    MoveDirection = Vector3.zero;

        //    if (Input.GetKey(KeyCode.Space))
        //    {
        //        MoveDirection.y = JumpHeight;
        //    }

        //    if (Input.GetKey(KeyCode.A))
        //    {
        //        MoveDirection += -transform.right * Speed;
        //    }

        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        MoveDirection += transform.right * Speed;
        //    }
        //}
        //MoveDirection.y -= Gravity * Time.deltaTime;
        //Controller.Move(MoveDirection * Time.deltaTime);
    }
}
