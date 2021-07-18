using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public PuzzleNodeView NodePrefab;
    public PuzzleNode[] nodes;
    public NodeConnection[] connections;

    public int rowNumber = 3;
    public int columnNumber = 3;

    private float xOffset = 100;
    private float yOffset = 100;

    public void Awake()
    {
        xOffset = this.gameObject.GetComponent<RectTransform>().rect.width / (columnNumber + 1);
        yOffset = this.gameObject.GetComponent<RectTransform>().rect.width / (rowNumber + 1);
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
        for (int column = 1; column <= columnNumber; column++)
        {
            for (int row = 1; row <= rowNumber; row++)
            {
                var node = nodes.FirstOrDefault(puzzleNode => puzzleNode.positionInGridX == row && puzzleNode.positionInGridY == column);
                if (node != null)
                {
                    // nodes are instantiated in the upper left corner
                    var instnode = Instantiate(NodePrefab, this.transform, false);
                    instnode.transform.localPosition = new Vector3(
                        instnode.transform.localPosition.x + xOffset * column - instnode.GetComponent<RectTransform>().rect.width * 0.5f, 
                        instnode.transform.localPosition.y - yOffset * row + instnode.GetComponent<RectTransform>().rect.width * 0.5f, 
                        instnode.transform.localPosition.z);
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

