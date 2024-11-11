using UnityEngine;

public interface IAudioService
{
    void PlayMusic(string key, float volume);
    void StopMusic();
    void PlaySFX(string key, float volume, Transform source);
    void SetVolume(float volume);
}
