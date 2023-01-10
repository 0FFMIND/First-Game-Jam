using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public int index;
    private bool keyDown;
    [SerializeField] int maxIndex;
    public AudioSource audioSource;
    public bool disableOnce = false;
    public JoyStick joyStickIn;
    private void Start()
    {
        joyStickIn = GameObject.FindWithTag("joyStick").GetComponent<JoyStick>();
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") != 0 || joyStickIn.posIn.y != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0 || joyStickIn.posIn.y < -0.01f)
                {
                    if (index < maxIndex)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if (Input.GetAxis("Vertical") > 0 || joyStickIn.posIn.y > 0.01f)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = maxIndex;
                    }
                }
                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }
    }
}
