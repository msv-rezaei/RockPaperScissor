using UnityEngine;

public class SubmitButton : MonoBehaviour
{
    public void Submit() => 
        GameManager.instance.Submit();
}
