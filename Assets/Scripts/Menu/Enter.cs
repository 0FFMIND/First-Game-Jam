using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enter : MonoBehaviour
{
    public GameObject info;
    public GameObject enter;
    public bool isPressed = false;
    public bool once = false;
    public bool isEnter = false;
    private void Awake()
    {
        if (Language.Instance.isMobile)
        {
            info.SetActive(false);
            enter.SetActive(true);
        }
    }
    public void Update()
    {
        if(isPressed == true && once)
        {
            isEnter = true;
            once = false;
        }
        else
        {
            isEnter = false;
            once = false;
        }
    }
    public bool nowEnter()
    {
        return isEnter;
    }
    public void OnPressed()
    {
        isPressed = true;
        once = true;
    }
}
