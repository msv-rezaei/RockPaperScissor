using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite[] rpsIcons;
    
    // Events
    public Action<int> OnComUpdate;                 // Invoked when comIndex is changed
    public Action<int> OnPlayerUpdate;              // Invoked when playerIndex is changed
    public Action<int, int, int> OnTurnComplete;    // Invoked when a turn is completed
    public Action OnReset;                          // Invoked when a new game is started

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

        OnPlayerUpdate.Invoke(playerIndex);
    }

    public void Submit()
    {
        comIndex = UnityEngine.Random.Range(0, 3);
        OnComUpdate.Invoke(comIndex);

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

        OnComUpdate.Invoke(comIndex);
    }
}
