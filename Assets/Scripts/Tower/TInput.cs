using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TInput : MonoBehaviour
{
    public Vector3 aimPointVector { get; private set; }
    public Action OnShootEvent { get; set; }
    private CursorFollow cursorFollow;
    private void Start()
    {
        cursorFollow = GameObject.FindWithTag("cursorFollow").GetComponent<CursorFollow>();
    }
    private void Update()
    {
        GetAimPoint();
        GetShootInput();
    }
    private void GetShootInput()
    {
        if (Input.GetMouseButtonDown(0) || cursorFollow.touchCount > 0)
        {
            OnShootEvent();
        }
    }
    private void GetAimPoint()
    {
        Vector3 pos = cursorFollow.transform.position;
        pos.z = 0f;
        aimPointVector = pos;
    }
}
