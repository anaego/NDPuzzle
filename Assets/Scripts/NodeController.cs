using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController 
{
    private NodeData nodeData;
    private NodeView nodeView;

    public NodeData NodeData { get => nodeData; set => nodeData = value; }
    public NodeView NodeView { get => nodeView; set => nodeView = value; }

    public NodeController(NodeData nodeData, NodeView nodeView)
    {
        this.NodeData = nodeData;
        this.NodeView = nodeView;

    }
}
