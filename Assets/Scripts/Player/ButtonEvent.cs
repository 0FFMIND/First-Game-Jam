using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{

    public void OnPressed()
    {
        if (MineObj.Instance.GetDefence())
        {
            GameObject.FindWithTag("highTower").GetComponent<TMgr>().SetE();
        }else if (!MineObj.Instance.GetDefence())
        {
            GameObject.FindWithTag("lowTower").GetComponent<TMgr>().SetE();
        }
    }
    public void OnDashPressed()
    {
        var player = GameObject.FindWithTag("player");
        if(player != null)
        {
            player.GetComponent<PMovement>().SetDash();
        }
    }
}
