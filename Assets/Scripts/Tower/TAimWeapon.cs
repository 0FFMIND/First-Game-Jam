using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAimWeapon : MonoBehaviour
{
    public GameObject aim;
    public Transform aimTransform;
    private Transform gunTransform;
    private void Start()
    {
        if (MineObj.Instance.GetStrength())
        {
            if (MineObj.Instance.GetDefence())
            {
                aim = GameObject.FindWithTag("HighButHigh");
            }
            else if (!MineObj.Instance.GetDefence())
            {
                aim = GameObject.FindWithTag("LowButHigh");
            }
        }
        else if (!MineObj.Instance.GetStrength())
        {
            if (MineObj.Instance.GetDefence())
            {
                aim = GameObject.FindWithTag("HighButLow");
            }
            else if (!MineObj.Instance.GetDefence())
            {
                aim = GameObject.FindWithTag("LowButLow");
            }
        }
        aimTransform = aim.transform;
        if (MineObj.Instance.GetStrength())
        {
            gunTransform = GameObject.FindWithTag("FireP").GetComponent<Transform>();
        } else if (!MineObj.Instance.GetStrength())
        {
            gunTransform = GameObject.FindWithTag("FireP").GetComponent<Transform>();
        }
    }
    public void HandleShoot(TMgr.State state)
    {
        if (state == TMgr.State.Death) return;
        if (state == TMgr.State.Normal) {
            if (MineObj.isStrength)
            {
                GameObject.FindWithTag("highGun").GetComponent<Gun>().Shoot();
            }else if (!MineObj.isStrength)
            {
                GameObject.FindWithTag("lowGun").GetComponent<Gun>().Shoot();
            }
        }
    }
    public void PlayerAim(Vector3 aimPoint)
    {
        Vector3 aimDir = -(aimPoint- aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Vector3 scale = gunTransform.localScale;
        if (angle > 114f)
        {
            angle = 114f;
        }else if(angle < -114f)
        {
            angle = -114f;
        }
    }
}
