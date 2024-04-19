using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    int index = 0; 
    Image _image;

    private void Awake() =>
        _image = GetComponent<Image>();

    private void Start() =>
        UpdateSprite();

    public void SwitchIcon()
    {
        index++;
        if (index > 2) index = 0;

        UpdateSprite();
        GameManager.instance.SetPlayerIndex(index);
    }

    void UpdateSprite() =>
        _image.sprite = GameManager.instance.rpsIcons[index];
}
