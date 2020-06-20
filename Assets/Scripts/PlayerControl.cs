﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float xMove;
    private float yMove;
    public float MoveSpeed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(xMove * MoveSpeed, yMove * MoveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
