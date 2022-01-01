# Reverb
Audio in Unity made easy.

## About
Reverb was create to make the implementation of Audio and Music to your Unity-Application much less of a hassle.

# How to get started..

#### Installation..

Simply copy the [Reverb/](https://github.com/harroo/Reverb/tree/main/Reverb) folder into your Unity-Project's Assets directory.

It's recommended that you put it under a folder named "Plugins" or "Dependencies" or something of the like.

#### Setup..

##### Audio-Manager.

Create an empty Game-Object and set it up like so:
![scrot0](https://github.com/harroo/Reverb/raw/main/Images/audiomanager-example.png)

Then simply add all of your Audio-Clips to the list of Clips.

The name that they appear as will be the name that you use when playing them.

##### Music Manager.

Create an empty Game-Object and set it up like so:
![scrot1](https://raw.githubusercontent.com/harroo/Reverb/main/Images/musicmanager-example.png)

From here you need only configure the component to your needs and import your Music-Tracks the same way as you would for the Audio-Manager.

It is recommended that you set the Import-Settings on the Music-Tracks to be "Streamed" so that they don't cause longer loading times by being completely read into and stored in memory.

# Usage..

##### Playing Sounds.

```cs
// To play sound at a position.
ReverbAudioManager.Play3D("mySoundName", new Vector3(0, 1, 0));

// To play sound at a position with a volume override.
// This will specify to play at the maximum volume.
ReverbAudioManager.Play3D("mySoundName", new Vector3(0, 1, 0), 1.0f);

// To play a sound at a position with volume and pitch overrides.
// This will play at the maximum volume and with rather high pitch.
ReverbAudioManager.Play3D("mySoundName", new Vector3(0, 1, 0), 1.0f, 1.0f);


// To play sounds in the usual sort of way, simply don't specify a position.
ReverbAudioManager.Play("mySoundName");

// This will specify to play at the maximum volume.
ReverbAudioManager.Play("mySoundName", 1.0f);

// This will play at the maximum volume and with rather low pitch.
ReverbAudioManager.Play("mySoundName", 1.0f, -0.8f);
```
These can be written in ANY script, they only require there to an existing `ReverbAudioManager`.

##### Utility Components.

There are a number of "Event-Utility" Components that can be applied to a Game-Object in order to further simplify implementing Audio to your project.
To use them, simply apply them to a Game-Object and configure them to your desired setting.

# Epilogue.
Reverb is supposed to be easy to use and light-weight, therefore if you have any adjustments or improvements feel free to contribute!

If you'd like to discuss this, or any other project of mine, feel free to join my Discord-Server!
https://discord.gg/feRRmykReU

---

Spelling and Orthography correction: [Kieralia](https://github.com/kieralia)
