using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : CharacterBaseState
{
    private PlayerMovement playerMoveSystem;
    public override void EnterState(Player player)
    {
        player.SetAnimation("Jump");

        playerMoveSystem = player.PlayerMovementSystem;
    }

    public override void Update(Player player)
    {
        if (playerMoveSystem.IsGrounded()) player.TransitionToState(player.idleState);
        else if (PlayerTryMove()) MoveInAir();
    }

    private bool PlayerTryMove()
    {
        Debug.Log("Try move");
        return playerMoveSystem.TryMovePlayer();
    }

    private void MoveInAir()
    {
        Debug.Log(" move");
        playerMoveSystem.MovePlayer();
    }
}
