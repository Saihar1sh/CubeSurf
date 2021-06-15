using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoSingletonGeneric<CameraFollow>
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offset;

    void Update()
    {
        transform.position = player.position + offset;
    }
    public void SetTargetPlayer(Transform t)
    {
        player = t;
    }
}
