using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float moveSpeed;
    Rigidbody enemyRb;
    GameObject playerRb;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerRb = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (playerRb != null)
        {
            moveSpeed = GetComponent<CharacterController>().moveSpeed;
            Vector3 moveDirection = (playerRb.transform.position - transform.position).normalized;
            enemyRb.AddForce(moveDirection * moveSpeed * Time.deltaTime);
        }
       
    }
}
