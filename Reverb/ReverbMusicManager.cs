
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class ReverbMusicManager : MonoBehaviour {

    public AudioClip[] tracks;

    public bool keepAliveInstance;
    public bool fadeInAndOut;

    public float fadeTime;
    public float minDelay, maxDelay;

    private bool fadeUp, fadeDown;

    private float fadeTemp, delayTemp;

    private static ReverbMusicManager instance;

    private AudioSource audioSource;

    private void Start () {

        if (keepAliveInstance) {

            if (instance != null) {

                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        audioSource = GetComponent<AudioSource>();

        if (fadeInAndOut)
            audioSource.volume = 0.0f;
    }

    private void Update () {

        CalculateFades();

        if (delayTemp <= 0) {

            audioSource.clip = tracks[Random.Range(0, tracks.Length)];
            audioSource.Play();

            fadeTemp = audioSource.clip.length - fadeTime;
            fadeUp = true;
            fadeDown = false;

            delayTemp = audioSource.clip.length + Random.Range(minDelay, maxDelay);

        } else delayTemp -= Time.deltaTime;

        if (fadeTemp <= 0 && audioSource.volume > 0.0f) {

            fadeDown = true;
            fadeUp = false;

        } else fadeTemp -= Time.deltaTime;
    }

    private void CalculateFades () {

        if (fadeUp) {

            audioSource.volume += Time.deltaTime * (1.0f / fadeTime);

            if (audioSource.volume > 0.95f) {

                audioSource.volume = 1.0f;
                fadeUp = false;
            }
        }

        if (fadeDown) {

            audioSource.volume -= Time.deltaTime * (1.0f / fadeTime);

            if (audioSource.volume < 0.05f) {

                audioSource.volume = 0.0f;
                fadeDown = false;
            }
        }
    }
}
