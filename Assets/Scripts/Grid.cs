using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public PuzzleNodeView NodePrefab;
    public PuzzleNode[] nodes;
    public NodeConnection[] connections;
    public int width;
    public int height;
    public int xOffset = 100;
    public int yOffset = 100;

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
        for (int column = 0; column < height; column++)
        {
            for (int row = 0; row < height; row++)
            {
                var node = nodes.FirstOrDefault(puzzleNode => puzzleNode.positionInGridX == row && puzzleNode.positionInGridY == column);
                if (node != null)
                {
                    // nodes are instantiated in the upper left corner
                    var instnode = Instantiate(NodePrefab, this.transform, false);
                    instnode.transform.localPosition = new Vector3(
                        instnode.transform.localPosition.x + xOffset * row, 
                        instnode.transform.localPosition.y + yOffset * column, 
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

