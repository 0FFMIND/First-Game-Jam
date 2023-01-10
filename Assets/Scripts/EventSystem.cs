using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.WebSockets;
using System.Text;
using System;
using System.Threading;
using System.Threading.Tasks;

public class EventSystem : MonoBehaviour
{
    ////定义无返回值但带参数的委托
    //public delegate void OpenEventHandler();
    //public delegate void MessageEventHandler(byte[] data);
    //public delegate void ErrorEventHandler(string errorMsg);
    //public delegate void CloseEventHandler(string errorMsg);
    //public delegate void SendEventHandler(GameMessage gameMessage);
    ////定义委托对应的事件
    //public event OpenEventHandler OnOpen;
    //public event MessageEventHandler OnMessage;
    //public event ErrorEventHandler OnError;
    //public event CloseEventHandler OnClose;
    //public event SendEventHandler OnSend;
    ////带一个socket
    //private ClientWebSocket socket;
    //private ExternalInfo externalInfo;
    //private LocalInfo localInfo;
    //private PlayerSpawner playerSpawner;
    //private OthersSpawner othersSpawner;
    //private BombSpawner bombSpawner;
    //private bool isAControl = false;
    //private CancellationTokenSource tokenSource;
    //private CancellationToken token;
    ////保证顺序和更新
    //private uint playerMoveUpdateSequence = 1;
    //private bool isTwoPeople = false;
    //public void SetUp(ClientWebSocket socket, ExternalInfo externalInfo, LocalInfo localInfo, PlayerSpawner playerSpawner, OthersSpawner othersSpawner, BombSpawner bombSpawner)
    //{
    //    this.socket = socket;
    //    this.externalInfo = externalInfo;
    //    this.localInfo = localInfo;
    //    this.bombSpawner = bombSpawner;
    //    this.othersSpawner = othersSpawner;
    //    this.playerSpawner = playerSpawner;
    //    OnOpen += () =>
    //    {
    //        //刚开始的连接的时候发送一个StartOP的消息
    //        GameMessage startConnect = new GameMessage("Connect", OpcodeDef.StartOp);
    //        SendText(JsonUtility.ToJson(startConnect));//message和opcode同时发送给socket
    //    };
    //    OnSend += (sendMessage) =>
    //    {
    //        if(isTwoPeople)//否则只有一个玩家不发送坐标更新
    //        {
    //            //增加一个计数sequence
    //            string str = playerMoveUpdateSequence.ToString();
    //            str.TrimStart((char)0);
    //            sendMessage = new GameMessage(sendMessage.opcode, str, sendMessage.movex, sendMessage.movey);
    //            playerMoveUpdateSequence++;
    //            SendText(JsonUtility.ToJson(sendMessage));
    //        }
    //    };

