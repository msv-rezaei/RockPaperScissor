using UnityEngine;
using UnityEngine.UI;

public class ComIcon : MonoBehaviour
{
    Image _image;

    private void Awake() =>
        _image = GetComponent<Image>();

    private void Start() =>
        GameManager.instance.OnComIconUpdate += UpdateIcon; 

    void UpdateIcon(Sprite newIcon) => 
        _image.sprite = newIcon;
}
