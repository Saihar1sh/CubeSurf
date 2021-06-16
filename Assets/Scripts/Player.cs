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
        magnetPowerCollider.enabled = false;

    }

    public void MagnetPickup()
    {
        Debug.Log("5 secs started");
        CubesManager.Instance.MagnetPowerPickup(magnetPowerCollider, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollectableCubes")
        {
            CubesManager.Instance.AddCubes();
            other.gameObject.SetActive(false);
        }
    }

    public void EnablePlayerMovement(bool p)
    {
        this.enabled = p;
    }

}