using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashShadow : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer thisSprite;
    public SpriteRenderer playerSprite;
    public ShadowPool shadowPool;

    public bool isPlayerA = true;

    //���ƵĲ���
    public float activeTime = 1f;
    public float activeStart;//��ʼʱ��
    public float alpha;
    public float alphaSet = 0.8f;//��ʼֵ
    public float alphaMultiplier = 0.8f;//alpha���ٵı���ֵ
    public float Timer = 0f;
    private void OnEnable()
    {
        player = GameObject.FindWithTag("player").GetComponent<Transform>();
        shadowPool = GameObject.FindWithTag("shadowPool").GetComponent<ShadowPool>();
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        alpha = alphaSet;//��ʼֵ
        thisSprite.sprite = playerSprite.sprite;
        transform.position = player.position;
        transform.localScale = player.localScale;
        transform.rotation = player.rotation;
        activeStart = Time.time;
    }
    private void FixedUpdate()
    {
        Timer += Time.fixedDeltaTime;
        if(Timer > 0.05f) {
            thisSprite.color = new Color(0.8f, 0.8f, 0.8f, alpha);
            alpha *= alphaMultiplier;
            Timer = 0f;
        }
        if (Time.time > activeStart + activeTime)
        {
            shadowPool.ReturnPlayerPool(this.gameObject);
        }
    }
}
