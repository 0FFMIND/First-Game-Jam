using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadWord : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.GetComponent<Text>().text = Language.Instance.GetTest(this.gameObject.name);
    }
    private void Update()
    {
        if (Language.Instance.changeSignal)
        {
            this.gameObject.GetComponent<Text>().text = Language.Instance.GetTest(this.gameObject.name);
        }
    }
}
