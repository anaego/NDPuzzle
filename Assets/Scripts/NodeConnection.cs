using UnityEngine;

public class NodeConnection : MonoBehaviour
{
    public PuzzleNode startNode;
    public PuzzleNode endNode;
    public GameObject connection;

    public bool On { get; private set; } = false;

    public void Start()
    {
        if (connection == null)
        {
            connection = this.gameObject;
        }
    }

    public void ToggleConnection(bool on)
    {
        this.On = on;
        connection.SetActive(on);
    }

    public void OnMouseUp()
    {
        ToggleConnection(!On);
    }
}
