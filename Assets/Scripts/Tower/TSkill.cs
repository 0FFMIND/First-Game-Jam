using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TSkill : MonoBehaviour
{
    public Image KillImage;
    public TMgr tMgr;
    private void Start()
    {
        if (MineObj.Instance.GetStrength())
        {
            tMgr = GameObject.FindWithTag("highTower").GetComponent<TMgr>();
        }else if (!MineObj.Instance.GetStrength())
        {
            tMgr = GameObject.FindWithTag("lowTower").GetComponent<TMgr>();
        }
    }
    private void Update()
    {
        SkillPressed(KillImage, tMgr.GetPercentage());
    }
    private void SkillPressed(Image skillImg, float percentage)
    {
        Debug.Log(percentage);
        KillImage.fillAmount = percentage;
    }
}
