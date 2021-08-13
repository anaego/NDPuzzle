using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public PuzzleNodeView NodePrefab;
    public PuzzleNode[] nodes;
    public NodeConnection[] connections;
    public RectTransform gridBackground;
    [SerializeField]
    private Transform startTransform;


    public int rowNumber = 3;
    public int columnNumber = 3;

    private float xOffset = 1;
    private float yOffset = 1;

    public void Awake()
    {
        //xOffset = (columnNumber + 1);
        //yOffset = (rowNumber + 1);
    }

    public int CountConnectedNodes(PuzzleNode node)
    {
        var count = 0;
        foreach (var connection in connections)
        {
            if (connection.StartNode == node || connection.EndNode == node) count++;
        }
        return count;
    }

    public void PlaceNodes()
    {
        Vector2 offset = startTransform.localPosition;
        for (int column = 1; column <= columnNumber; column++)
        {
            for (int row = 1; row <= rowNumber; row++)
            {
                var node = nodes.FirstOrDefault(puzzleNode => puzzleNode.positionInGridX == row && puzzleNode.positionInGridY == column);
                if (node != null)
                {
                    // nodes are instantiated in the upper left corner
                    var instnode = Instantiate(NodePrefab, this.transform, false);
                    var nodeScale = instnode.transform.localScale.x;
                    instnode.transform.position = offset + new Vector2(
                        ((xOffset + nodeScale) * column) ,
                        ((yOffset + nodeScale) * row)
                    );
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

