﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // public Material[] materials;
    public Renderer rend;
    public Transform trans;
    public bool isPressed;
    // 0 = Stand, 1 = Run , 2 = Sneak, 3 = Crawl
    public int playerState = 0;
    public float sneakHeight = 0.55f;
    public float crawlHeight = 0.2f;
    public GameState gameState;

    Rigidbody rigidBody;
    float hori;
    float vert;

    public float speed = 10.0f;

    void Start()
    {
        isPressed = false;
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerState = 0;
        }
        if (playerState == 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            speed = 10.0f;
            rend.GetComponent<Renderer>().material.color = Color.white;
        }

        if (playerState == 1)
        {
            transform.localRotation = Quaternion.Euler(80, 0, 0);
            speed = 15.0f;
            rend.GetComponent<Renderer>().material.color = Color.red;
        }
        if (playerState == 2)
        {
            transform.localRotation = Quaternion.Euler(10, 0, 0);
            speed = 7.0f;
            rend.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (playerState == 3)
        {

            transform.localRotation = Quaternion.Euler(30, 0, 0);
            speed = 3.0f;
            rend.GetComponent<Renderer>().material.color = Color.green;
        }

        hori = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
        rigidBody.velocity = new Vector3(hori * speed, 0, vert * speed);
    }
    void Update()
    {
        if (!isPressed)
        {
            
        }

        // Run
        if (Input.GetKey(KeyCode.Space))
        {
            isPressed = !isPressed;
            if (isPressed)
            {
                playerState = 1;
                Debug.Log("this is 1");
            }
        }
       
        // Sneak
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isPressed = !isPressed;
            if (isPressed)
            {
                playerState = 2;
                Debug.Log("this is 2");
            }
        }
        // Crawl
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isPressed = !isPressed;
            if (isPressed)
            {
                playerState = 3;
                Debug.Log("this is 3");
            }
        }

        gameState.playerState = playerState;
    }
}
