using Audio;
using UnityEngine;

public class AudioController : IAudioController
{
    private readonly AudioDatabase _audioDatabase;
    private readonly AudioSource _sound;
    
    public AudioController(AudioDatabase audioDatabase)
    {
        _audioDatabase = audioDatabase;
        _sound = new GameObject("_Sound").AddComponent<AudioSource>();
        _sound.playOnAwake = false;
    }

    public void PlaySound(AudioClip audioClip)
    {
        if (audioClip == null)
            return;
        
        _sound.PlayOneShot(audioClip);
    } 
    
    public void PlaySound(ESoundType soundType)
    {
        var audioClip = _audioDatabase.GetAudioClip(soundType); 
        
        if (audioClip == null)
            return;
        
        _sound.PlayOneShot(audioClip);
    }
}
