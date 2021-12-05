
using UnityEngine;

public class ReverbPlaySoundOn_StartStop : MonoBehaviour {

    public bool playOn_Start, playOn_Destroy;

    [Space()]
    public string soundName;
    public bool play3D;
    public float volumeOverride, pitchOverride;

    private void Start () {

        if (!playOn_Start) return;

        if (play3D)
            ReverbAudioManager.Play3D(soundName, transform.position, volumeOverride, pitchOverride);
        else
            ReverbAudioManager.Play(soundName,volumeOverride, pitchOverride);
    }

    private void OnDestroy () {

        if (!playOn_Destroy) return;

        if (!gameObject.scene.isLoaded) return;

        if (play3D)
            ReverbAudioManager.Play3D(soundName, transform.position, volumeOverride, pitchOverride);
        else
            ReverbAudioManager.Play(soundName,volumeOverride, pitchOverride);
    }
}
