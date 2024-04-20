using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] bool isOpen = true;
    [SerializeField] Vector3 openPosition;
    [SerializeField] Vector3 closePosition;
    [SerializeField][Range(0f, 1f)] float lerp = 0.5f;
    [SerializeField] Color winColor;
    [SerializeField] Color loseColor;
    [SerializeField] GameObject winTitle;
    [SerializeField] GameObject loseTitle;

    Image _image;

    private void OnEnable()
    {
        GameManager.instance.OnTurnComplete += CheckForResult;
        InputManager.actions.Player.Submit.performed += OnExit; 
    }

    private void Awake() => 
        _image = GetComponent<Image>();

    private void Update()
    {
        if (isOpen)
            transform.localPosition = Vector3.Lerp(transform.localPosition, openPosition, lerp);
        else
            transform.localPosition = Vector3.Lerp(transform.localPosition, closePosition, lerp);
    }

    void CheckForResult(int playerScore, int comScore, int status)
    {
        if(playerScore == 5)
        {
            _image.color = winColor;
            winTitle.SetActive(true); 
            loseTitle.SetActive(false);
            isOpen = false;
        }
        else if (comScore == 5) 
        {
            _image.color = loseColor;
            loseTitle.SetActive(true);
            winTitle.SetActive(false); 
            isOpen = false;
        }

    }

    void OnExit(InputAction.CallbackContext ctx)
    {
        if(!isOpen)
        {
            GameManager.instance.Reset();
            isOpen = true; 
        }
    }
}
