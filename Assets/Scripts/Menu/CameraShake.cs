using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : UnitySingleton<CameraShake>
{
    private bool isShake;
    public void StartShake(float duration, float strength)
    {
        if (!isShake)
        {
            StartCoroutine(Shake(duration, strength));
        }
    }
    IEnumerator Shake(float duration, float strength)
    {
        isShake = true;
        Transform camera = Camera.main.transform;
        Vector3 startPos = camera.position;
        while(duration > 0)
        {
            camera.position = Random.insideUnitSphere * strength + startPos;
            duration -= Time.deltaTime;
            yield return null;
        }
        camera.position = startPos;
        isShake = false;
    }
}
