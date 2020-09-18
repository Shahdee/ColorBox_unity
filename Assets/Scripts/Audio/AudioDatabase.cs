using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using Audio;

public class AudioDatabase : MonoBehaviour, IAudioDatabase
{
    [SerializeField] private List<AudioData> _audioData;
    
    [Serializable]
    public class AudioData
    {
        public ESoundType SoundType;
        public AudioClip AudioClip;
    }

    public AudioClip GetAudioClip(ESoundType soundType)
    {
        var data = _audioData.FirstOrDefault(ad => ad.SoundType == soundType);
        if (data != null)
            return data.AudioClip;

        return null;
    }
}