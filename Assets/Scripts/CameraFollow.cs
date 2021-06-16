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
        transform.position = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * 5f);
        if (CubesManager.Instance.cubes.Count >= 20)
            offset.z = -25;
    }
    public void SetTargetPlayer(Transform t)
    {
        player = t;
    }
}
