using UnityEngine;
using TMPro; 

public class ScorePanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI comScoreText;

    private void Start() =>
        GameManager.instance.OnTurnComplete += UpdateScoreTexts;

    void UpdateScoreTexts(int playerScore, int comScore)
    {
        playerScoreText.text = playerScore.ToString(); 
        comScoreText.text = comScore.ToString();
    }
}
