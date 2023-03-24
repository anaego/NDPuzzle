using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GridView gridView;
    [SerializeField] private GridSettingsScriptableObject gridSettings;

    void Start()
    {
        var gridController = new GridController(gridView, gridSettings);
        gridController.GeneratePuzzle();
    }
}
