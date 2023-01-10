using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMgr : MonoBehaviour
{
    public enum State
    {
        Normal,
        Death,
    }
    public State state;
    public float maxHealth = 200f;
    public float nowHealth;
    private TInput tInput;
    private THealth tHealth;
    private TAimWeapon tAimWeapon;
    private Animator animator;
    private AudioSource audioSource;
    //
    private bool isE = false;
    private bool onCool = false;
    public float coolTime = 15f;
    private float lastTime;
    private bool once = true;
    private void Start()
    {
        //Register
        tInput = GetComponent<TInput>();
        tAimWeapon = GetComponent<TAimWeapon>();
        tHealth = GetComponent<THealth>();
        animator = GetComponent<Animator>();
        state = State.Normal;
        audioSource = GetComponent<AudioSource>();
        //Event
        tInput.OnShootEvent = () => { tAimWeapon.HandleShoot(state); };
        nowHealth = maxHealth;//相当于百分比
    }
    public void ReceiveDamage(float damage)
    {
        if ( nowHealth <= 0)
            return;
        nowHealth -= damage;
        tHealth.SetHealthBar(nowHealth,maxHealth);
        if (nowHealth <= 0)
        {
            state = TMgr.State.Death;
        }
        else
        {
            GameObject.FindWithTag("hitSound").GetComponent<AudioSource>().Play();
        }
    }
    private void Update()
    {
        if (state == TMgr.State.Death)
        {
            animator.SetBool("death", true);
            Invoke("SetDeathBool", 0.2f);
            int NUMB = GameObject.FindWithTag("groundMgr").GetComponent<TowerMgr>().enemyKilled;
            if (once)
            {
                MineObj.Instance.AddMine(NUMB * 0.1f);
                once = false;
            }
            GameObject.FindWithTag("hitSound").GetComponent<AudioSource>().Play();
            Fader.Instance.ChangeScene("BackThree");
            return;
        }
        if (state == TMgr.State.Normal)
        {
            tAimWeapon.PlayerAim(tInput.aimPointVector);
            if ((Input.GetKeyDown(KeyCode.E)|| isE) && !onCool)
            {
                isE = false;
                DestroyAll();
                audioSource.Play();
                lastTime = Time.time;
                onCool = true;
                Invoke("OnCool", coolTime);
            }
            
        }
    }
    public void DestroyAll()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].GetComponent<EnemyBase>().Death();
        }
    }
    public float GetPercentage()
    {
        if (onCool)
        {
            return (Time.time - lastTime) / coolTime;
        }
        else
        {
            return 1f;
        }
    }
    public void OnCool()
    {
        onCool = false;
    }
    public void SetE()
    {
        isE = true;
    }
    private void SetDeathBool()
    {
        animator.SetBool("Death", false);
    }
}
