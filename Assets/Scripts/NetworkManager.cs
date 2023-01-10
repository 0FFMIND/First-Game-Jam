using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public abstract class NetworkManager : MonoBehaviour
{
    public BombSpawner bombSpawner = null;
    public OthersSpawner othersSpawner = null;
    public PlayerSpawner playerSpawner = null;
    public ExternalInfo externalInfo = null;//用来显示连接信息
    public LocalInfo localInfo = null;//显示内部更新的消息
    public EventSystem eventSystem;//事件中心
    private void Start()
    {
        bombSpawner = GameObject.FindWithTag("bombSpawner").GetComponent<BombSpawner>();
        othersSpawner = GameObject.FindWithTag("othersSpawner").GetComponent<OthersSpawner>();
        playerSpawner = GameObject.FindWithTag("playerSpawner").GetComponent<PlayerSpawner>();
        externalInfo = GameObject.FindWithTag("externalInfo").GetComponent<ExternalInfo>();
        localInfo = GameObject.FindWithTag("localInfo").GetComponent<LocalInfo>();
        if (bombSpawner == null) Debug.Log("Cannot find your BombSpawner");
        if (othersSpawner == null) Debug.Log("Cannot find your OthersSpawner");
        if (playerSpawner == null) Debug.Log("Cannot find your PlayerSpawner");
        if (externalInfo == null) Debug.Log("Cannot find your ExternalInfo");
        if (localInfo == null) Debug.Log("Cannot find your localInfo");
        Connect();
    }
    public abstract void Connect();
}
