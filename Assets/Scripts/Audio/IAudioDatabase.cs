using UnityEngine;

namespace Audio
{
    public interface IAudioDatabase
    {
        AudioClip GetAudioClip(ESoundType soundType);
    }
}