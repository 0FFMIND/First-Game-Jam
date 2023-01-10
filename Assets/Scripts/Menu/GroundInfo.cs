using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundInfo : MonoBehaviour
{
    public Text nowTest;
    private void Start()
    {
        if(Language.Instance.nowOption == LanguageOption.English)
        {
            nowTest.text = "SELECT MINERALS AS MUCH AS YOU CAN";
        }else if(Language.Instance.nowOption == LanguageOption.Chinese)
        {
            nowTest.text = "点击射击，E键冲刺，请尽可能多的收集矿石E键冲刺，请尽可能多的收集矿石";
        }
    }
}
