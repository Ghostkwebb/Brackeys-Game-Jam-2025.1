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
    public AudioClip jumpSound;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        bgMusic.clip = backgroundMusic;
        bgMusic.loop = true;
        StartCoroutine(playBGMusic());
    }

    IEnumerator playBGMusic() {
        yield return new WaitForSeconds(0.5f);
        bgMusic.Play();
    }

    public void PlaySlimeMovementSound() {
        if (!SFXSource.isPlaying && SFXSource.clip != slimeMovement) 
        {
            SFXSource.clip = slimeMovement;
            SFXSource.loop = true; 
            SFXSource.Play();
        } else if (!SFXSource.isPlaying && SFXSource.clip == slimeMovement) { 
            SFXSource.Play();
        }
    }

    public void StopSlimeMovementSound() {
        SFXSource.Stop();
        SFXSource.loop = false; 
    }

    public void PlayJumpSound() {
        playSFX(jumpSound);
    }


    public void playSFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }
}
