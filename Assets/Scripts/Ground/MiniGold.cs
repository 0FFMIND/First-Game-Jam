using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGold : Pickable
{
    public GameObject pickParticle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            GameObject.FindWithTag("groundMgr").GetComponent<GameMgr>().AddMine();
            GameObject.FindWithTag("getSound").GetComponent<AudioSource>().Play();
            GameObject particle = Instantiate(pickParticle, transform.position, Quaternion.identity);
            Destroy(particle, 0.4f);
            Destroy(gameObject);
        }
    }
}
