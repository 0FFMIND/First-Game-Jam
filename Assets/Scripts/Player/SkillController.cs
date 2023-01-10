using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    //item在该下面获取
    [SerializeField] public Image dashImage;
    [SerializeField] public Image invisibleImage;
    private PMovement pMovement;
    private void Start()
    {
        pMovement = GameObject.FindWithTag("player").GetComponent<PMovement>();
    }
    private void Update()
    {
        var player = GameObject.FindWithTag("player");
        SkillPressed(dashImage, pMovement.GetCooldownPercentage());
    }
    private void SkillPressed(Image skillImage, float percentage)
    {
        skillImage.fillAmount = percentage;
    }
}
