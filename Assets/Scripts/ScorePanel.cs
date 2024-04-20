using UnityEngine;
using TMPro; 

public class ScorePanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI comScoreText;

    private void OnEnable()
    {
        GameManager.instance.OnTurnComplete += UpdateScoreTexts;
        GameManager.instance.OnReset += Reset;
    }

    void UpdateScoreTexts(int playerScore, int comScore, int status)
    {
        playerScoreText.text = playerScore.ToString(); 
        comScoreText.text = comScore.ToString();
    }

    private void Reset()
    {
        playerScoreText.text = "0";
        comScoreText.text = "0"; 
    }
}
