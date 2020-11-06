using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : CharacterBaseState
{
    private PlayerMovement playerMoveSystem;
    public override void EnterState(Player player)
    {
        player.SetAnimation("Move");

        playerMoveSystem = player.PlayerMovementSystem;
    }

    public override void Update(Player player)
    {
        if (PlayerTryMove()) MovePlayer();
        else player.TransitionToState(player.idleState);

        if (Input.GetKeyDown(KeyCode.Space)) JumpPlayer(player);
    }
    private bool PlayerTryMove( )
    {
        return playerMoveSystem.TryMovePlayer();
    }

    private void MovePlayer()
    {
        playerMoveSystem.MovePlayer();
    }

    private void JumpPlayer(Player player)
    {
        playerMoveSystem.JumpPlayer();

        player.TransitionToState(player.jumpState);
    }
}
