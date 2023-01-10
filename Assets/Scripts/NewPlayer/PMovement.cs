using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isRight = true;
    private ParticleSystem dust;
    public ParticleSystem hit;
    private ShadowPool shadowPool;
    public State state { get; set; }
    private Rigidbody2D rb;
    public Animator animator;
    //���ⰴ��Dash����Ӱ��DashPool�������
    public bool isDashDown = false;
    private float dashSpeed = 12f;
    private float dashTime = 0.25f;
    private float dashCooldownTime = 1f;
    private float lastDashTime = 0f;
    private bool isDashOnCoolDown = false;
    private bool isDashing = false;
    private float dashImageFillPercentage = 1f;
    private Vector2 dashdir = new Vector2(0f, 0f);
    public enum State
    {
        Normal,
        Roll,
        Death,
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dust = GameObject.FindWithTag("dust").GetComponent<ParticleSystem>();
        hit = GameObject.FindGameObjectWithTag("hit").GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        shadowPool = GameObject.FindWithTag("shadowPool").GetComponent<ShadowPool>();
        state = State.Normal;
    }
    public void managePlayerMove(Vector2 movementInput)
    {
        switch (state)
        {
            case State.Normal:
                MovePlayer(movementInput);
                break;
            case State.Roll:
                break;
        }
    }
    public void HitPlay()
    {
        hit.Play();
    }
    public void freezeMovement()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void MovePlayer(Vector2 movementInput)
    {
        movementInput.Normalize();
        CheckMoveAndDir(movementInput);
        Vector2 movement = movementInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
    public void CheckDash(Vector2 movementInput)
    {
        if (Input.GetKeyDown(KeyCode.E) || isDashDown)
        {
            dashdir = movementInput;
            if (isDashOnCoolDown || isDashing)
            {
                return;
            }
            lastDashTime = Time.time;
            isDashing = true;
            animator.SetBool("Dashing", true); CreatDust();
            Invoke("AniDelayBool", 0.24f);
        }
        Dash(dashdir);
        CalcDashCoolDownPercentage();
    }
    public void CalcDashCoolDownPercentage()
    {
        if (isDashOnCoolDown)
        {
            dashImageFillPercentage = (Time.time - lastDashTime) / dashCooldownTime;
        }
        else//Ĭ��dashonCoolDownΪfalse
        {
            dashImageFillPercentage = 1f;
        }
    }
    public float GetCooldownPercentage()
    {
        return dashImageFillPercentage;
    }
    public void SetDash()
    {
        isDashDown = true;
        Invoke("SetDashBool", 0.02f);
    }
    public void SetDashBool()
    {
        isDashDown = false;
    }
    private void Dash(Vector2 dashDir)
    {
        //��ǰʱ��С��3�뷵��Ϊtrue������cooldown
        isDashOnCoolDown = lastDashTime == 0f ? false : Time.time - lastDashTime < dashCooldownTime;
        if (!isDashing) return;
        bool isDashFinished = Time.time - lastDashTime > dashTime;
        shadowPool.GetFromPlayerPool();
        if (isDashFinished)
        {
            isDashing = false;
        }
        else
        {
            dashDir.Normalize();
            CheckMoveAndDir(dashDir);
            GameObject.FindWithTag("rollSound").GetComponent<AudioSource>().Play();
            //�����ƶ���������λ��
            Vector2 movement = dashDir * dashSpeed * Time.fixedDeltaTime;
            //dirΪ��ǰ����
            rb.MovePosition(rb.position + movement);
        }
    }
    private void AniDelayBool()
    {
        animator.SetBool("Dashing", false);
    }
    private void CreatDust()
    {
        dust.Play();
    }
    private void CheckMoveAndDir(Vector2 input)
    {
        //����ʱ��ͼƬ��ת��GetAxisRaw
        bool faceDir = Mathf.Abs(input.x) > Mathf.Epsilon;
        if (faceDir)
        {
            if (input.x > 0.05f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                GameObject.FindWithTag("bar").GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 0);
                dust.transform.localScale = new Vector3(1, 1, 1);
                isRight = true;
            }
            if (input.x < 0.05f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                GameObject.FindWithTag("bar").GetComponent<Transform>().localRotation = Quaternion.Euler(0, -180, 0);
                dust.transform.localScale = new Vector3(-1, 1, 1);
                isRight = false;
            }
        }

        if (input.x > 0.1f || input.x < -0.1f || input.y > 0.1f || input.y < -0.1f)
        {
            CreatDust();
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
}
