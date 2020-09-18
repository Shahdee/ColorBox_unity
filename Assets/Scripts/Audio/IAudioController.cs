    using Audio;
    using UnityEngine;

    public interface IAudioController
    {
        void PlaySound(AudioClip audioClip);
        
        void PlaySound(ESoundType soundType);
    }
