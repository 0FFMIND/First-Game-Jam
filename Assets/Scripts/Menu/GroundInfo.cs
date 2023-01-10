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
            nowTest.text = "��������E����̣��뾡���ܶ���ռ���ʯE����̣��뾡���ܶ���ռ���ʯ";
        }
    }
}
