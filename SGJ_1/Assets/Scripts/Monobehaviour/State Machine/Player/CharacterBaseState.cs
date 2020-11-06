using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseState 
{
    public abstract void EnterState(Player player);

    public abstract void Update(Player player);
}
