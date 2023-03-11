using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownRestart : MonoBehaviour
{
    [SerializeField] private float posX, posY, posZ;

    void Update()
    {
        if (transform.position.y < -5)
        {
            transform.position = new Vector3(posX, posY, posZ);
        }
    }
}