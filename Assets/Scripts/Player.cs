using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private BoxCollider magnetPowerCollider;


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

}