using UnityEngine;
using UnityEngine.UI;

public class ComIcon : MonoBehaviour
{
    Image _image;

    private void Awake() =>
        _image = GetComponent<Image>();

    private void Start() =>
        GameManager.instance.OnComUpdate += UpdateIcon; 

    void UpdateIcon(int index) => 
        _image.sprite = GameManager.instance.rpsIcons[index];
}
