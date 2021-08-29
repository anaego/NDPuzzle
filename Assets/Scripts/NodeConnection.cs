using UnityEngine;

public class NodeConnection : MonoBehaviour
{
    public PuzzleNode StartNode;
    public PuzzleNode EndNode;

    public bool On = false;

    public void ToggleConnection(bool on)
    {
        On = on;
        gameObject.SetActive(on);
    }
}
