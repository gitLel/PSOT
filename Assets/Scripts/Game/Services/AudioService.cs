using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AudioService : IAudioService
{
    private const float FadeDuration = 2.0f;

    private readonly Dictionary<string, AudioClip> audioMap;
    private AudioSource music;
    private Tweener tweenFadeIn;
    private Tweener tweenFadeOut;
    private float volumeMusic = 1f;
    private float volumeSfx = 1f;

    public AudioService(Audio.Config audioConfig)
    {
        audioMap = new Dictionary<string, AudioClip>(audioConfig.AudioClips.Count);

        for(var i = 0; i < audioConfig.AudioClips.Count; i++)
        {
            var clip = audioConfig.AudioClips[i];
            audioMap.Add(clip.name, clip);
        }
    }
    public void SetVolume(float volume)
    {
        volumeSfx = volume;
        volumeMusic = volume;
    }
    public void PlaySFX(string key, float volume, Transform source)
    {
        if (!audioMap.TryGetValue(key, out var clip))
        {
            Debug.LogWarning($"Couldn't find '{key}' AudioClip.");
            return;
        }

        var vol = volumeSfx * volume;

        if (vol <= 0f)
            return;

        AudioSource.PlayClipAtPoint(clip, source.position, vol);
    }
    public void PlayMusic(string key, float volume)
    {
        throw new System.NotImplementedException();
    }

    public void StopMusic()
    {
        throw new System.NotImplementedException();
    }
}
