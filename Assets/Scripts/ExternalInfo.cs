using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExternalInfo : MonoBehaviour
{
    private Text connectInfo;
    private void Start()
    {
        connectInfo = GetComponent<Text>();
    }
    public void SetText(string text)
    {
        connectInfo.text = text;
    }
}
