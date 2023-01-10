using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
//    public Rigidbody2D rb = null; public Animator animator = null;
//    public WSNetworkManager wsNetworkManager = null;
//    public BombSpawner bombSpawner = null;
//    //粒子系统
//    public ParticleSystem dust;
//    //是否为当前操作对象
//    public bool isPlayerA = true;
//    //用来移动的参数
//    public LayerMask stopMovement;
//    public float moveSpeed = 3f;
//    //Network的队列
//    public Queue<Action> jobs = new Queue<Action>();
//    public JoyStick joyStickIn;
//    public ShadowPool shadowPool;
//    Queue<PosMessage> posMessages = new Queue<PosMessage>();
//    PosMessage pos;
//    //特殊按键Dash，残影在DashPool上面管理
//    public bool isDashDown = false;
//    private float dashSpeed = 12f;
//    private float dashTime = 0.25f;
//    private float dashCooldownTime = 1f;
//    private float lastDashTime = 0f;
//    private bool isDashOnCoolDown = false;
//    private bool isDashing = false;
//    private float dashImageFillPercentage = 1f;
//    private Vector2 dashdir = new Vector2(0f,0f);
//    public uint nowNum = 0;
//    public uint preNum = 0;
//    private SortedList<uint, PosMessage> updatePosQueue = new SortedList<uint, PosMessage>();
//    void Start()
//    {
//        animator = GetComponent<Animator>(); rb = GetComponent<Rigidbody2D>(); dust = GetComponentInChildren<ParticleSystem>();
//        wsNetworkManager = GameObject.FindWithTag("webManager").GetComponent<WSNetworkManager>();
//        bombSpawner = GameObject.FindWithTag("bombSpawner").GetComponent<BombSpawner>();
//        joyStickIn = GameObject.FindWithTag("joyStick").GetComponent<JoyStick>();
//        shadowPool = GameObject.FindWithTag("shadowPool").GetComponent<ShadowPool>();
//    }
//    public void MoveExternal(float x, float y,uint seq,string opcode)
//    {
//        PosMessage posMessage = new PosMessage(x, y,opcode);
//        if (seq == (uint)0) return;
//        updatePosQueue.Add(seq, posMessage);
//    }
//    private void KeyMove(float x,float y)
//    {
//        Vector2 input;
//        input = new Vector2(x, y);
//        input.Normalize();
//        CheckMoveAndDir(input);
//        //按键移动到的坐标位置
//        Vector2 movement = input * moveSpeed * Time.fixedDeltaTime;
//        //direction = input;
//        rb.MovePosition(rb.position + movement);
//        Vector2 avatarPos = rb.position;
//        BroadcastMovement(avatarPos.x, avatarPos.y);

//    }
//    private void CheckDir(float x, float y)
//    {
//        //当为PlayerA的时候根据按键移动player，非PlayerA的时候根据按键移动others
//        if (isPlayerA && rb.gameObject == GameObject.FindWithTag("player") ||
//            !isPlayerA && rb.gameObject == GameObject.FindWithTag("others")
//            )
//        {
//            KeyMove(x, y);
//        }

//    }
//    private void CreatDust()
//    {
//        dust.Play();
//    }
//    private void CheckMoveAndDir(Vector2 input)
//    {
//        if (input.x > 0.1f || input.x < -0.1f || input.y > 0.1f || input.y < -0.1f)
//        {
//            CreatDust();
//            animator.SetBool("Moving", true);
//        }
//        else
//        {
//            animator.SetBool("Moving", false);
//        }
//        //处理及时的图片旋转用GetAxisRaw
//        bool faceDir = Mathf.Abs(input.x) > Mathf.Epsilon;
//        if (faceDir)
//        {
//            if (input.x > 0.05f)
//            {
//                transform.localRotation = Quaternion.Euler(0, 0, 0);
//            }
//            if (input.x < 0.05f)
//            {
//                transform.localRotation = Quaternion.Euler(0, 180, 0);

//            }
//        }
//    }
//    private void FixedUpdate()
//    {
//        //适配手机按键
//        float x = 0f; float y = 0f;
//        if (!isDashing)
//        {
//            if (joyStickIn.posIn.x != 0)
//            {
//                x = joyStickIn.posIn.x;
//            }
//            else
//            {
//                x = Input.GetAxisRaw("Horizontal");
//            }
//            if(joyStickIn.posIn.y != 0)
//            {
//                y = joyStickIn.posIn.y;
//            }
//            else
//            {
//                y = Input.GetAxisRaw("Vertical");
//            }
//            CheckDir(x, y);
//        }
//        //当为PlayerA的时候根据按键移动player，非PlayerA的时候根据按键移动others
//        if (isPlayerA && rb.gameObject == GameObject.FindWithTag("player") ||
//            !isPlayerA && rb.gameObject == GameObject.FindWithTag("others")
//            )
//        {
//            if (Input.GetKeyDown(KeyCode.J) || isDashDown)
//            {
//                dashdir = new Vector2(x, y);
//                if (isDashOnCoolDown || isDashing)
//                {
//                    return;
//                }
//                lastDashTime = Time.time;
//                isDashing = true;
//                animator.SetBool("Dashing", true); CreatDust();
//                Invoke("AniDelayBool", 0.24f);
//            }
//            Dash(dashdir);
//            CalcDashCoolDownPercentage();
//        }

