using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TwoShop : MonoBehaviour
{
    public Text textPanel;
    public AudioSource clickSource;
    public AudioSource typingSource;
    public float speed = 0.05f;
    public GameObject areYouSure;
    private bool isFinished = true;
    private bool cancelTyping = false;
    private bool Turn = false;
    private JoyStick joyStickIn;
    List<GameObject> child;
    private void Start()
    {
        joyStickIn = GameObject.FindWithTag("joyStick").GetComponent<JoyStick>();
        child = new List<GameObject>();
    }
    public void ShowStrength()
    {
        clickSource.Play();
        if (Language.Instance.nowOption == LanguageOption.Chinese)
        {
            StartCoroutine(SetTextUI("需要两颗矿石，购买后会强化你手上的武器并更改武器外观"));
        }
        else if (Language.Instance.nowOption == LanguageOption.English)
        {
            StartCoroutine(SetTextUI("REQUIRE TWO MIERALS, AND STRENGTHEN YOUR TOWER'S WEAPON"));
        }
    }
    public void ShowDefence()
    {
        clickSource.Play();
        if (Language.Instance.nowOption == LanguageOption.Chinese)
        {
            StartCoroutine(SetTextUI("需要三颗矿石，购买后会强化你的防御并提高人物血量值"));
        }
        else if (Language.Instance.nowOption == LanguageOption.English)
        {
            StartCoroutine(SetTextUI("REQUIRE THREE MIERALS, AND STRENGTHEN YOUR DEFENCE"));
        }
    }
    public void ShowShoot()
    {
        clickSource.Play();
        if (Language.Instance.nowOption == LanguageOption.Chinese)
        {
            StartCoroutine(SetTextUI("需要一颗矿石，购买后会加快你高塔武器的攻击速度"));
        }
        else if (Language.Instance.nowOption == LanguageOption.English)
        {
            StartCoroutine(SetTextUI("REQUIRE ONE MIERALS, AND SPEED UP WEAPONTIME OF YOUR TOWER WEAPON"));
        }
    }
    public void BuyStrength()
    {
        clickSource.Play();
        if (!MineObj.Instance.GetStrength())
        {
            if (MineObj.Instance.GetMineNum() - 2 >= 0)
            {
                MineObj.Instance.DecreaseMine(2);
                MineObj.Instance.SetTwoS();
                if (Language.Instance.nowOption == LanguageOption.Chinese)
                {
                    StartCoroutine(SetTextUI("感谢你购买单次增强武器的商品！"));
                }
                else if (Language.Instance.nowOption == LanguageOption.English)
                {
                    StartCoroutine(SetTextUI("THANKS FOR PURCHASING A SINGLE ENHANCEMENT ON YOUR WEAPON !"));
                }
            }
            else if (MineObj.Instance.GetMineNum() < 2)
            {
                if (Language.Instance.nowOption == LanguageOption.Chinese)
                {
                    StartCoroutine(SetTextUI("很抱歉你当前矿石的数目不足以购买当前商品"));
                }
                else if (Language.Instance.nowOption == LanguageOption.English)
                {
                    StartCoroutine(SetTextUI("WE ARE SORRY THAT YOUR MINERALS ARE NOT ENOUGHT TO PURCHASE CURRENT ITEM"));
                }
            }
        }
        else if (MineObj.Instance.GetStrength())
        {
            if (Language.Instance.nowOption == LanguageOption.Chinese)
            {
                StartCoroutine(SetTextUI("你已经购买过当前商品了，请勿重复购买"));
            }
            else if (Language.Instance.nowOption == LanguageOption.English)
            {
                StartCoroutine(SetTextUI("YOU HAVE ALREADY PURCHASED THE CURRENT ITEM"));
            }
        }
    }
    public void BuyDefence()
    {
        clickSource.Play();
        if (!MineObj.Instance.GetDefence())
        {
            if (MineObj.Instance.GetMineNum() - 3 >= 0)
            {
                MineObj.Instance.DecreaseMine(3);
                MineObj.Instance.SetTwoD();
                if (Language.Instance.nowOption == LanguageOption.Chinese)
                {
                    StartCoroutine(SetTextUI("感谢你购买单次增强防御的商品！"));
                }
                else if (Language.Instance.nowOption == LanguageOption.English)
                {
                    StartCoroutine(SetTextUI("THANKS FOR PURCHASING A SINGLE ENHANCEMENT ON YOUR DEFENCE !"));
                }
            }
            else if (MineObj.Instance.GetMineNum() < 3)
            {
                if (Language.Instance.nowOption == LanguageOption.Chinese)
                {
                    StartCoroutine(SetTextUI("很抱歉你当前矿石的数目不足以购买当前商品"));
                }
                else if (Language.Instance.nowOption == LanguageOption.English)
                {
                    StartCoroutine(SetTextUI("WE ARE SORRY THAT YOUR MINERALS ARE NOT ENOUGHT TO PURCHASE CURRENT ITEM"));
                }
            }
        }
        else if (MineObj.Instance.GetDefence())
        {
            if (Language.Instance.nowOption == LanguageOption.Chinese)
            {
                StartCoroutine(SetTextUI("你已经购买过当前商品了，请勿重复购买"));
            }
            else if (Language.Instance.nowOption == LanguageOption.English)
            {
                StartCoroutine(SetTextUI("YOU HAVE ALREADY PURCHASED THE CURRENT ITEM"));
            }
        }
    }
    private void Update()
    {
        if (joyStickIn.posIn.x > 0.01f && cancelTyping)
        {
            Turn = true;
        }
        else
        {
            Turn = false;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Turn)
        {
            if (!isFinished)
            {
                cancelTyping = !cancelTyping;
            }
        }
    }
    public void BuyShoot()
    {
        clickSource.Play();
        if (!MineObj.Instance.GetShoot())
        {
            if (MineObj.Instance.GetMineNum() - 1 >= 0)
            {
                MineObj.Instance.DecreaseMine(1);
                MineObj.Instance.SetTwoQ();
                if (Language.Instance.nowOption == LanguageOption.Chinese)
                {
                    StartCoroutine(SetTextUI("感谢你购买单次增强武器射速的商品！"));
                }
                else if (Language.Instance.nowOption == LanguageOption.English)
                {
                    StartCoroutine(SetTextUI("THANKS FOR PURCHASING A SINGLE ENHANCEMENT ON YOUR TOWER WEAPONTIME !"));
                }
            }
            else if (MineObj.Instance.GetMineNum() < 1)
            {
                if (Language.Instance.nowOption == LanguageOption.Chinese)
                {
                    StartCoroutine(SetTextUI("很抱歉你当前矿石的数目不足以购买当前商品"));
                }
                else if (Language.Instance.nowOption == LanguageOption.English)
                {
                    StartCoroutine(SetTextUI("WE ARE SORRY THAT YOUR MINERALS ARE NOT ENOUGHT TO PURCHASE CURRENT ITEM"));
                }
            }
        }
        else if (MineObj.Instance.GetShoot())
        {
            if (Language.Instance.nowOption == LanguageOption.Chinese)
            {
                StartCoroutine(SetTextUI("你已经购买过当前商品了，请勿重复购买"));
            }
            else if (Language.Instance.nowOption == LanguageOption.English)
            {
                StartCoroutine(SetTextUI("YOU HAVE ALREADY PURCHASED THE CURRENT ITEM"));
            }
        }
    }
    public void GoTower()
    {
        for (int i = 0; i < 7; i++)
        {
            child.Add(this.transform.GetChild(i).gameObject);
        }
        foreach (var chil in child)
        {
            chil.SetActive(false);
        }
        areYouSure.SetActive(true);
        if (Language.Instance.nowOption == LanguageOption.Chinese)
        {
            StartCoroutine(SetTextUI("是否你已经确认你的购买了，并回到矿藏？"));
        }
        else if (Language.Instance.nowOption == LanguageOption.English)
        {
            StartCoroutine(SetTextUI("HAVE YOU CONFIRMED YOUR PURCHASE AND HEAD TO MINE?"));
        }
    }
    public void Yes()
    {
        Fader.Instance.ChangeScene("GroundScene");
    }
    public void No()
    {
        foreach (var chil in child)
        {
            chil.SetActive(true);
        }
        child.Clear();
        areYouSure.SetActive(false);
    }
    private IEnumerator SetTextUI(string textList)
    {
        if (isFinished)
        {
            isFinished = false;
            textPanel.text = "";
            int i = 0;
            while (i < textList.Length && !cancelTyping)
            {
                textPanel.text += textList[i];
                i++;
                typingSource.Play();
                yield return new WaitForSeconds(speed);
            }
            cancelTyping = false;
            textPanel.text = textList;
            isFinished = true;
        }
    }
}
