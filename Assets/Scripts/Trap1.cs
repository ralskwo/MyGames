using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    //public GameObject trap;


    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("충돌");
    }
}
