using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THealth : MonoBehaviour
{
    public Transform HealthBar;
    private Vector3 originHealth;
    private void Start()
    {
        if (!MineObj.Instance.GetDefence())
        {
            HealthBar = GameObject.FindWithTag("healthBarLow").GetComponent<Transform>();
            originHealth = new Vector3(0.8295927f, -0.08952981f, 1f);
        }else if (MineObj.Instance.GetDefence())
        {
            HealthBar = GameObject.FindWithTag("healthBarHigh").GetComponent<Transform>();
            originHealth = new Vector3(0.8295927f, -0.08952981f, 1f);
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
