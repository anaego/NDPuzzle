using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridController
{
    // TODO provide all of that
    private GridView gridView;
    private GridSettingsScriptableObject gridSettings;

    private List<NodeController> nodeControllerCollection = new List<NodeController>();
    private List<ConnectionController> connectionControllerCollection = new List<ConnectionController>();

    public GridController(GridView gridView, GridSettingsScriptableObject gridSettings)
    {
        this.gridView = gridView;
        this.gridSettings = gridSettings;
    }

    public void GeneratePuzzle()
    {
        ResetControllers();
        // TODO: Check that connection possibilities are created correctly with empty spaces and with connections blocking each other
        for (int row = 1; row <= gridSettings.RowNumber; row++)
        {
            for (int column = 1; column <= gridSettings.ColumnNumber; column++)
            {
                if (Random.value < gridSettings.NodeGenerationProbability)
                {
                    var nodeData = new NodeData(column, row, 0);
                    var nodeView = Object.Instantiate(gridSettings.NodePrefab, gridView.NodeParent);
                    // TODO init node position
                    nodeView.InitializePosition(
                        GetGridColumnPositionOffset(column), 
                        GetGridRowPositionOffset(row));
                    var nodeController = new NodeController(nodeData, nodeView);
                    nodeControllerCollection.Add(nodeController);
                    var possibleNodeConnectionControllers = CreatePossibleConnections(
                        nodeData.PositionInGridX, nodeData.PositionInGridY, nodeData);
                    connectionControllerCollection.AddRange(possibleNodeConnectionControllers);
                }
            }
        }
        GenerateNodeNumbers(nodeControllerCollection, connectionControllerCollection);
    }

    public bool CheckPuzzleSolved()
    {
        return !nodeControllerCollection.Any(nodeController => IsConnectedCorrectly(nodeController.NodeData));
    }

    private void ResetControllers()
    {
        nodeControllerCollection.Clear();
        connectionControllerCollection.Clear();
    }

    private void GenerateNodeNumbers(List<NodeController> generatedNodes, List<ConnectionController> generatedPossibleConnections)
    {
        // TODO we created connection data for all possile connections. then we need to go thru possible connections and mark them as appearing or not. then assign desired number to node
    }

    private int CountActiveConnections(NodeData node)
    {
        var count = 0;
        // TODO rework for connection data base
        //foreach (var connection in ConnectionDataCollection)
        //{
        //    // TODO move this check to data?
        //    // TODO also simplify this check with linq
        //    if ((connection.StartNode == node || connection.EndNode == node) && connection.IsOn)
        //    {
        //        count++;
        //    }
        //}
        return count;
    }

    private bool IsConnectedCorrectly(NodeData nodeData)
    {
        return CountActiveConnections(nodeData) != nodeData.Number;
    }

    private IEnumerable<ConnectionController> CreatePossibleConnections(int column, int row, NodeData node)
    {
        if (DoesUpperNodeExist(column, row))
        {
            // TODO probs extract methods here
            var connectionData = CreateConnectionDataAbove(column, row, node);
            var connectionView = CreateAndPositionConnectionView(
                GetGridColumnPositionOffset(column),
                GetGridHalfRowPositionOffset(row), 
                ConnectionType.Vertical);
            yield return new ConnectionController(connectionData, connectionView);
        }
        if (DoesLeftNodeExist(column, row))
        {
            var connectionData = CreateConnectionDataLeft(column, row, node);
            var connectionView = CreateAndPositionConnectionView(
                GetGridHalfColumnPositionOffset(column),
                GetGridRowPositionOffset(row),
                ConnectionType.Vertical);
            yield return new ConnectionController(connectionData, connectionView);
        }
        if (DoesUpperLeftNodeExist(column, row) 
            || (DoesUpperNodeExist(column, row) && DoesLeftNodeExist(column, row)))
        {
            var connectionData = CreateDiagonalConnectionDataAboveAndLeft(column, row, node);
            var connectionView = CreateAndPositionConnectionView(
                GetGridHalfColumnPositionOffset(column), 
                GetGridHalfRowPositionOffset(row), 
                ConnectionType.DiagonalSwitch);
            yield return new ConnectionController(connectionData, connectionView);
        }
    }

    private BaseConnectionView CreateAndPositionConnectionView(float xOffset, float yOffset, ConnectionType connectionType)
    {
        var connectionView = Object.Instantiate(
            gridSettings.GetConnectionViewPrefab(connectionType),
            gridView.NodeParent);
        connectionView.InitializePosition(xOffset, yOffset);
        return connectionView;
    }

    private NodeData GetNodeAboveCoordinate(int column, int row)
    {
        return nodeControllerCollection.FirstOrDefault(node => node.NodeData.IsNodeAboveCoordinate(column, row))?.NodeData;
    }

    private NodeData GetNodeLeftOfCoordinate(int column, int row)
    {
        return nodeControllerCollection.FirstOrDefault(node => node.NodeData.IsNodeLeftOfCoordinate(column, row))?.NodeData;
    }

    private bool DoesUpperNodeExist(int column, int row)
    {
        return nodeControllerCollection.Any(node => node.NodeData.IsNodeAboveCoordinate(column, row));
    }

    private bool DoesLeftNodeExist(int column, int row)
    {
        return nodeControllerCollection.Any(node => node.NodeData.IsNodeLeftOfCoordinate(column, row));
    }

    private bool DoesUpperLeftNodeExist(int column, int row)
    {
        return nodeControllerCollection.Any(node => node.NodeData.IsNodeLeftAndAboveCoordinate(column, row));
    }

    private BaseConnectionData CreateConnectionDataAbove(int column, int row, NodeData node)
    {
        return new ConnectionData(ConnectionType.Vertical, GetNodeAboveCoordinate(column, row), node);
    }

    private BaseConnectionData CreateConnectionDataLeft(int column, int row, NodeData node)
    {
        return new ConnectionData(ConnectionType.Horizontal, GetNodeLeftOfCoordinate(column, row), node);
    }

    private BaseConnectionData CreateDiagonalConnectionDataAboveAndLeft(int column, int row, NodeData node)
    {
        var upperRightToLowerLeftConnection = CreateUpperRightToLowerLeftConnectionData(column, row);
        var upperLeftToLowerRightConnection = CreateUpperLeftToLowerRightConnectionData(column, row, node);
        return new DiagonalConnectionData(
            ConnectionType.DiagonalSwitch, upperRightToLowerLeftConnection, upperLeftToLowerRightConnection);
    }

    private ConnectionData CreateUpperRightToLowerLeftConnectionData(int column, int row)
    {
        if (!(DoesUpperNodeExist(column, row) && DoesLeftNodeExist(column, row)))
        {
            return null;
        }
        return new ConnectionData(
            ConnectionType.UpperRightToLowerLeft, 
            GetNodeAboveCoordinate(column, row), 
            GetNodeLeftOfCoordinate(column, row));
    }

    private ConnectionData CreateUpperLeftToLowerRightConnectionData(int column, int row, NodeData endNode)
    {
        if (!DoesUpperLeftNodeExist(column, row))
        {
            return null;
        }
        return new ConnectionData(
            ConnectionType.UpperLeftToLowerRight, GetNodeAboveCoordinate(column, row), endNode);
    }

    private bool CoordinateHasNode(NodeData node, int x, int y)
    {
        return nodeControllerCollection.Any(node => node.NodeData.IsAtCoordinate(x, y));
    }

    private float GetGridColumnPositionOffset(int column)
    {
        return GetGridPositionOffset(
            gridSettings.BaseXOffsetAdjusted * column, 
            -gridSettings.MainOffset);
    }

    private float GetGridRowPositionOffset(int row)
    {
        return GetGridPositionOffset(
            -gridSettings.BaseYOffsetAdjusted * row, 
            gridSettings.MainOffset);
    }

    private float GetGridHalfColumnPositionOffset(int column)
    {
        return GetGridPositionOffset(
            gridSettings.BaseXOffsetAdjusted * column - gridSettings.BaseXOffsetAdjusted / 2, 
            -gridSettings.MainOffset);
    }

    private float GetGridHalfRowPositionOffset(int row)
    {
        return GetGridPositionOffset(
            -gridSettings.BaseYOffsetAdjusted * row + gridSettings.BaseYOffsetAdjusted / 2, 
            gridSettings.MainOffset);
    }

    private float GetGridPositionOffset(float rowOrColumnOffset, float mainOffset)
    {
        return rowOrColumnOffset + mainOffset;
    }
}
