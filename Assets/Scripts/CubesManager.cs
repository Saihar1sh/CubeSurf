using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesManager : MonoSingletonGeneric<CubesManager>
{
    //Variables
    [SerializeField]
    private float mvtSpeed = 5f;

    [SerializeField]
    private Transform spawnLocation;

    private bool magnetPicked = false, boostPicked = false, gameOver = false;

    private int length;

    //Script ref
    [SerializeField]
    private CubeController playerCubePrefab;
    private CubeController top;
    [SerializeField]
    private Player player;
    [SerializeField]
    private InputManager inputManager;

    //Lists
    public List<CubeController> cubes;
    public List<Rigidbody> cubeRbs;

    void Start()
    {
        top = cubes[0];
    }

    void Update()
    {
        if (cubes.Count == 0)
        {
            foreach (Rigidbody rb in cubeRbs)
            {
                rb.velocity = Vector3.zero;
            }
            return;
        }
        Movement();
    }

    public void AddCubes()
    {
        Vector3 lastTopPos = player.transform.position;                 //moving player up like a jump then instantiating new cube in player's last position
        player.transform.position += Vector3.up * 3;
        CubeController cube = Instantiate<CubeController>(playerCubePrefab, lastTopPos, top.transform.rotation, spawnLocation);
        cubes.Add(cube);
        top = cube;

    }

    private void Movement()
    {
        foreach (Rigidbody cubeRb in cubeRbs)
        {
            Vector3 desiredPos = new Vector3(inputManager.SwipeDelta.normalized.x, 0, 1f);
            cubeRb.MovePosition(cubeRb.position + desiredPos * mvtSpeed * Time.deltaTime);
        }

    }

    public void MagnetPowerPickup(BoxCollider magnetPowerCollider, float secs)
    {
        if (!magnetPicked)
        {
            StartCoroutine(MagnetPickup(magnetPowerCollider, secs));
            magnetPicked = true;
        }
    }
    public void BoostPowerPickup()
    {
        if (!boostPicked)
        {
            StartCoroutine(BoostPickup());
            boostPicked = true;
        }
    }
    IEnumerator MagnetPickup(BoxCollider magnetPowerCollider, float secs)
    {
        magnetPowerCollider.enabled = true;
        yield return new WaitForSeconds(secs);
        magnetPowerCollider.enabled = false;
        magnetPicked = false;
    }
    IEnumerator BoostPickup()
    {
        float speed = mvtSpeed;
        mvtSpeed = mvtSpeed * 3f;
        yield return new WaitForSeconds(5f);
        mvtSpeed = speed;
        boostPicked = false;
    }

}
