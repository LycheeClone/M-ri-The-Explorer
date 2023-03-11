using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed;
    private Vector3 _distanceByPlayer;

    void Start()
    {
        _distanceByPlayer = CalculateDistance(player);
    }

    void FixedUpdate()
    {
        MoveTheCamera();
    }

    private void MoveTheCamera()
    {
        var position = player.position;
        var lookAtPlayer = position + _distanceByPlayer;
        transform.position = Vector3.Lerp(transform.position, lookAtPlayer, cameraSpeed * Time.deltaTime);
        //transform.LookAt(position);
    }

    private Vector3 CalculateDistance(Transform newTarget)
    {
        return transform.position - newTarget.position;
    }
}