using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletImpact;
    private float bulletDamage;
    public void setBulletDamage(float damage)
    {
        bulletDamage = damage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy" || collision.gameObject.tag == "wall")
        {
            if(collision.gameObject.tag == "enemy")
            {
                collision.gameObject.GetComponent<IEnemyBase>().ReceiveDamage(bulletDamage);
                GameObject impact = Instantiate(bulletImpact, transform.position, Quaternion.identity);
                Destroy(impact, 0.3f);
                Destroy(gameObject);
            }
            else if(collision.gameObject.tag == "wall")
            {
                GameObject impact = Instantiate(bulletImpact, transform.position, Quaternion.identity);
                Destroy(impact, 0.3f);
                Destroy(gameObject);
            }
        }
    }
}
