using TMPro;
using UnityEngine;

public class InfoText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;

    Animator _animator;

    private void Awake() => 
        _animator = GetComponent<Animator>();

    private void Start() =>
        GameManager.instance.OnTurnComplete += Notify;

    void Notify(int playerScore, int comScore, int status)
    {
        switch(status)
        {
            case -1:
                infoText.text = "COM WON!";
                break;
            case 0:
                infoText.text = "DRAW!";
                break;
            case 1:
                infoText.text = "PLAYER WON!";
                break; 
        }
        _animator.SetTrigger("Notify");
    }
}
