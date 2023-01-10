using System;
using UnityEngine;

public interface IPlayerInput
{
    Vector2 movementInputVector { get;}
    Vector3 aimPointVector { get; }
    Action OnShootEvent { get; set; }
    Action TimeOutEvent { get; set; }
}
