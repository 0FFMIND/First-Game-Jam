using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MineObj : UnitySingleton<MineObj>
{
    public static int mineNum;
    public static bool isStrength = false;
    public static bool isDefence = false;
    public static bool isQuickShoot = false;

    public static bool isTwoS = false;
    public static bool isTwoD = false;
    public static bool isTwoQ = false;
    public bool GetTwoS()
    {
        return isTwoS;
    }
    public bool GetTwoD()
    {
        return isTwoD;
    }
    public bool GetTwoQ()
    {
        return isTwoQ;
    }
    public void SetTwoS()
    {
        isTwoS = true;
    }
    public void SetTwoD()
    {
        isTwoD = true;
    }
    public void SetTwoQ()
    {
        isTwoQ = true;
    }
    protected override void Awake()
    {
        base.Awake();
    }
    public bool GetStrength()
    {
        return isStrength;
    }
    public bool GetDefence()
    {
        return isDefence;
    }
    public bool GetShoot()
    {
        return isQuickShoot;
    }
    public void SetStrength()
    {
        isStrength = true;
    }
    public void SetDefence()
    {
        isDefence = true;
    }
    public void SetShoot()
    {
        isQuickShoot = true;
    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject gameMgr = GameObject.FindWithTag("groundMgr");
        if (gameMgr != null && scene.name != "TowerScene")
        {
            mineNum = gameMgr.GetComponent<GameMgr>().mineCollected;
        }

        if(scene.name == "BackThree")
        {
            isStrength = false;
            isDefence = false;
            isQuickShoot = false;
            
        }
        if(scene.name == "TowerScene")
        {
            isTwoD = false;
            isTwoQ = false;
            isTwoS = false;
        }
    }
    public void AddMine(float num)
    {
        int a = (int)num;
        mineNum = mineNum + a;
    }
    public void DecreaseMine(int num)
    {
        mineNum = mineNum - num;
    }
    public int GetMineNum()
    {
        return mineNum;
    }
    public void StolenMine()
    {
        int nowMine = (int)( mineNum * 0.5f );
        float now = mineNum * 0.5f - nowMine;
        if(now > 0.1)
        {
            nowMine = nowMine + 1;
        }
        mineNum = nowMine;
    }
    public void AddMine()
    {
        mineNum = mineNum + 3;
    }
}
