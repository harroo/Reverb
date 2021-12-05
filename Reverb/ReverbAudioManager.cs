
using System;

using UnityEngine;
using UnityEngine.Audio;

public class ReverbAudioManager : MonoBehaviour {

    public AudioClip[] clips;

    private static ReverbAudioManager instance;
    private void Awake () {

        if (instance != null) {

            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start () {

        Debug.Log("[Reverb::AudioManager]: Total Pre-Loaded Audio-Clips: " + clips.Length);
    }


    private void PlaySound3D (string soundName, Vector3 position, float audioOverride, float pitchOverride) {

        AudioClip clip = Array.Find(clips, ctx => ctx.name == soundName);

        if (clip == null) {

            Debug.LogWarning("[Reverb::AudioManager]: Sound `" + soundName + "' was not found!");

            return;
        }

        AudioSource audioSource = new GameObject().AddComponent<AudioSource>();
        audioSource.clip = clip;

        audioSource.volume = Mathf.Clamp(
            ReverbSettings.volume + audioOverride, 0.0f, 1.0f
        );
        audioSource.pitch = Mathf.Clamp(
            UnityEngine.Random.Range(0.5f, 1.5f) + pitchOverride, -3.0f, 3.0f
        );

        audioSource.spatialBlend = 1.0f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.minDistance = 4.0f;
        audioSource.maxDistance = 24.0f;
        audioSource.gameObject.transform.position = position;

        audioSource.gameObject.name = "Temperary Audio Object: " + soundName;
        audioSource.Play();
        audioSource.gameObject.AddComponent<ReverbObject>().aliveTime = clip.length + 1;
    }

    private void PlaySound (string soundName, float audioOverride, float pitchOverride) {

        AudioClip clip = Array.Find(clips, ctx => ctx.name == soundName);

        if (clip == null) {

            Debug.LogWarning("[Reverb::AudioManager]: Sound `" + soundName + "' was not found!");

            return;
        }

        AudioSource audioSource = new GameObject().AddComponent<AudioSource>();
        audioSource.clip = clip;

        audioSource.volume = Mathf.Clamp(
            ReverbSettings.volume + audioOverride, 0.0f, 1.0f
        );
        audioSource.pitch = Mathf.Clamp(
            UnityEngine.Random.Range(0.7f, 1.4f) + pitchOverride, -3.0f, 3.0f
        );

        audioSource.gameObject.name = "Temperary Audio Object: " + soundName;
        audioSource.Play();
        audioSource.gameObject.AddComponent<ReverbObject>().aliveTime = clip.length + 1;
    }


    public static void Play3D (string soundName, Vector3 position) {

        instance.PlaySound3D(soundName, position, 0.0f, 0.0f);
    }
    public static void Play3D (string soundName, Vector3 position, float audioOverride) {

        instance.PlaySound3D(soundName, position, audioOverride, 0.0f);
    }
    public static void Play3D (string soundName, Vector3 position, float audioOverride, float pitchOverride) {

        instance.PlaySound3D(soundName, position, audioOverride, pitchOverride);
    }

    public static void Play (string soundName) {

        instance.PlaySound(soundName, 0.0f, 0.0f);
    }
    public static void Play (string soundName, float audioOverride) {

        instance.PlaySound(soundName, audioOverride, 0.0f);
    }
    public static void Play (string soundName, float audioOverride, float pitchOverride) {

        instance.PlaySound(soundName, audioOverride, pitchOverride);
    }


    public static float GetSoundLength (string soundName) {

        AudioClip clip = Array.Find(instance.clips, ctx => ctx.name == soundName);

        if (clip == null) {

            Debug.LogWarning("[Reverb::AudioManager]: Sound `" + soundName + "' was not found!");

            return 0.0f;

        } else return clip.length;
    }
}
