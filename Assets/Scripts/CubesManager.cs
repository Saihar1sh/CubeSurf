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

    private bool started = true, gameOver = false;

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
            gameOver = true;
            return;
        }
        Movement();
    }

    public void AddCubes()
    {
        Vector3 lastTopPos = player.transform.position;
        CubeController cube = Instantiate<CubeController>(playerCubePrefab, lastTopPos, top.transform.rotation, spawnLocation);
        player.transform.position += Vector3.up * 3;
        cubes.Add(cube);
        top = cube;

    }

    private void Movement()
    {
        foreach (Rigidbody cubeRb in cubeRbs)
        {
            Vector3 desiredPos = new Vector3(inputManager.SwipeDelta.normalized.x, 0, 1f);
            cubeRb.MovePosition(cubeRb.position + desiredPos * mvtSpeed * Time.deltaTime);
            /*            Vector3 playerPos = playerMain.transform.position;
                        playerPos.x += inputManager.SwipeDelta.normalized.x * mvtSpeed * Time.deltaTime;
                        playerMain.transform.position = playerPos;
            */
        }

    }

}
