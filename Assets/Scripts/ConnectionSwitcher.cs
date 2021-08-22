using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionSwitcher : MonoBehaviour
{
    public NodeConnection connection1;
    public NodeConnection connection2;

    public void OnMouseUp()
    {
        if (!connection1.gameObject.activeInHierarchy && !connection1.gameObject.activeInHierarchy)
        {
            connection1.gameObject.SetActive(true);
        }
    }
}
