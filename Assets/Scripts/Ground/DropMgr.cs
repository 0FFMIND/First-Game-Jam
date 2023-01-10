using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMgr : MonoBehaviour
{
    [System.Serializable]
    public struct Object
    {
        public GameObject pickable;
        public float dropChance;
    }
    public Object[] objects;
    public void DropGun(Vector3 position)
    {
        //ÔÝÊ±²»Ð´
    }
    public void DropGold(Vector3 position)
    {
        Instantiate(objects[0].pickable, position, Quaternion.identity);
    }
    public void DropHeart(Vector3 position)
    {
        float randomValue = Random.value;
        if(randomValue < objects[1].dropChance)
        {
            Instantiate(objects[1].pickable, position, Quaternion.identity);
        }
    }
}
