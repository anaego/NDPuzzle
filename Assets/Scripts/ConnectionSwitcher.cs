using UnityEngine;

public class ConnectionSwitcher : MonoBehaviour
{
    public NodeConnection connection1;
    public NodeConnection connection2;

    public void OnMouseUp()
    {
        if (connection2 == null)
        {
            connection1.ToggleConnection(!connection1.On);
        }
        else
        {
            ToggleTwoConnections();
        }
    }

    private void ToggleTwoConnections()
    {
        if (!connection1.On && !connection1.On)
        {
            connection1.ToggleConnection(true);
        }
        else if (connection1.On)
        {
            connection1.ToggleConnection(false);
            connection2.ToggleConnection(true);
        }
        else if (connection2.On)
        {
            connection1.ToggleConnection(false);
            connection2.ToggleConnection(false);
        }
    }
}
