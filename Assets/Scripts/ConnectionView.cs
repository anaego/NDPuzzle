using UnityEngine;

public class ConnectionView : BaseConnectionView
{
    [SerializeField] private GameObject connection;

    public bool On 
    { 
        set 
        {
            connection.SetActive(value);
        } 
    }
    public bool Possible { get; private set; }

    public void Start()
    {
        if (connection == null)
        {
            connection = this.gameObject;
        }
    }

    public void OnMouseUp()
    {
        // TODO instead of this, callback to controller
        On = !connection.gameObject.activeSelf;
    }
}
