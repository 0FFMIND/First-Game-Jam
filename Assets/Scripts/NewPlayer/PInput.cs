using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PInput : MonoBehaviour, IPlayerInput
{
    public Vector2 movementInputVector { get; private set; }
    public Vector3 aimPointVector { get; private set; }
    public Action OnShootEvent { get; set; }
    public Action OnRollEvent { get; set; }
    public Action TimeOutEvent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    private CursorFollow cursorFollow;

    private JoyStick joyStickIn;
    private void Start()
    {
        cursorFollow = GameObject.FindWithTag("cursorFollow").GetComponent<CursorFollow>();
        joyStickIn = GameObject.FindWithTag("joyStick").GetComponent<JoyStick>();
    }
    private void Update()
    {
        GetAimPoint();
        GetMovementInput();
        GetShootInput();
    }
    private void GetShootInput()
    {
        if(Input.GetMouseButtonDown(0) || cursorFollow.touchCount > 0)
        {
            OnShootEvent();
        }
    }
    public void GetRollInput()
    {
        if (Input.GetKeyDown(""))
        {

        }
    }
    private void GetAimPoint()
    {
        Vector3 pos = cursorFollow.transform.position;
        pos.z = 0f;
        aimPointVector = pos;
    }
    private void GetMovementInput()
    {
        float x = 0f;float y = 0f;
        if (joyStickIn.posIn.x != 0)
            x = joyStickIn.posIn.x;
        else
            x = Input.GetAxisRaw("Horizontal");
        if (joyStickIn.posIn.y != 0)
            y = joyStickIn.posIn.y;
        else
            y = Input.GetAxisRaw("Vertical");
        movementInputVector = new Vector2(x,y);
    }
}
