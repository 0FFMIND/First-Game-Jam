[System.Serializable]
public class GameMessage
{
    public string uuid;
    public string opcode;
    public string message;
    public string movex;
    public string movey;
    //seq为发送包的顺序
    public string seq;
    public GameMessage(string messageIn, string opcodeIn)
    {
        this.message = messageIn;
        this.opcode = opcodeIn;
    }
    public GameMessage(string opcodeIn, string movexIn, string moveyIn)
    {
        this.opcode = opcodeIn;
        this.movex = movexIn;
        this.movey = moveyIn;
    }
    public GameMessage(string opcodeIn, string seqIn,string movexIn, string moveyIn)
    {
        this.opcode = opcodeIn;
        this.seq = seqIn;
        this.movex = movexIn;
        this.movey = moveyIn;
    }
}
