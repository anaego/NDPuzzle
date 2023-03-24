using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GridScriptableObject", order = 1)]
public class GridSettingsScriptableObject : ScriptableObject
{
    [SerializeField] private NodeView nodePrefab;
    [SerializeField] private ConnectionView verticalConnectionPrefab;
    [SerializeField] private ConnectionView horizontalConnectionPrefab;
    [SerializeField] private ConnectionSwitchView diagonalConnectionContainerPrefab;

    [SerializeField] private int rowNumber = 3;
    [SerializeField] private int columnNumber = 3;
    [SerializeField] private float nodeGenerationProbability = 0.9f;

    [SerializeField] private float baseXOffset = 10;
    [SerializeField] private float baseYOffset = 10;

    public NodeView NodePrefab { get => nodePrefab; }

    public float BaseXOffsetAdjusted => baseXOffset / (columnNumber + 1);
    public float BaseYOffsetAdjusted => baseYOffset / (rowNumber + 1);
    public float MainOffset => BaseXOffsetAdjusted * 2;

    public int RowNumber { get => rowNumber; }
    public int ColumnNumber { get => columnNumber; }
    public float NodeGenerationProbability { get => nodeGenerationProbability; }

    internal BaseConnectionView GetConnectionViewPrefab(ConnectionType connectionType)
    {
        switch (connectionType)
        {
            case ConnectionType.Vertical:
                return verticalConnectionPrefab;
            case ConnectionType.Horizontal:
                return horizontalConnectionPrefab;
            case ConnectionType.DiagonalSwitch:
                return diagonalConnectionContainerPrefab;
            case ConnectionType.UpperLeftToLowerRight:
            case ConnectionType.UpperRightToLowerLeft:
                return null;
            default:
                Debug.LogWarning($"Unknown connectio type: {connectionType}");
                return null;
        }
    }
}
