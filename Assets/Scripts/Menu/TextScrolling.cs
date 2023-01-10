using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScrolling : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 StartPosition;
    private void Start()
    {
        StartPosition = new Vector3(1893f, -7.18f);
    }
    private void Update()
    {
        
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(GetComponent<RectTransform>().anchoredPosition.x < -1484.0f)
        {
            GetComponent<RectTransform>().anchoredPosition3D = StartPosition;
        }
    }
}
