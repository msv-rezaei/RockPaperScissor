using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip switchButtonSfx;
    [SerializeField] AudioClip winSfx, drawSfx, loseSfx; 

    AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        GameManager.instance.OnPlayerUpdate += (int index) => _source.PlayOneShot(switchButtonSfx);
        GameManager.instance.OnTurnComplete += (int playerIndex, int comIndex, int status) =>
            _source.PlayOneShot(status == 0 ? drawSfx : status == 1 ? winSfx : loseSfx); 
    }


}
