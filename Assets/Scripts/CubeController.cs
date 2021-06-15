using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float mvtSpeed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void Start()
    {
        CubesManager.Instance.cubeRbs.Add(rb);
    }
    void Update()
    {
        //rb.MovePosition(rb.position + Vector3.forward * mvtSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacles")
        {
            CubesManager.Instance.cubes.Remove(this);
            CubesManager.Instance.cubeRbs.Remove(rb);
            this.enabled = false;

        }

        if (other.gameObject.tag == "CollectableCubes")
        {
            CubesManager.Instance.AddCubes();
            other.gameObject.SetActive(false);
        }
    }
}
