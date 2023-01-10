using System;
using UnityEngine;

[Serializable]
public class ItemStack
{
    [SerializeField]
    private ItemDefinition _item;
    [SerializeField]
    private int _numberOfItems;
    public bool IsStackable => _item.IsStackable;
    public ItemDefinition Item => _item;
    public int NumberOfItems
    {
        get => _numberOfItems;
        set
        {
            value = value < 0 ? 0 : value;
            _numberOfItems = _item != null && Item.IsStackable ? value : 1;
        }
    }
    public ItemStack(ItemDefinition item,int numberOfItems)
    {
        _item = item;
        _numberOfItems = numberOfItems;
    }
}
