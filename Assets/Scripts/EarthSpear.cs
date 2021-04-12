using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EarthSpear : MonoBehaviour
{
    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            body.AddForce(Vector3.up * 25, ForceMode.Impulse);
    }
    // void OnTriggerEnter(Collider collider)
    // {
    //     body.AddForce(Vector3.up * 10, ForceMode.Impulse);
    // }
}
