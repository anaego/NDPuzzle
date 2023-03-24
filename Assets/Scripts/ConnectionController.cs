using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionController
{
    private BaseConnectionData connectionData;
    private BaseConnectionView connectionView;

    public ConnectionController(BaseConnectionData connectionData, BaseConnectionView connectionView)
    {
        this.connectionData = connectionData;
        this.connectionView = connectionView;
    }
}
