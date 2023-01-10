using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TowerTimeMgr : MonoBehaviour
{
    public Text timeDisplayed;
    public float sTime;
    public float elapsedTime = 0f;
    private TimeSpan timePlaying;
    private void Start()
    {
        sTime = 0;
    }
    private void FixedUpdate()
    {
        elapsedTime = Time.fixedDeltaTime;
        sTime += elapsedTime;
        timePlaying = TimeSpan.FromSeconds(sTime);
        timeDisplayed.text = "´æ»î£º" + timePlaying.ToString("mm':'ss'.'ff");

    }
}
