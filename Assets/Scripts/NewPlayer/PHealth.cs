using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHealth : MonoBehaviour
{
    public Transform HealthBar;
    private Vector3 originHealth;
    private void Start()
    {
        HealthBar = GameObject.FindWithTag("healthBar").GetComponent<Transform>();
        originHealth = new Vector3(0.8167199f, -0.07668506f, 1f);
        if (MineObj.Instance.GetTwoD())
        {
            originHealth.x = originHealth.x * 2;
            HealthBar.localScale = new Vector3(originHealth.x,
    HealthBar.localScale.y, HealthBar.localScale.z);
        }
    }
    public void SetMaxHealth()
    {
    }
    public void SetHealthBar(float percentage,float max)
    {
        percentage = percentage / max;
        HealthBar.localScale = new Vector3(originHealth.x * percentage,
            HealthBar.localScale.y, HealthBar.localScale.z);
    }
}
