using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorTrap : MonoBehaviour
{
    public GameObject image;
    public Transform FirePos;

    private bool isTriggered = false;

    void OnTriggerEnter(Collider collider)
    {
        if (!isTriggered)
        {
            MakeImage();
        }
        isTriggered = true;
    }
    void MakeImage()
    {
        Instantiate(image, FirePos.transform.position, FirePos.transform.rotation);
    }

}
