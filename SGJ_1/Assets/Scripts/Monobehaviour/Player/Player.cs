using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerRotate)), RequireComponent(typeof(Animator)), RequireComponent(typeof(PlayerMovement)), RequireComponent(typeof(PlayerShoot))]
public class Player : MonoBehaviour, IAttackable
{
    

    public readonly PlayerMoveState moveState = new PlayerMoveState();
    public readonly PlayerJumpState jumpState = new PlayerJumpState();
    public readonly PlayerIdleState idleState = new PlayerIdleState();
    public readonly PlayerDeathState deathState = new PlayerDeathState();


    private CharacterBaseState currentState;
    private Animator playerAnimator;
    private CharacterController playerCharacterController;
    private PlayerMovement playerMoveSystem;

    public CharacterController PlayerCharacterController => playerCharacterController;
    public PlayerMovement PlayerMovementSystem => playerMoveSystem;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerCharacterController = GetComponent<CharacterController>();
        playerMoveSystem = GetComponent<PlayerMovement>();
    }


    void Start()
    {
        TransitionToState(idleState);                                        //при начале сразу переходим в состояние IdleState
    }


    void Update()
    {
        currentState.Update(this);
    }

    public void TransitionToState(CharacterBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void SetAnimation(string animationName)
    {
        Debug.Log(animationName);
    }

    public void GetDamage(float damage)
    {
        Debug.Log("GetDamage");
    }
}
