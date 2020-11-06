using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : CharacterBaseState
{
    private PlayerMovement playerMoveSystem;
    public override void EnterState(Player player)
    {
        player.SetAnimation("Idle");

        playerMoveSystem = player.PlayerMovementSystem;
    }

    public override void Update(Player player)
    {
        if (playerMoveSystem.TryMovePlayer()) player.TransitionToState(player.moveState);

        if (Input.GetKeyDown(KeyCode.Space)) JumpPlayer(player);
    }

    private void JumpPlayer(Player player)
    {
        playerMoveSystem.JumpPlayer();

        player.TransitionToState(player.jumpState);
    }
}
