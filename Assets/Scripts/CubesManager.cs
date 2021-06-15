﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesManager : MonoSingletonGeneric<CubesManager>
{
    //Variables
    [SerializeField]
    private float mvtSpeed = 5f, groundCheckDist = 1f;

    [SerializeField]
    private Transform spawnLocation, groundCheck;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool magnetPicked = false, boostPicked = false, gameOver = true, isGrounded = false, playerDisabled = false;

    //Scripts ref
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
        EnableMovement(false);
    }

    void Update()
    {
        isGrounded = Physics.Raycast(groundCheck.position, -transform.up, groundCheckDist, whatIsGround);

        if (isGrounded || cubes.Count == 0)
        {
            EnableMovement(false);
            UIManager.Instance.RetryImageEnable(true);
            return;
        }
        Movement();
    }

    public void EnableMovement(bool boolean)
    {
        foreach (CubeController cube in cubes)
        {
            cube.enabled = boolean;
        }
        if (!playerDisabled)
            StartCoroutine(MovementEnable(boolean));
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

        Vector3 pos = top.transform.position;
        float xpos = pos.x;
        float zpos = pos.z;
        player.transform.position = new Vector3(xpos, player.transform.position.y, zpos);
        foreach (CubeController cube in cubes)                                              //maintaining them as one stack of cubes while moving
        {
            cube.transform.position = new Vector3(xpos, cube.transform.position.y, zpos);
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

    //coroutines
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

    IEnumerator MovementEnable(bool b)
    {
        playerDisabled = true;
        yield return new WaitForSeconds(2f);
        player.EnablePlayerMovement(b);
        playerDisabled = false;
    }

    //gizmos
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDist, groundCheck.position.z));
    }
}
