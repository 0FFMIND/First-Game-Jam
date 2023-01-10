using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeMgr : MonoBehaviour
{
    public Text timeDisplayed;
    public float restTime;
    public float elapsedTime = 0f;
    private TimeSpan timePlaying;
    private void Start()
    {
        restTime = 30f;
    }
    private void FixedUpdate()
    {
        if (restTime > 0f)
        {
            MineObj.Instance.GetMineNum();
            elapsedTime = Time.fixedDeltaTime;
            restTime -= elapsedTime;
            timePlaying = TimeSpan.FromSeconds(restTime);
            timeDisplayed.text = "ʣ�ࣺ" + timePlaying.ToString("mm':'ss'.'ff");
        }
        else
        {
            Fader.Instance.isDefeated = false;
            MineObj.Instance.AddMine();
            Fader.Instance.ChangeScene("BackTwo");
        }
    }
}
