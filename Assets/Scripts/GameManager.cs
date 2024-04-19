using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite[] rpsIcons;
    
    public Action<Sprite> OnComIconUpdate;
    public Action<int, int> OnTurnComplete;

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

        if ((comIndex == playerIndex+1) || (comIndex == playerIndex-2))
            comScore++; 
        else if(comIndex != playerIndex)
            playerScore++;

        OnTurnComplete.Invoke(playerScore, comScore);
    }
}
