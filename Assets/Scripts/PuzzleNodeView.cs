using TMPro;
using UnityEngine;

public class PuzzleNodeView : MonoBehaviour
{
    public TextMeshProUGUI numberText;

    public void Initialize(int number)
    {
        numberText.text = number.ToString();
    }
}