//using NativeWebSocket;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net.WebSockets;
//using System.Threading;
//using System.Threading.Tasks;
//using UnityEngine;

public class WSNetworkManager // NetworkManager//�����̳и���ĳ�Ա�ͷ�����Start�Զ�����
{
    //    private ClientWebSocket mysocket = null;
    //    private string url = "wss://e92kyg8gs9.execute-api.us-east-1.amazonaws.com/production";//���Լ���WebService��ַ
    //    private CancellationTokenSource tokenSource; private CancellationToken token;//��ʾ�ر��ź�
    //    private readonly object Lock = new object();
    //    public override async void Connect()
    //    {
    //        Debug.Log("Trying to connect the web socket URL��" + url); externalInfo.SetText("Waiting for initialization");
    //        try
    //        {
    //            tokenSource = new CancellationTokenSource();//Source����������token��
    //            token = tokenSource.Token;//token����Ϊ��ֹ�̵߳ķ���
    //            mysocket = new ClientWebSocket();
    //            await mysocket.ConnectAsync(new Uri(url), token);
    //            Debug.Log("Successfully connected"); externalInfo.SetText("Successfully connected to endpoint��" + url);
    //            eventSystem.SetUp(mysocket,externalInfo,localInfo,playerSpawner,othersSpawner,bombSpawner);//�¼�����ע���¼�
    //            eventSystem.CallOnOpen();//����OnOpen�¼�

    //            await ReceiveData();//socket�󶨺�ʼ�첽���շ��͵�buffer����
    //        }
    //        catch(Exception e)
    //        {
    //            eventSystem.CallOnError(e.Message);
    //            eventSystem.CallOnClose("Close");
    //        }
    //        finally
    //        {
    //            if(mysocket != null)
    //            {
    //                tokenSource.Cancel();
    //                mysocket.Dispose();
    //            }
    //        }
    //    }
    //    private List<byte[]> messageList = new List<byte[]>();
    //    public void DispatchMessageQueue()
    //    {
    //        if (messageList.Count == 0)
    //        {
    //            return;
    //        }

    //        List<byte[]> messageListCopy;

    //        lock (Lock)
    //        {
    //            messageListCopy = new List<byte[]>(messageList);
    //            messageList.Clear();
    //        }

    //        var len = messageListCopy.Count;
    //        for (int i = 0; i < len; i++)
    //        {
    //            eventSystem.CallOnMessage(messageListCopy[i]);
    //        }
    //    }
    //    private void FixedUpdate()
    //    {
    //        DispatchMessageQueue();
    //    }
    //    //���󶨵�socket�ϵ�������Ϊ�첽�������н���
    //    public async Task ReceiveData()
    //    {
    //        //��arraySegment����buffer����
    //        ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8192]);
    //        try
    //        {
    //            while (mysocket.State == System.Net.WebSockets.WebSocketState.Open)
    //            {
    //                WebSocketReceiveResult result = null;
    //                using (var ms = new MemoryStream())
    //                {
    //                    //�ͻ����յ�����Ϣ�����һ��do whileѭ��
    //                    do
    //                    {//�տ�ʼ������ʱ��û������Ϣ����awaitֱ���˳���������ִ��������߼�
    //                        result = await mysocket.ReceiveAsync(buffer, token);
    //                        ms.Write(buffer.Array, buffer.Offset, result.Count);
    //                    } while (!result.EndOfMessage);
    //                    ms.Seek(0, SeekOrigin.Begin);

    //                    //����õ�result���д���
    //                    if (result.MessageType == WebSocketMessageType.Text)
    //                    {

    //                        lock (Lock)
    //                        {
    //                            messageList.Add(ms.ToArray());
    //                        }


    //                    }
    //                    else if (result.MessageType == WebSocketMessageType.Close)
    //                    {
    //                        await Close();
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            tokenSource.Cancel();
    //        }
    //        finally
    //        {
    //            eventSystem.CallOnClose("close");
    //        }

    //    }
    //    public async Task Close()
    //    {
    //        await mysocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, token);
    //    }
}
