using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Pickable
{
    public float healAmount = 20f;
    public GameObject pickParticle;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<PlayerMgr>().Heal(healAmount);
            GameObject.FindWithTag("getSound").GetComponent<AudioSource>().Play();
            GameObject particle = Instantiate(pickParticle, transform.position, Quaternion.identity);
            Destroy(particle, 0.4f);
            Destroy(gameObject);
        }
    }
}
