using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController characterController;
    public float MovementSpeed = 1;
    public GameObject Self;
    private float velocity = 0;
    public float Gravity = 9.8f;
    public static int PelletsRemaining = 75;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // player movement - forward, backward, left, right
        if(PlayerCamera.MovementSuppressed == false)
        {
            float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
            float vertical = Input.GetAxis("Vertical") * MovementSpeed;
            characterController.Move((PlayerCamera.cam.transform.right * horizontal + PlayerCamera.cam.transform.forward * vertical) * Time.deltaTime);
        }
        // Gravity
        if (characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Debug.Log("Player should be dying.");
            PlayerCamera.MovementSuppressed = true;
            Destroy(Self);
        }

        else if (collision.gameObject.CompareTag("Pellet"))
        {
            Debug.Log("Hit a pellet.");
            PelletsRemaining--;
            string EatenPellet = collision.gameObject.name;
            Debug.Log(EatenPellet);
            GameObject DeadPellet = GameObject.Find(EatenPellet);
            Destroy(DeadPellet);
        }
    }
}
