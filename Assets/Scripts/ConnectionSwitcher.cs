using UnityEngine;

public class ConnectionSwitcher : MonoBehaviour
{
    public NodeConnection upperLeftToLowerRight; // diagonal from upper left to lower right
    public NodeConnection upperRightToLowerLeft; // diagonal from lower left to upper right

    public void OnMouseUp()
    {
        if (upperRightToLowerLeft == null)
        {
            upperLeftToLowerRight.ToggleConnection(!upperLeftToLowerRight.On);
        }
        else if (upperLeftToLowerRight == null) 
        {
            upperLeftToLowerRight.ToggleConnection(!upperLeftToLowerRight.On);
        }
        else
        {
            ToggleTwoConnections();
        }
    }

    public void ToggleTwoConnections()
    {
        if (!upperLeftToLowerRight.On && !upperRightToLowerLeft.On)
        {
            upperLeftToLowerRight.ToggleConnection(true);
            upperRightToLowerLeft.ToggleConnection(false);
        }
        else if (upperLeftToLowerRight.On)
        {
            upperLeftToLowerRight.ToggleConnection(false);
            upperRightToLowerLeft.ToggleConnection(true);
        }
        else if (upperRightToLowerLeft.On)
        {
            upperLeftToLowerRight.ToggleConnection(false);
            upperRightToLowerLeft.ToggleConnection(false);
        }
    }
}
