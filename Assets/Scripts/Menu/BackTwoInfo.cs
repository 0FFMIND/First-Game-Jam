using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackTwoInfo : MonoBehaviour
{
    public Text firstText;
    public Text secondText;
    private void Start()
    {
        if (!Language.Instance.isMobile)
        {
            if (Language.Instance.nowOption == LanguageOption.Chinese)
            {
                firstText.text = "你的矿石数量：";
                secondText.text = MineObj.Instance.GetMineNum().ToString();
            }
            else if (Language.Instance.nowOption == LanguageOption.English)
            {
                firstText.text = "MINERALS NUM:";
                secondText.text = MineObj.Instance.GetMineNum().ToString();
            }
        }else if (Language.Instance.isMobile)
        {
            if (Language.Instance.nowOption == LanguageOption.Chinese)
            {
                firstText.text = "你的矿石数量：" + MineObj.Instance.GetMineNum().ToString();
                secondText.text = "";
            }
            else if (Language.Instance.nowOption == LanguageOption.English)
            {
                firstText.text = "MINERALS NUM:" + MineObj.Instance.GetMineNum().ToString();
                secondText.text = "";
            }
        }
    }
    private void Update()
    {
        if (!Language.Instance.isMobile)
        {
            secondText.text = MineObj.Instance.GetMineNum().ToString();
        }else if (Language.Instance.isMobile)
        {
            if (Language.Instance.nowOption == LanguageOption.Chinese)
            {
                firstText.text = "你的矿石数量：" + MineObj.Instance.GetMineNum().ToString();
            }
            else if (Language.Instance.nowOption == LanguageOption.English)
            {
                firstText.text = "MINERALS NUM:" + MineObj.Instance.GetMineNum().ToString();
            }
        }
    }
}
