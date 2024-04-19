using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour
{
    [SerializeField] float cooldownTime = 1.0f;

    Button _button;

    private void Awake() => 
        _button = GetComponent<Button>();

    public void Submit()
    {
        GameManager.instance.Submit();
        StartCoroutine(Cooldown()); 
    }

    IEnumerator Cooldown()
    {
        _button.interactable = false; 
        yield return new WaitForSeconds(cooldownTime);
        _button.interactable = true;
    }
}
