﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 10.0f;
    public float rotateSpeed = 10.0f;
    public float jumpForce = 10.0f;

    private float h, v;

    private bool isGround = true;

    Rigidbody body;


    void Start()
    {
        body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);


        if (!(h == 0 && v == 0))
        {
            transform.position += dir.normalized * Speed * Time.deltaTime;
            //transform.Translate(dir * Speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGround = false;
        }
    }

    // 충돌 함수
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
