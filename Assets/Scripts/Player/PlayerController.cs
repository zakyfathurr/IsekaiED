using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    public CharacterScriptableObject characterData;
    public Vector2 moveDir;
    public Vector2 lastMovedVector;
    public int[] GetPlayerPositions()
    {
        return new int[] { (int)transform.position.x, (int)transform.position.y };
    }


    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2 (1, 0f);
    }

    private void OnEnable()
    {
        playerControls.Enable();   
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        moveDir = movement.normalized;


        if (moveDir.x != 0)
        {
            lastMovedVector = new Vector2(moveDir.x, 0f);
        }

        if (moveDir.y != 0)
        {
            lastMovedVector = new Vector2(moveDir.y, 0f); 
        }

        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(moveDir.x, moveDir.y);
        }

    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (characterData.MoveSpeed * Time.deltaTime)); 
    }

}
