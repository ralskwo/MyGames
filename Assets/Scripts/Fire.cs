using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }
    void Update()
    {
        transform.Translate(Vector3.up * 30.0f * Time.deltaTime);
    }
}
