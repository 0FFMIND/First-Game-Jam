using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackOneInfo : MonoBehaviour
{
    public Text firstText;
    public Text secondText;
    private void Start()
    {
        if(Language.Instance.nowOption == LanguageOption.English)
        {
            firstText.text = "THIS SCENE DISPLAYS THE BACKGROUND STORY OF THE WHOLE STROY";
            secondText.text = "该画面仅播放一次 DISPLAYED ONLY ONCE";
        }else if(Language.Instance.nowOption == LanguageOption.Chinese)
        {
            firstText.text = "这是故事的背景知识介绍";
            secondText.text = "该画面仅播放一次 DISPLAYED ONLY ONCE";
        }
        
    }
}
