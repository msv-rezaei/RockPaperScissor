using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite[] rpsIcons;
    
    public Action<Sprite> OnComIconUpdate;
    public Action<int, int, int> OnTurnComplete;
    public Action OnReset;

    int playerIndex = 0; 
    int comIndex = 0;

    int playerScore = 0;
    int comScore = 0; 

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public void SetPlayerIndex(int index)
    {
        if (index < 0 || index > 2)
            throw new ArgumentOutOfRangeException("Player index must be an integer in range of [0, 2]");

        playerIndex = index;
    }

    public void Submit()
    {
        comIndex = UnityEngine.Random.Range(0, 3);
        OnComIconUpdate.Invoke(rpsIcons[comIndex]);

        int status = 0;
        if ((comIndex == playerIndex + 1) || (comIndex == playerIndex - 2))
        {
            comScore++;
            status = -1;
        }
        else if (comIndex != playerIndex)
        {
            playerScore++;
            status = 1; 
        }

        OnTurnComplete.Invoke(playerScore, comScore, status);
    }

    public void Reset()
    {
        OnReset.Invoke();
        playerScore = comScore = 0;
        playerIndex = comIndex = 0;

        OnComIconUpdate.Invoke(rpsIcons[comIndex]);
    }
}
