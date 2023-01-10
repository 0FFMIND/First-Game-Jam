using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    private Vector2 mousePos;
    public Vector3 defaultPos;
    public int touchCount;
    private void Awake()
    {
        defaultPos = this.transform.position;
    }
    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        touchCount = Input.touchCount;
        if(Language.Instance.isMobile)
        {
            for (int i = 0; i < touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                mousePos = Camera.main.ScreenToWorldPoint(touch.position);
            }
        }
        else if(!Language.Instance.isMobile)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        transform.position = mousePos;
    }
}
