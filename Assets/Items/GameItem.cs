using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    [SerializeField]
    private ItemStack _stack;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private void SetupGameObject()
    {
        if (_stack.Item == null) return;
    }
}
