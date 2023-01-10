using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosMessage {
    public string opcode;
    public float x;
    public float y;
    public uint seq;
    public PosMessage(float xIn, float yIn,string opcodeIn)
    {
        this.x = xIn;
        this.y = yIn;
        this.opcode = opcodeIn;
    }
    public Vector2 ToVector2()
    {
        return new Vector2(x, y);
    }
}
