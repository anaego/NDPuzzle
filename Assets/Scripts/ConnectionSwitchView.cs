using UnityEngine;

public class ConnectionSwitchView : BaseConnectionView
{
    public ConnectionView UpperLeftToLowerRight;
    public ConnectionView UpperRightToLowerLeft;

    public void OnMouseUp()
    {
        // TODO callback from controller
        //if (UpperRightToLowerLeft == null)
        //{
        //    UpperLeftToLowerRight.ToggleConnection(!UpperLeftToLowerRight.On);
        //}
        //else if (UpperLeftToLowerRight == null) 
        //{
        //    UpperLeftToLowerRight.ToggleConnection(!UpperLeftToLowerRight.On);
        //}
        //else
        //{
        //    ToggleTwoConnections();
        //}
    }

    // TODO refactor
    public void ToggleTwoConnections()
    {
        //if (!UpperLeftToLowerRight.On && !UpperRightToLowerLeft.On)
        //{
        //    UpperLeftToLowerRight.ToggleConnection(true);
        //    UpperRightToLowerLeft.ToggleConnection(false);
        //}
        //else if (UpperLeftToLowerRight.On)
        //{
        //    UpperLeftToLowerRight.ToggleConnection(false);
        //    UpperRightToLowerLeft.ToggleConnection(true);
        //}
        //else if (UpperRightToLowerLeft.On)
        //{
        //    UpperLeftToLowerRight.ToggleConnection(false);
        //    UpperRightToLowerLeft.ToggleConnection(false);
        //}
    }
}
