using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;


    [SerializeField]
    private Transform playerMain;

    [SerializeField]
    private InputManager inputManager;


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
        //Movement();
    }

}