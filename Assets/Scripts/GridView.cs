using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridView : MonoBehaviour
{
    [SerializeField] private RectTransform gridBackground;
    [SerializeField] private Transform nodeParent;

    public Transform NodeParent => nodeParent;

    public void ShowPuzzleResult(bool isSolved)
    {
        // TODO change how we show result later
        if (isSolved)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Not solved yet!");
        }
    }
}

