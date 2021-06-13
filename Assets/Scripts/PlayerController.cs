using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float mvtSpeed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + Vector3.forward * mvtSpeed * Time.deltaTime);
    }
}
