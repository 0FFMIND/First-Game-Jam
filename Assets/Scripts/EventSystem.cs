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
    ////�����޷���ֵ����������ί��
    //public delegate void OpenEventHandler();
    //public delegate void MessageEventHandler(byte[] data);
    //public delegate void ErrorEventHandler(string errorMsg);
    //public delegate void CloseEventHandler(string errorMsg);
    //public delegate void SendEventHandler(GameMessage gameMessage);
    ////����ί�ж�Ӧ���¼�
    //public event OpenEventHandler OnOpen;
    //public event MessageEventHandler OnMessage;
    //public event ErrorEventHandler OnError;
    //public event CloseEventHandler OnClose;
    //public event SendEventHandler OnSend;
    ////��һ��socket
    //private ClientWebSocket socket;
    //private ExternalInfo externalInfo;
    //private LocalInfo localInfo;
    //private PlayerSpawner playerSpawner;
    //private OthersSpawner othersSpawner;
    //private BombSpawner bombSpawner;
    //private bool isAControl = false;
    //private CancellationTokenSource tokenSource;
    //private CancellationToken token;
    ////��֤˳��͸���
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
    //        //�տ�ʼ�����ӵ�ʱ����һ��StartOP����Ϣ
    //        GameMessage startConnect = new GameMessage("Connect", OpcodeDef.StartOp);
    //        SendText(JsonUtility.ToJson(startConnect));//message��opcodeͬʱ���͸�socket
    //    };
    //    OnSend += (sendMessage) =>
    //    {
    //        if(isTwoPeople)//����ֻ��һ����Ҳ������������
    //        {
    //            //����һ������sequence
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
    //    GameMessage gameMessage = JsonUtility.FromJson<GameMessage>(message);//����õ�JSON���ݴ���gameMessage֮��
    //    if (gameMessage.opcode == OpcodeDef.YoulogOp)
    //    {
    //        localInfo.SetText("This room has one player");//��ʾ�������
    //        isAControl = true;
    //        playerSpawner.SpawnPlayer(isAControl);//�����Լ���ɫ
    //    }
    //    else if (gameMessage.opcode == OpcodeDef.ConnectOp)
    //    {
    //        isTwoPeople = true;
    //        playerMoveUpdateSequence = 0;//�ڶ�����ҽ����ʱ��ʼͬ������λ����Ϣ
    //        externalInfo.SetText("Another player join the room : " + gameMessage.uuid);//��Ϣ�㲥
    //        localInfo.SetText("This room has two players");//��ʾ�������
    //        if (!isAControl)
    //        {
    //            playerSpawner.SpawnPlayer(isAControl);//player2�ӽ�������������false
    //            othersSpawner.SpawnOthers(isAControl);
    //        }
    //        else
    //        {
    //            othersSpawner.SpawnOthers(isAControl);//player1�ӽ��������붼Ϊtrue
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
    //    tokenSource = new CancellationTokenSource();//Source����������token��
    //    token = tokenSource.Token;//token����Ϊ��ֹ�̵߳ķ���
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

