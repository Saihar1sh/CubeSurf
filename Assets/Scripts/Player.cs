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

    public void EnablePlayerMovement(bool p)
    {
        this.enabled = p;
    }

}