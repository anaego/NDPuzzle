using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PuzzleCreator : MonoBehaviour
{
    public NodeConnection NodeConnectionPrefab;
    public Grid grid;

    void Start()
    {
        //var node1 = new PuzzleNode();//Instantiate(NodePrefab, grid.transform);
        //var node2 = new PuzzleNode();//Instantiate(NodePrefab, grid.transform);
        var node1 = new PuzzleNode(0, 0, 1);
        var node2 = new PuzzleNode(1, 0, 1);
        //node1.transform.position = Random.insideUnitCircle;
        //node2.transform.position = Random.insideUnitCircle;
        grid.nodes = new PuzzleNode[] { node1, node2 };
        grid.PlaceNodes();
        Debug.Log($"Puzzle solved: {grid.CheckPuzzleSolved()}");


        //var connection = Instantiate(NodeConnectionPrefab);
        //connection.StartNode = node1;
        //connection.EndNode = node2;
        //grid.connections = new NodeConnection[] { connection };
        //Debug.Log($"Puzzle solved: {grid.CheckPuzzleSolved()}");
    }
}
