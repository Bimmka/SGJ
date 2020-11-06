using Cinemachine;
using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Скорость движения персонажа")]
    [SerializeField] private float moveSpeed = 1f;

    [Header("Сила прыжка")]
    [SerializeField] private float jumpForce = 1f;

    [Header("Камера игрока")]
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private CharacterController playerCharacterController;

    private float horizontal = 0f;
    private float vertical = 0f;
    private float gravityForce = 0f;

    private Vector3 direction = Vector3.zero;

    public static Action<Vector3> MoveVector;

    void Start()
    {
        playerCharacterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        Gravity();

        InputVerticalHorizontal();

        MovePlayerOnDirection();
    }

    private void Gravity()
    {
        SetGravityForce();

        SetMoveDirection();        
    }

    private void SetGravityForce()
    {
        if (!playerCharacterController.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1;
    }

    private void InputVerticalHorizontal()
    {
        vertical = Input.GetAxisRaw("Vertical") * moveSpeed;        
        horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    private void SetMoveDirection()
    {
        direction = transform.forward * vertical + transform.right * horizontal;
        direction.y = gravityForce;
    }

    private void MovePlayerOnDirection()
    {
        playerCharacterController.Move( direction * Time.deltaTime);
    }

    public bool IsGrounded()
    {
        return playerCharacterController.isGrounded;
    }

    public bool TryMovePlayer()
    {
        if (vertical == 0 && horizontal == 0) return false;
        else return true;
    }

    public void MovePlayer()
    {
        SetMoveDirection();
    }    

    public void JumpPlayer()
    {
        gravityForce = jumpForce;

        SetMoveDirection();

        MovePlayerOnDirection();
    }
}
