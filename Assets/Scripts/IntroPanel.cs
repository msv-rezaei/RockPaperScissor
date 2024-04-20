using UnityEngine;
using UnityEngine.InputSystem; 

public class IntroPanel : MonoBehaviour
{
    [SerializeField] bool isOpen = false;
    [SerializeField] Vector3 openPosition;
    [SerializeField] Vector3 closePosition;
    [SerializeField][Range(0f, 1f)] float lerp = 0.5f;

    private void OnEnable()
    {
        InputManager.actions.Player.Submit.performed += (InputAction.CallbackContext ctx) => isOpen = true;
        InputManager.actions.Player.Exit.performed += (InputAction.CallbackContext ctx) => isOpen = false;
    }

    private void Update()
    {
        if (isOpen)
            transform.localPosition = Vector3.Lerp(transform.localPosition, openPosition, lerp);
        else
            transform.localPosition = Vector3.Lerp(transform.localPosition, closePosition, lerp); 
    }
}
