
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public Text textEnemyKilled;
    public Text textMineCollected;
    public int mineCollected = 0;
    public int enemyKilled = 0;
    private void Start()
    {
        UpdateText();
    }
    public void AddMine()
    {
        mineCollected++;
        UpdateText();
    }
    public void AddEnemyDead()
    {
        enemyKilled++;
        UpdateText();
    }
    public void UpdateText()
    {
        if (Language.Instance.nowOption == LanguageOption.English)
        {
            textEnemyKilled.text = "KILLED:"+ enemyKilled.ToString();
            textMineCollected.text = "MINERALS:"+ mineCollected.ToString();
        }
        else if (Language.Instance.nowOption == LanguageOption.Chinese)
        {
            textEnemyKilled.text = "击杀数量："+ enemyKilled.ToString();
            textMineCollected.text = "矿石收集："+ mineCollected.ToString();
        }
    }
}
