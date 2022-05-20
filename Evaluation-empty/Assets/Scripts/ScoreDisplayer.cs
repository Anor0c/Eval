using UnityEngine;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{
    TextMeshPro tmpro;
    private void Awake()
    {
        tmpro = GetComponent<TextMeshPro>();
    }
    public void SetScore(int score)
    {
        tmpro.text ="Score:"+ score;
    }
}
