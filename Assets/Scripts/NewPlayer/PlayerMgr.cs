using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    private float maxHealthOne = 100;
    private float maxHealthTwo = 300;
    private float maxHealth;
    private float nowHealth;
    private IPlayerInput playerInput;
    private PAimWeapon pAimWeapon;
    private PMovement pMovement;
    private PHealth pHealth;
    private void Start()
    {
        //Register
        playerInput = GetComponent<IPlayerInput>();
        pAimWeapon = GetComponent<PAimWeapon>();
        pMovement = GetComponent<PMovement>();
        pHealth = GetComponent<PHealth>();
        //Event
        playerInput.OnShootEvent = () => { pAimWeapon.HandleShoot(pMovement.state); };
        pHealth.SetMaxHealth();
        if (MineObj.Instance.GetTwoD())
        {
            maxHealth = maxHealthTwo;
        }else if (!MineObj.Instance.GetTwoD())
        {
            maxHealth = maxHealthOne;
        }
        nowHealth = maxHealth;//相当于百分比

    }
    public void Heal(float healAmount)
    {
        nowHealth += healAmount;
        if (nowHealth > maxHealth)
            nowHealth = maxHealth;
        pHealth.SetHealthBar(nowHealth,maxHealth);
    }
    public void ReceiveDamage(float damage)
    {
        if (pMovement.state == PMovement.State.Roll || nowHealth <= 0)
            return;
        nowHealth -= damage;
        pHealth.SetHealthBar(nowHealth,maxHealth);
        if(nowHealth<= 0)
        {
            pMovement.state = PMovement.State.Death;
        }
        else
        {
            pMovement.HitPlay();
            GameObject.FindWithTag("hitSound").GetComponent<AudioSource>().Play();
        }
    }
    private void Update()
    {
        if(pMovement.state == PMovement.State.Death)
        {
            pMovement.freezeMovement();
            pMovement.animator.SetBool("death", true);
            Invoke("SetDeathBool", 0.2f);
            GameObject.FindWithTag("hitSound").GetComponent<AudioSource>().Play();
            Fader.Instance.isDefeated = true;
            MineObj.Instance.StolenMine();
            Fader.Instance.ChangeScene("BackTwo");
            return;
        }
        if(pMovement.state == PMovement.State.Normal)
        {
            pAimWeapon.PlayerAim(playerInput.aimPointVector);
            pMovement.managePlayerMove(playerInput.movementInputVector);
            pMovement.CheckDash(playerInput.movementInputVector);
        }
    }
    private void SetDeathBool()
    {
        pMovement.animator.SetBool("death", false);
    }
}
