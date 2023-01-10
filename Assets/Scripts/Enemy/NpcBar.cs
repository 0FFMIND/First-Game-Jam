using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcBar : MonoBehaviour
{
    public Transform npcBar;
    public List<GameObject> child;
    public Color low;
    public Color high;
    public Vector3 offset;
    public Vector3 originHealth;
    private void Start()
    {
        npcBar = this.transform.GetChild(0).gameObject.GetComponent<Transform>();
        for (int i = 0; i < 2; i++)
        {
            child.Add(this.transform.GetChild(i).gameObject);
        }
        foreach (var chil in child)
        {
            chil.SetActive(false);
        }
    }
    public void DisableAll()
    {
        foreach (var chil in child)
        {
            chil.SetActive(false);
        }
    }
    public void SetHealth(float health, float maxHealth)
    {
        if(health < maxHealth)
        {
            foreach (var chil in child)
            {
                chil.SetActive(true);
            }
        }
        npcBar = this.transform.GetChild(0).gameObject.GetComponent<Transform>();
        float percentage = health / maxHealth;
        npcBar.localScale = new Vector3(npcBar.localScale.x * percentage, npcBar.localScale.y, npcBar.localScale.z);
        npcBar.GetComponent<SpriteRenderer>().color = Color.Lerp(low, high, percentage);
    }
    private void Update()
    {
        this.transform.position = transform.parent.position + offset;
    }
}
