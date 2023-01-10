using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public enum LanguageOption
{
    English,
    Chinese,
};
public class Language : UnitySingleton<Language>
{
    public LanguageOption nowOption;
    public Text text;
    Dictionary<string, string> nowDict = new Dictionary<string, string>();
    public bool changeSignal = false;
    string mobileWord = "-ugpIsMobile";
    public bool isMobile = true;
    private string test;
    //获取命令行参数
    private string GetCmdLine()
    {
        string openCmdStr = "";
        string[] CommandLines = Environment.GetCommandLineArgs();
        openCmdStr = CommandLines.Aggregate<string, string>("CommandLineArgs : ", (a, b) => a + " , " + b);
        return openCmdStr;
    }
    private bool CheckIsMobile()
    {
        string openCmdStr = GetCmdLine();
        if (openCmdStr != "")
        {
            return openCmdStr.Contains(mobileWord);
        }
        return true;
    }
    protected override void Awake()
    {
        base.Awake();
        isMobile = CheckIsMobile();
        LoadLanguage(LanguageOption.English);
        nowOption = LanguageOption.English;
    }
    private void Start()
    {
    }
    public void ChangeLanguage(LanguageOption languageOption)
    {
        Debug.Log(languageOption);
        LoadLanguage(languageOption);
    }
    private void LoadLanguage(LanguageOption languageOption)
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        string path= "";
        if (languageOption == LanguageOption.English)
            path = "English";
        if (languageOption == LanguageOption.Chinese)
            path = "Chinese";
        TextAsset targetAsset = Resources.Load<TextAsset>(path);
        string[] lines = targetAsset.text.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrEmpty(lines[i]))
            {
                continue;
            }
            else
            {
                string[] nowLines = lines[i].Split(':');
                dict.Add(nowLines[0], nowLines[1]);
            }
        }
        nowDict = dict;
        changeSignal = true;
        if (languageOption == LanguageOption.English)
            Invoke("SetFalseEn", 0.1f);
        if (languageOption == LanguageOption.Chinese)
            Invoke("SetFalseCn", 0.1f);
    }
    public void SetFalseEn()
    {
        changeSignal = false;
        nowOption = LanguageOption.English;
    }
    public void SetFalseCn()
    {
        changeSignal = false;
        nowOption = LanguageOption.Chinese;
    }
    public string GetTest(string key)
    {
        if (nowDict.ContainsKey(key))
        {
            return nowDict[key];
        }
        else
        {
            return null;
        }
    }
}
