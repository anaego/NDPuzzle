public class BaseConnectionData
{
    private ConnectionType connectionType;

    public ConnectionType ConnectionType { get => connectionType; }

    public BaseConnectionData(ConnectionType connectionType)
    {
        this.connectionType = connectionType;
    }
}