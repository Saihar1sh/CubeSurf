using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Rigidbody rb;

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

        if (other.gameObject.tag == "Boost")
        {
            CubesManager.Instance.BoostPowerPickup();
        }

    }
}
