//using NativeWebSocket;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net.WebSockets;
//using System.Threading;
//using System.Threading.Tasks;
//using UnityEngine;

public class WSNetworkManager // NetworkManager//子类会继承父类的成员和方法，Start自动调用
{
    //    private ClientWebSocket mysocket = null;
    //    private string url = "wss://e92kyg8gs9.execute-api.us-east-1.amazonaws.com/production";//绑定自己的WebService地址
    //    private CancellationTokenSource tokenSource; private CancellationToken token;//表示关闭信号
    //    private readonly object Lock = new object();
    //    public override async void Connect()
    //    {
    //        Debug.Log("Trying to connect the web socket URL：" + url); externalInfo.SetText("Waiting for initialization");
    //        try
    //        {
    //            tokenSource = new CancellationTokenSource();//Source是用来产生token的
    //            token = tokenSource.Token;//token属性为终止线程的方法
    //            mysocket = new ClientWebSocket();
    //            await mysocket.ConnectAsync(new Uri(url), token);
    //            Debug.Log("Successfully connected"); externalInfo.SetText("Successfully connected to endpoint：" + url);
    //            eventSystem.SetUp(mysocket,externalInfo,localInfo,playerSpawner,othersSpawner,bombSpawner);//事件中心注册事件
    //            eventSystem.CallOnOpen();//调用OnOpen事件

    //            await ReceiveData();//socket绑定后开始异步接收发送的buffer数据
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
    //    //将绑定的socket上的数据作为异步操作进行接收
    //    public async Task ReceiveData()
    //    {
    //        //用arraySegment接收buffer内容
    //        ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8192]);
    //        try
    //        {
    //            while (mysocket.State == System.Net.WebSockets.WebSocketState.Open)
    //            {
    //                WebSocketReceiveResult result = null;
    //                using (var ms = new MemoryStream())
    //                {
    //                    //客户端收到新信息会进入一次do while循环
    //                    do
    //                    {//刚开始启动的时候没有新信息所以await直接退出，不会再执行下面的逻辑
    //                        result = await mysocket.ReceiveAsync(buffer, token);
    //                        ms.Write(buffer.Array, buffer.Offset, result.Count);
    //                    } while (!result.EndOfMessage);
    //                    ms.Seek(0, SeekOrigin.Begin);

    //                    //将获得的result进行处理
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
