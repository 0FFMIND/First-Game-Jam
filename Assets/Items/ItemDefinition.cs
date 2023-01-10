using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/Item Definition",fileName = "New Item Definition")]
public class ItemDefinition : ScriptableObject
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private bool _isStackable;
    [SerializeField]
    private Sprite _inGameSprite;
    [SerializeField]
    private Sprite _uiSprite;
    //�����Է�װһ��
    public string Name => _name;
    public bool IsStackable => _isStackable;
    public Sprite InGameSprite => _inGameSprite;
    public Sprite UISprite => _uiSprite;
}
