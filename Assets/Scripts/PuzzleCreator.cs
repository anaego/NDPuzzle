using UnityEngine;

public class PuzzleCreator : MonoBehaviour
{
    public NodeConnection NodeConnectionPrefab;
    public Grid grid;

    void Start()
    {
        //var node1 = new PuzzleNode();//Instantiate(NodePrefab, grid.transform);
        //var node2 = new PuzzleNode();//Instantiate(NodePrefab, grid.transform);
        var node1 = new PuzzleNode(1, 1, 1);
        var node2 = new PuzzleNode(1, 2, 1);
        var node3 = new PuzzleNode(1, 3, 1);
        var node4 = new PuzzleNode(2, 1, 1);
        var node5 = new PuzzleNode(2, 2, 1);
        var node6 = new PuzzleNode(2, 3, 1);
        var node7 = new PuzzleNode(3, 1, 1);
        var node8 = new PuzzleNode(3, 2, 1);
        var node9 = new PuzzleNode(3, 3, 1);
        //node1.transform.position = Random.insideUnitCircle;
        //node2.transform.position = Random.insideUnitCircle;
        grid.nodes = new PuzzleNode[] { node1, node2, node3, node4, node5, node6, node7, node8, node9 };
        grid.PlaceNodes();
        Debug.Log($"Puzzle solved: {grid.CheckPuzzleSolved()}");


        //var connection = Instantiate(NodeConnectionPrefab);
        //connection.StartNode = node1;
        //connection.EndNode = node2;
        //grid.connections = new NodeConnection[] { connection };
        //Debug.Log($"Puzzle solved: {grid.CheckPuzzleSolved()}");
    }
}
