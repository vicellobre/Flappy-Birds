using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool         initialized = false;
    static AudioSource  audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.Click, Resources.Load<AudioClip>("Audios/Click"));
        audioClips.Add(AudioClipName.Dead, Resources.Load<AudioClip>("Audios/Dead"));
        audioClips.Add(AudioClipName.GameOver, Resources.Load<AudioClip>("Audios/GameOver"));
        audioClips.Add(AudioClipName.Jump, Resources.Load<AudioClip>("Audios/Jump"));
        audioClips.Add(AudioClipName.LevelUp, Resources.Load<AudioClip>("Audios/LevelUp"));
        audioClips.Add(AudioClipName.Points, Resources.Load<AudioClip>("Audios/Points"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}