    //    OnMessage += (bytes) =>
    //    {
    //        string message = Encoding.UTF8.GetString(bytes);
    //        ProcessMessage(message);
    //    };
    //}
    //public void ProcessMessage(string message)
    //{
    //    GameMessage gameMessage = JsonUtility.FromJson<GameMessage>(message);//将获得的JSON数据存入gameMessage之中
    //    if (gameMessage.opcode == OpcodeDef.YoulogOp)
    //    {
    //        localInfo.SetText("This room has one player");//表示玩家数量
    //        isAControl = true;
    //        playerSpawner.SpawnPlayer(isAControl);//创建自己角色
    //    }
    //    else if (gameMessage.opcode == OpcodeDef.ConnectOp)
    //    {
    //        isTwoPeople = true;
    //        playerMoveUpdateSequence = 0;//第二个玩家进入的时候开始同步发送位置信息
    //        externalInfo.SetText("Another player join the room : " + gameMessage.uuid);//消息广播
    //        localInfo.SetText("This room has two players");//表示玩家数量
    //        if (!isAControl)
    //        {
    //            playerSpawner.SpawnPlayer(isAControl);//player2视角两个参数都是false
    //            othersSpawner.SpawnOthers(isAControl);
    //        }
    //        else
    //        {
    //            othersSpawner.SpawnOthers(isAControl);//player1视角两个传入都为true
    //        }
    //    }
    //    else if (gameMessage.opcode == OpcodeDef.UpdatePos_Op || gameMessage.opcode == OpcodeDef.UpdateDash_Op)
    //    {
    //        float x = float.Parse(gameMessage.movex);
    //        float y = float.Parse(gameMessage.movey);
    //        uint seq = uint.Parse(gameMessage.seq);
    //        string opcode = gameMessage.opcode;
    //        if (!isAControl && isTwoPeople)
    //        {
    //            playerSpawner.playerMovement.MoveExternal(x, y,seq,opcode);
    //        }
    //        else if (isAControl && isTwoPeople)
    //        {
    //            othersSpawner.playerMovement.MoveExternal(x, y,seq,opcode);
    //        }
    //    }
    //}
    //public void CallOnSend(GameMessage sendMessage)
    //{
    //    OnSend?.Invoke(sendMessage);
    //}
    //public void CallOnError(string message)
    //{
    //    OnError?.Invoke(message);
    //}
    //public void CallOnClose(string test)
    //{
    //    OnClose?.Invoke(test);
    //}
    //public void CallOnOpen()
    //{
    //    OnOpen?.Invoke();
    //}
    //public void CallOnMessage(byte[] data)
    //{
    //    OnMessage?.Invoke(data);
    //}
    //private readonly object Lock = new object();

    //private bool isSending = false;
    //private List<ArraySegment<byte>> sendTextQueue = new List<ArraySegment<byte>>();
    //public Task SendText(string message)
    //{
    //    var encoded = Encoding.UTF8.GetBytes(message);
    //    return SendMessage(sendTextQueue, WebSocketMessageType.Text, new ArraySegment<byte>(encoded, 0, encoded.Length));
    //}

    //private async Task SendMessage(List<ArraySegment<byte>> queue, WebSocketMessageType messageType, ArraySegment<byte> buffer)
    //{
    //    tokenSource = new CancellationTokenSource();//Source是用来产生token的
    //    token = tokenSource.Token;//token属性为终止线程的方法
    //    if (buffer.Count == 0)
    //    {
    //        return;
    //    }
    //    bool sending;

    //    lock (Lock)
    //    {
    //        sending = isSending;

    //        // If not, we are now.
    //        if (!isSending)
    //        {
    //            isSending = true;
    //        }
    //    }

    //    if (!sending)
    //    {
    //        // Lock with a timeout, just in case.
    //        if (!Monitor.TryEnter(socket, 1000))
    //        {
    //            // If we couldn't obtain exclusive access to the socket in one second, something is wrong.
    //            await socket.CloseAsync(WebSocketCloseStatus.InternalServerError, string.Empty, token);
    //            return;
    //        }

    //        try
    //        {
    //            // Send the message synchronously.
    //            var t = socket.SendAsync(buffer, messageType, true, token);
    //            t.Wait(token);
    //        }
    //        finally
    //        {
    //            Monitor.Exit(socket);
    //        }

    //        // Note that we've finished sending.
    //        lock (Lock)
    //        {
    //            isSending = false;
    //        }

    //        // Handle any queued messages.
    //        await HandleQueue(queue, messageType);
    //    }
    //    else
    //    {
    //        // Add the message to the queue.
    //        lock (Lock)
    //        {
    //            queue.Add(buffer);
    //        }
    //    }
    //}

    //private async Task HandleQueue(List<ArraySegment<byte>> queue, WebSocketMessageType messageType)
    //{
    //    var buffer = new ArraySegment<byte>();
    //    lock (Lock)
    //    {
    //        // Check for an item in the queue.
    //        if (queue.Count > 0)
    //        {
    //            // Pull it off the top.
    //            buffer = queue[0];
    //            queue.RemoveAt(0);
    //        }
    //    }

    //    // Send that message.
    //    if (buffer.Count > 0)
    //    {
    //        await SendMessage(queue, messageType, buffer);
    //    }
    //}
}

