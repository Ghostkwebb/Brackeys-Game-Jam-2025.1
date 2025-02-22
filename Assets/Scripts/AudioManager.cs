using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip buttonClick;
    public AudioClip slimeMovement;

    void Start() {
        bgMusic.clip = backgroundMusic;
        bgMusic.loop = true;
        StartCoroutine(playBGMusic());
    }

    public void playSFX(AudioClip clip) {
        if(clip == slimeMovement) {
            SFXSource.loop = true;
        }
        SFXSource.PlayOneShot(clip);
    }

    IEnumerator playBGMusic() {
        yield return new WaitForSeconds(0.3f);
        bgMusic.Play();
    }
}
