using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class JoyStick : MonoBehaviour,IDragHandler, IPointerDownHandler,IPointerUpHandler
{
    private Image joyStickBackground;
    private Image joyStickButton;
    
    public Vector2 posIn;

    private void Start()
    {
        joyStickButton = transform.GetChild(0).GetComponent<Image>();
        joyStickBackground = transform.GetChild(1).GetComponent<Image>();
        if (Language.Instance.isMobile)
        {
            joyStickBackground.color = new Color(255f,255f, 255f, 255f);
            joyStickButton.color = new Color(255f, 255f, 255f, 255f);
        }
        else
        {
            joyStickBackground.gameObject.SetActive(false);
            joyStickButton.gameObject.SetActive(false);
        }
    }

    public void OnDrag(PointerEventData eventData)//实现接口
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joyStickBackground.rectTransform,eventData.position,eventData.pressEventCamera,out posIn))
        {
            //相除一次
            posIn.x /= joyStickBackground.rectTransform.sizeDelta.x;
            posIn.y /= joyStickBackground.rectTransform.sizeDelta.y;
            //控制大小
            if(posIn.magnitude > 1f)
            {
                posIn = posIn.normalized;
                Debug.Log(posIn);
            }
            //移动Transform
            joyStickButton.rectTransform.anchoredPosition = new Vector2(
                posIn.x * joyStickBackground.rectTransform.sizeDelta.x * 0.5f, posIn.y * joyStickBackground.rectTransform.sizeDelta.y * 0.5f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        posIn = Vector2.zero;
        joyStickButton.rectTransform.anchoredPosition = Vector2.zero;
    }
}
