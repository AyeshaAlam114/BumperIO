using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform focalPosition;
    Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        moveSpeed = GetComponent<CharacterController>().moveSpeed;
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPosition.forward * verticalInput * moveSpeed * Time.deltaTime);
    }
}
