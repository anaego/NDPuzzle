using System;
using TMPro;
using UnityEngine;

public class NodeView : MonoBehaviour
{
    public TextMeshProUGUI numberText;

    // TODO use somehow with callback?
    public void InitializeNumber(int number, int column, int row)
    {
        // TODO this is temp, remove later
        numberText.text = $"{number}; column={column}, row={row}";
    }

    public void InitializePosition(float xOffset, float yOffset)
    {
        transform.localPosition = new Vector3(
            transform.localPosition.x + xOffset,
            transform.localPosition.y + yOffset,
            transform.localPosition.z);
    }
}