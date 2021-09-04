using System.Linq;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public PuzzleNodeView nodePrefab;
    public NodeConnection verticalConnectionPrefab;
    public NodeConnection horizontalConnectionPrefab;
    public ConnectionSwitcher diagonalConnectionPrefab;
    public PuzzleNode[] nodes;
    public NodeConnection[] connections;
    public RectTransform gridBackground;
    //public Transform startTransform;

    public int rowNumber = 3;
    public int columnNumber = 3;

    private float xOffset = 10;
    private float yOffset = 10;
    private float mainOffset = 5f;
    private float nodeWidth = 1.5f;

    public void Awake()
    {
        xOffset = xOffset / (columnNumber + 1);
        yOffset = yOffset / (rowNumber + 1);
        mainOffset = xOffset * 2;
        // Presuming that node is 1 unit in length
        nodeWidth = nodePrefab.gameObject.transform.localScale.x;
    }

    public int CountConnectedNodes(PuzzleNode node)
    {
        var count = 0;
        foreach (var connection in connections)
        {
            if (connection.startNode == node || connection.endNode == node) count++;
        }
        return count;
    }

    public void PlaceNodes()
    {
        //Vector2 offset = startTransform.localPosition;
        for (int column = 1; column <= columnNumber; column++)
        {
            for (int row = 1; row <= rowNumber; row++)
            {
                var node = nodes.FirstOrDefault(puzzleNode => puzzleNode.positionInGridX == row && puzzleNode.positionInGridY == column);
                if (node != null)
                {
                    var instnode = Instantiate(nodePrefab, this.transform, false);
                    instnode.Initialize(node.number);
                    instnode.transform.localPosition = new Vector3(
                        instnode.transform.localPosition.x
                            + xOffset * column
                            - mainOffset,
                        instnode.transform.localPosition.y
                            - yOffset * row
                            + mainOffset,
                        instnode.transform.localPosition.z);
                    if (nodes.Any(puzzleNode => puzzleNode.positionInGridX == row - 1 && puzzleNode.positionInGridY == column))
                    {
                        // connection above
                        var connectionBelow = Instantiate(verticalConnectionPrefab, this.transform, false);
                        connectionBelow.transform.localPosition = new Vector3(
                            connectionBelow.transform.localPosition.x
                                + xOffset * column
                                - mainOffset,
                            connectionBelow.transform.localPosition.y
                                - yOffset * row
                                + mainOffset
                                + yOffset / 2,
                            connectionBelow.transform.localPosition.z);
                    }
                    if (nodes.Any(puzzleNode => puzzleNode.positionInGridX == row && puzzleNode.positionInGridY == column - 1))
                    {
                        // connection to the left
                        var connectionLeft = Instantiate(horizontalConnectionPrefab, this.transform, false);
                        connectionLeft.transform.localPosition = new Vector3(
                            connectionLeft.transform.localPosition.x
                                + xOffset * column
                                - mainOffset
                                - xOffset / 2,
                            connectionLeft.transform.localPosition.y
                                - yOffset * row
                                + mainOffset,
                            connectionLeft.transform.localPosition.z);
                    }
                    // diagonal connections
                    var upperLeftNodeExists = nodes.Any(puzzleNode => puzzleNode.positionInGridX == row - 1 && puzzleNode.positionInGridY == column - 1);
                    var upperNodeExists = nodes.Any(puzzleNode => puzzleNode.positionInGridX == row - 1 && puzzleNode.positionInGridY == column);
                    var leftNodeExists = nodes.Any(puzzleNode => puzzleNode.positionInGridX == row && puzzleNode.positionInGridY == column - 1);
                    if (upperLeftNodeExists || (upperNodeExists && leftNodeExists))
                    {
                        var diagonalConnection = Instantiate(diagonalConnectionPrefab, this.transform, false);
                        diagonalConnection.transform.localPosition = new Vector3(
                            diagonalConnection.transform.localPosition.x
                                + xOffset * column
                                - mainOffset
                                - xOffset / 2,
                            diagonalConnection.transform.localPosition.y
                                - yOffset * row
                                + mainOffset 
                                + yOffset / 2,
                            diagonalConnection.transform.localPosition.z);
                        if (!upperLeftNodeExists)
                        {
                            diagonalConnection.upperLeftToLowerRight = null;
                        }
                        else
                        {
                            diagonalConnection.upperLeftToLowerRight.startNode = nodes.First(puzzleNode => puzzleNode.positionInGridX == row - 1 && puzzleNode.positionInGridY == column);
                            diagonalConnection.upperLeftToLowerRight.endNode = node;
                        }
                        if (!(upperNodeExists && leftNodeExists))
                        {
                            diagonalConnection.upperRightToLowerLeft = null;
                        }
                        else
                        {
                            diagonalConnection.upperRightToLowerLeft.startNode = nodes.First(puzzleNode => puzzleNode.positionInGridX == row - 1 && puzzleNode.positionInGridY == column);
                            diagonalConnection.upperRightToLowerLeft.endNode = nodes.First(puzzleNode => puzzleNode.positionInGridX == row && puzzleNode.positionInGridY == column - 1);
                        }
                    }
                }
            }
        }
    }

    public bool CheckPuzzleSolved()
    {
        foreach (var puzzleNode in nodes)
        {
            if (CountConnectedNodes(puzzleNode) != puzzleNode.number) return false;
        }
        return true;
    }
}

