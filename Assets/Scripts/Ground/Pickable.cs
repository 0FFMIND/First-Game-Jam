using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public enum Type
    {
        Gold,
        Weapon,
        Heart,
    }
    public Type type;
    public float timeBeforeDespawn = 8f;
    public float DelayBetweenFlash = 0.3f;
    public GameObject ItemDespawn;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(DespawnAfterXSeconds());
    }
    private IEnumerator DespawnAfterXSeconds()
    {
        float timeLeft = timeBeforeDespawn * 0.8f;
        yield return new WaitForSeconds(timeLeft);
        while(timeLeft > 0)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            timeLeft -= DelayBetweenFlash;
            yield return new WaitForSeconds(DelayBetweenFlash);
        }
        Destroy(gameObject);
    }
}
