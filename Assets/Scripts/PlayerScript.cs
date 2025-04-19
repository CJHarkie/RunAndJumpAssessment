using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    # Every Variable that had to be defined for this code
    private CharacterController Controller;
    public float Speed = 40f;
    public float JumpHeight = 20f;
    public float Gravity = 20f;
    public float PushForce = 5f;
    private Vector3 MoveDirection = Vector3.zero;
    [SerializeField] private TextMeshProUGUI ValuableText;
    public int Valuables = 0;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        # This function makes the character move forward on its own
        Vector3 move = new Vector3(0, 1, 0);
        move = transform.forward * Speed * Time.deltaTime; 
        Controller.Move(move);
        
        # This function makes the character move side to side
        float moveX = 0;
        if (Input.GetKey(KeyCode.A)) moveX = -1;
        if (Input.GetKey(KeyCode.D)) moveX = 1;

        move = transform.right * moveX * Speed;

        # This if statement is for how the character jumps when the character is grounded
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
    }

    # This bracket is for showing the valuable counter on the screen using TextMeshPro and making sure the valuables disappear once collided with by the character
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Valuables++;
            ValuableText.text = "Valuables: " + Valuables;
            Debug.Log("Valuables: " + Valuables);
            Destroy(other.gameObject);
        }
    }

    # This bracket is for crashing into certain objects with a rigidbody which lets the object get pushed once the character collides with it
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // Only push non-kinematic rigidbodies
        if (body != null && !body.isKinematic)
        {
            Vector3 pushDir = hit.moveDirection;
            pushDir.y = 0; // No vertical force
            body.AddForce(pushDir * PushForce, ForceMode.Impulse);

        }
    }
}
