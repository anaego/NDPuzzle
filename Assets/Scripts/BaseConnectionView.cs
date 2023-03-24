using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConnectionView : MonoBehaviour
{
    public void InitializePosition(float xOffset, float yOffset)
    {
        transform.localPosition = new Vector3(
            transform.localPosition.x + xOffset,
            transform.localPosition.y + yOffset,
            transform.localPosition.z);
    }
}
