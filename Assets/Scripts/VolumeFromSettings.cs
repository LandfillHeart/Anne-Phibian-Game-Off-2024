using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class VolumeFromSettings : MonoBehaviour
    {
        private AudioSource source;
        public bool musicVolume;
        
        private void Start()
        {
            source = GetComponent<AudioSource>();
            AudioManager.Instance.VolumeSettingsChanged += () =>
            {
                source.volume = AudioManager.Instance.MusicVolume;
            };
        }
    }
}