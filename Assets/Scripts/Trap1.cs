using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    //public GameObject trap;

    public float Xpos = 0.0f;
    public float Ypos = 0.0f;
    public float Zpos = 0.0f;

    private bool triggered = false;

    void OnTriggerEnter(Collider collider)
    {
        if (!triggered)
        {
            Debug.Log("충돌");
            // Instantiate(
            //     trap,
            //     new Vector3(
            //         this.transform.position.x + Xpos,
            //         this.transform.position.y + Ypos,
            //         this.transform.position.z + Zpos),
            //         Quaternion.identity);
            triggered = true;
        }
    }
}
