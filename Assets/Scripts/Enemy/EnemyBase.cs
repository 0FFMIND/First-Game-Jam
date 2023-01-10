using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class EnemyBase : MonoBehaviour, IEnemyBase
{
    //子类数据
    public GameObject deathParticle;
    public float meleeDamage;
    public float maxHealth;
    public AudioSource deathAudio;
    public enum EnemyType
    {
        Bat,
        Mine,
        Mole,
        GBat,
    }
    public EnemyType enemyType;
    //原有
    private DropMgr dropMgr;
    private GameMgr gameMgr;
    private NpcBar npcBar;
    private float health;
    private State state;
    private Animator animator;
    private AIPath aIPath;
    private AIDestinationSetter aIDestinationSetter;
    private CircleCollider2D circleCollider;
    //塔上
    private TowerMgr towerMgr;

    private enum State
    {
        Normal,
        Dead
    }
    private void Start()
    {
        if(enemyType == EnemyType.Mine || enemyType == EnemyType.Bat)
        {
            gameMgr = GameObject.FindWithTag("groundMgr").GetComponent<GameMgr>();
            dropMgr = GameObject.FindWithTag("groundMgr").GetComponent<DropMgr>();
            npcBar = GetComponentInChildren<NpcBar>();
            animator = GetComponent<Animator>();
            circleCollider = GetComponent<CircleCollider2D>();
            aIPath = GetComponent<AIPath>();
            aIDestinationSetter = GetComponent<AIDestinationSetter>();
            //设置
            health = maxHealth;
            state = State.Normal;
            npcBar.SetHealth(health, maxHealth);
            aIDestinationSetter.target = GameObject.FindWithTag("player").GetComponent<Transform>();
        }else if(enemyType == EnemyType.GBat || enemyType == EnemyType.Mole)
        {
            towerMgr = GameObject.FindWithTag("groundMgr").GetComponent<TowerMgr>();
            npcBar = GetComponentInChildren<NpcBar>();
            animator = GetComponent<Animator>();
            circleCollider = GetComponent<CircleCollider2D>();
            aIPath = GetComponent<AIPath>();
            aIDestinationSetter = GetComponent<AIDestinationSetter>();
            //设置
            health = maxHealth;
            state = State.Normal;
            npcBar.SetHealth(health, maxHealth);
            if (!MineObj.Instance.GetDefence())
            {
                aIDestinationSetter.target = GameObject.FindWithTag("lowTower").GetComponent<Transform>();
            }else if (MineObj.Instance.GetDefence())
            {
                aIDestinationSetter.target = GameObject.FindWithTag("highTower").GetComponent<Transform>();
            }
        }
    }
    private void Update()
    {
        CheckFlip();
    }
    private void CheckFlip()
    {
        //暂时不用写
    }
    public void ReceiveDamage(float damage)
    {
        if (state != State.Normal)
            return;
        health -= damage;
        npcBar.SetHealth(health, maxHealth);
        if (health <= 0)
        {
            Death();
            return;
        }
        Hit();
    }
    private void Hit()
    {
        animator.SetTrigger("Hit");
    }
    public void Death()
    {
        state = State.Dead;
        deathAudio.Play();
        circleCollider.enabled = false;
        aIPath.isStopped = true;
        StartCoroutine(PlayDeathAnimation());
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "TowerScene")
        {
            towerMgr.AddEnemyDead();
        }else if(scene.name == "GroundScene")
        {
            gameMgr.AddEnemyDead();
        }
    }
    private IEnumerator PlayDeathAnimation()
    {
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        //没有的就不用drop
        if(enemyType == EnemyType.Bat)
        {
            dropMgr.DropHeart(transform.position);
        }else if(enemyType == EnemyType.Mine)
        {
            dropMgr.DropGold(transform.position);
        }
        GameObject particle = Instantiate(deathParticle, transform.position, Quaternion.identity);
        npcBar.DisableAll();
        Destroy(particle, 0.4f);
        Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(enemyType == EnemyType.Bat || enemyType == EnemyType.Mine)
        {
            if (collision.gameObject.tag == "player")
            {
                collision.gameObject.GetComponent<PlayerMgr>().ReceiveDamage(meleeDamage);
            }
        }else if(enemyType == EnemyType.Mole || enemyType == EnemyType.GBat)
        {
            if (!MineObj.Instance.GetDefence())
            {
                if(collision.gameObject.tag == "lowTower")
                {
                    collision.gameObject.GetComponent<TMgr>().ReceiveDamage(meleeDamage);
                }
            }
            else if (MineObj.Instance.GetDefence())
            {
                if (collision.gameObject.tag == "highTower")
                {
                    collision.gameObject.GetComponent<TMgr>().ReceiveDamage(meleeDamage);
                }
            }
        }
    }
}
