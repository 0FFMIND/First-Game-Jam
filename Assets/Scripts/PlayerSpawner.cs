using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    //public GameObject playerPrefab;
    //public GameObject myPlayer;

    //public GameObject skillPrefab;
    //public GameObject playerSkill;
    //public Transform skillTransform;
    //public ShadowPool shadowPool;
    //public PlayerMovement playerMovement = null;
    //public void SpawnPlayer(bool isA)
    //{
    //    //当存在此玩家则不新建，直接返回
    //    if (playerMovement != null) return;
    //    if (playerSkill != null) return;
    //    //否则新建myPlayer并指定局部坐标
    //    myPlayer = Instantiate(playerPrefab, this.transform);
    //    playerMovement = myPlayer.GetComponent<PlayerMovement>();
    //    shadowPool = GameObject.FindWithTag("shadowPool").GetComponent<ShadowPool>();
    //    playerMovement.transform.position = this.transform.position;
    //    myPlayer.SetActive(true);
    //    //设置isPlayerA
    //    playerMovement.isPlayerA = isA;
    //    //现在新建技能条，对象池，并绑定组件
    //    shadowPool.FillPlayerPool(8);
    //}
    //public bool ReturnIsA()
    //{
    //    return playerMovement.isPlayerA;
    //}
    //public void DespawnPlayer()
    //{
    //    if(playerMovement != null)
    //    {
    //        Destroy(playerMovement.gameObject);
    //        GameObject.FindWithTag("webManager").GetComponent<WSNetworkManager>().eventSystem.CallOnClose("test");
    //    }
    //}
}
