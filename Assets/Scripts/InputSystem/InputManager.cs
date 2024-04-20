using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputActions actions;

    private void Awake()
    {
        if (actions == null)
        {
            actions = new InputActions();
            actions.Enable();
        }
        else
            Destroy(this.gameObject); 
    }
}
