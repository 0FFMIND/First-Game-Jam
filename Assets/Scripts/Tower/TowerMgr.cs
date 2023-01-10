using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TowerMgr : MonoBehaviour
{
    public Text textEnemyKilled;
    public int enemyKilled = 0;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "TowerScene")
        {
            if (MineObj.Instance.GetDefence())
            {
                GameObject.FindWithTag("lowTower").SetActive(false);
                GameObject.FindWithTag("highTower").SetActive(true);
            }
            else if (!MineObj.Instance.GetDefence())
            {
                GameObject.FindWithTag("lowTower").SetActive(true);
                GameObject.FindWithTag("highTower").SetActive(false);
            }
            if (MineObj.Instance.GetStrength())
            {
                GameObject.FindWithTag("highGun").SetActive(true);
                GameObject.FindWithTag("lowGun").SetActive(false);
            }else if (!MineObj.Instance.GetStrength())
            {
                GameObject.FindWithTag("lowGun").SetActive(true);
                GameObject.FindWithTag("highGun").SetActive(false);
            }
        }
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
            textEnemyKilled.text = "KILLED:" + enemyKilled.ToString();
        }
        else if (Language.Instance.nowOption == LanguageOption.Chinese)
        {
            textEnemyKilled.text = "»÷É±ÊýÁ¿£º" + enemyKilled.ToString();
        }
    }
}
