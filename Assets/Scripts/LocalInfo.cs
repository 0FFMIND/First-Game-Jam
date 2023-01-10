using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalInfo : MonoBehaviour
{
    public const string Waiting = "Waiting for other players...";
    public const string Matching = "Match found!";
    public const string Clicking = "Mouse Clicked!";
    private Text controlText;
    private void Start()
    {
        controlText = GetComponent<Text>();
        controlText.text = Waiting;
    }
    public void SetText(string text)
    {
        controlText.text = text;
    }
    public bool IsJoined()
    {
        return controlText.text == Matching;
    }
}
