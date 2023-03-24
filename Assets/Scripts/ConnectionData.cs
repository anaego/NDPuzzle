public class ConnectionData : BaseConnectionData
{
    private NodeData startNode;
    private NodeData endNode;
    private bool canBeUsed;
    private bool isOn;

    public NodeData StartNode { get => startNode; }
    public NodeData EndNode { get => endNode; }
    public bool IsOn { get => isOn; }

    public ConnectionData(ConnectionType connectionType, NodeData startNode, NodeData endNode, bool isOn = false) 
        : base(connectionType)
    {
        this.startNode = startNode;
        this.endNode = endNode;
        this.isOn = isOn;
    }
}
