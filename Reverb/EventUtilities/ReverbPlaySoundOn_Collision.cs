
using System;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ReverbPlaySoundOn_Collision : MonoBehaviour {

    public string[] activatingTags;

    public bool playOn_CollisionEnter, playOn_CollisionExit;

    [Space()]
    public string soundName;
    public bool play3D;
    public float volumeOverride, pitchOverride;

    private void OnCollisionEnter (Collision collision) {

        if (activatingTags.Length != 0)
            if (Array.IndexOf(activatingTags, collision.collider.tag) <= -1)
                return;

        if (play3D)
            ReverbAudioManager.Play3D(soundName, transform.position, volumeOverride, pitchOverride);
        else
            ReverbAudioManager.Play(soundName,volumeOverride, pitchOverride);
    }

    private void OnCollisionExit (Collision collision) {

        if (activatingTags.Length != 0)
            if (Array.IndexOf(activatingTags, collision.collider.tag) <= -1)
                return;

        if (play3D)
            ReverbAudioManager.Play3D(soundName, transform.position, volumeOverride, pitchOverride);
        else
            ReverbAudioManager.Play(soundName,volumeOverride, pitchOverride);
    }
}
