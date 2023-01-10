using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAimWeapon : MonoBehaviour
{
    public string defaultWeapon = "Gun";
    private GameObject aim;
    private Transform aimTransform;
    private Transform gunTransform;
    private PMovement pMovement;
    private void Awake()
    {
        aim = GameObject.FindWithTag("aim");
        aimTransform = aim.transform;
        if (MineObj.Instance.GetTwoS())
        {
            gunTransform = GameObject.FindWithTag("nbGun").GetComponent<Transform>();
            GameObject.FindWithTag("nbGun").SetActive(true);
            GameObject.FindWithTag("cyberGun").SetActive(false);
        }
        else if (!MineObj.Instance.GetTwoS())
        {
            gunTransform = GameObject.FindWithTag("cyberGun").GetComponent<Transform>();
            GameObject.FindWithTag("nbGun").SetActive(false);
            GameObject.FindWithTag("cyberGun").SetActive(true);
        }
        pMovement = GameObject.FindWithTag("player").GetComponent<PMovement>();
    }
    public void HandleShoot(PMovement.State state)
    {
        if (state == PMovement.State.Roll) return;
        if (state == PMovement.State.Normal) aim.GetComponentInChildren<IGun>()?.Shoot();
    }
    public void PlayerAim(Vector3 aimPoint)
    {
        Vector3 aimDir = (aimPoint - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Vector3 scale = gunTransform.localScale;
        if((angle > 90 || angle < -90) && pMovement.isRight)
        {
            //ÏòÓÒ
            scale.y = -1;
            gunTransform.localScale = scale;
            
        }
        else if((angle < 90 && angle > -90) && pMovement.isRight)
        {
            //Ïò×ó
            scale.y = 1;
            gunTransform.localScale = scale;
        }
    }
}
