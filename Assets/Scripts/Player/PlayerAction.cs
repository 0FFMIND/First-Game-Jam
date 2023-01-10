using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    protected const int MAX_HEALTH = 5;
    protected int health = 5;
    protected bool isActive = true;
    //ÑªÁ¿Ìõ
    [SerializeField] private GameObject healthBarParent;
    [SerializeField] private GameObject healthBarSlider;
    //ÊÜ»÷
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration = 0.1f;
    private void Start()
    {
        health = MAX_HEALTH;
    }
}
