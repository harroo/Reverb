
using UnityEngine;

public class ReverbPlaySoundOn_Update : MonoBehaviour {

    public float minDelay, maxDelay;

    private float delayTemp;

    [Space()]
    public string soundName;
    public bool play3D;
    public float volumeOverride, pitchOverride;

    private void Update () {

        if (delayTemp <= 0) {

            if (play3D)
                ReverbAudioManager.Play3D(soundName, transform.position, volumeOverride, pitchOverride);
            else
                ReverbAudioManager.Play(soundName,volumeOverride, pitchOverride);

            delayTemp = ReverbAudioManager.GetSoundLength(soundName) + Random.Range(minDelay, maxDelay);

        } else delayTemp -= Time.deltaTime;
    }
}
