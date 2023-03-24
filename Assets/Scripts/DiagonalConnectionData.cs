public class DiagonalConnectionData : BaseConnectionData
{
    private ConnectionData upperRightToLowerLeftConnection;
    private ConnectionData upperLeftToLowerRightConnection;

    public DiagonalConnectionData(
        ConnectionType connectionType, 
        ConnectionData upperRightToLowerLeftConnection = null,
        ConnectionData upperLeftToLowerRightConnection = null) 
        : base(connectionType)
    {
        this.upperRightToLowerLeftConnection = upperRightToLowerLeftConnection;
        this.upperLeftToLowerRightConnection = upperLeftToLowerRightConnection;
    }
}
