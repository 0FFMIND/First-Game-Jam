using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcodeDef : MonoBehaviour
{
    public const string YoulogOp = "0";//该房间只有当前用户的时候返回0
    public const string StartOp = "1";//进入房间的时候请求连接
    public const string ConnectOp = "2";//该房间有人时候再加入返回2
    //指定按键操作的OpCode
    public const string UpdateDash_Op = "3";
    public const string UpdatePos_Op = "7";//进行位置的更新
}