//        if(updatePosQueue.Count != 0)
//        {
//            ExMove();
//        }
//        if(posMessages.Count != 0)
//        {
            
//            pos = posMessages.Dequeue();
//            if(pos.opcode == OpcodeDef.UpdatePos_Op)
//            {
//                float drift = Vector2.Distance(rb.transform.position, pos.ToVector2());
//                if (drift > 0.05f)
//                {
//                    CreatDust();
//                    animator.SetBool("Moving", true);
//                }
//                else
//                {
//                    animator.SetBool("Moving", false);
//                }
//                float xChange = pos.x - rb.position.x;
//                bool faceDir = Mathf.Abs(xChange) > Mathf.Epsilon;
//                if (faceDir)
//                {
//                    if (xChange > 0.02f)
//                    {
//                        transform.localRotation = Quaternion.Euler(0, 0, 0);
//                    }
//                    if (xChange < -0.02f)
//                    {
//                        transform.localRotation = Quaternion.Euler(0, 180, 0);

//                    }
//                }
//                if (drift > 0.001f)
//                {
//                    Vector2 input;
//                    input = new Vector2(pos.x, pos.y) - new Vector2(rb.transform.position.x, rb.transform.position.y);
//                    rb.position = Vector2.Lerp(rb.position, new Vector2(pos.x, pos.y), 0.25f);
//                    //rb.MovePosition(pos.ToVector2());
//                }
//            }
//            if(pos.opcode == OpcodeDef.UpdateDash_Op)
//            {
//                Vector2 dashDir = new Vector2(pos.x, pos.y);
//                if (isPlayerA && rb.gameObject == GameObject.FindWithTag("others"))
//                    shadowPool.GetFromOthersPool();
//                if (!isPlayerA && rb.gameObject == GameObject.FindWithTag("player"))
//                    shadowPool.GetFromPlayerPool();
//                animator.SetBool("Dashing", true); CreatDust();
//                Invoke("AniDelayBool", 0.24f);
//                dashDir.Normalize();
//                CheckMoveAndDir(dashDir);
//                //按键移动到的坐标位置
//                Vector2 movement = dashDir * dashSpeed * Time.fixedDeltaTime;
//                //direction = input;
//                rb.MovePosition(rb.position + movement);
//                Vector2 avatarPos = rb.position;
//            }

//        }
//    }
//    private void AniDelayBool()
//    {
//        animator.SetBool("Dashing", false);
//    }
//    private void ExMove()
//    {
//        IList<uint> keys = updatePosQueue.Keys;
//        uint min = keys[0];
//        for (int i = 0; i < keys.Count; i++)
//        {
//            var value = keys[i];
//            if(min > keys[i])
//            {
//                min = keys[i];
//            }
//        }

//        if (preNum != 0) nowNum = min;
//        if (nowNum > preNum)
//            posMessages.Enqueue(updatePosQueue[nowNum]);
//        preNum = min;
//        updatePosQueue.Remove(min);
//    }
//    public void CalcDashCoolDownPercentage()
//    {
//        if (isDashOnCoolDown)
//        {
//            dashImageFillPercentage = (Time.time - lastDashTime) / dashCooldownTime;
//        }
//        else//默认dashonCoolDown为false
//        {
//            dashImageFillPercentage = 1f;
//        }
//    }
//    public float GetCooldownPercentage()
//    {
//        return dashImageFillPercentage;
//    }
//    private void Dash(Vector2 dashDir)
//    {
//        //当前时间小于3秒返回为true，正在cooldown
//        isDashOnCoolDown = lastDashTime == 0f ? false : Time.time - lastDashTime < dashCooldownTime;
//        if (!isDashing) return;
//        bool isDashFinished = Time.time - lastDashTime > dashTime;
//        if (isPlayerA && rb.gameObject == GameObject.FindWithTag("player"))
//            shadowPool.GetFromPlayerPool();
//        if (!isPlayerA && rb.gameObject == GameObject.FindWithTag("others"))
//            shadowPool.GetFromOthersPool();
//        if (isDashFinished)
//        {
//            isDashing = false;
//        }
//        else
//        {
//            dashDir.Normalize();
//            CheckMoveAndDir(dashDir);
//            //按键移动到的坐标位置
//            Vector2 movement = dashDir * dashSpeed * Time.fixedDeltaTime;
//            //dir为当前方向
//            rb.MovePosition(rb.position + movement);
//            Vector2 avatarPos = rb.position;
//            BroadcastDash(dashdir.x,dashdir.y);
//        }
//    }
//    private void BroadcastDash(float x, float y)
//    {
//        GameMessage gameMessage = new GameMessage(OpcodeDef.UpdateDash_Op, x.ToString(), y.ToString());
//        wsNetworkManager.eventSystem.CallOnSend(gameMessage);
//    }
//    private void BroadcastMovement(float x,float y)
//    {
//        GameMessage gameMessage = new GameMessage(OpcodeDef.UpdatePos_Op, x.ToString(), y.ToString());
//        wsNetworkManager.eventSystem.CallOnSend(gameMessage);
//    }
//    public void SetDash()
//    {
//        isDashDown = true;
//        Invoke("SetDashBool", 0.02f);
//    }
//    public void SetDashBool()
//    {
//        isDashDown = false;
//    }
}
