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
    //    //�����ڴ�������½���ֱ�ӷ���
    //    if (playerMovement != null) return;
    //    if (playerSkill != null) return;
    //    //�����½�myPlayer��ָ���ֲ�����
    //    myPlayer = Instantiate(playerPrefab, this.transform);
    //    playerMovement = myPlayer.GetComponent<PlayerMovement>();
    //    shadowPool = GameObject.FindWithTag("shadowPool").GetComponent<ShadowPool>();
    //    playerMovement.transform.position = this.transform.position;
    //    myPlayer.SetActive(true);
    //    //����isPlayerA
    //    playerMovement.isPlayerA = isA;
    //    //�����½�������������أ��������
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
