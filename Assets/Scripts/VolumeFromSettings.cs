using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class VolumeFromSettings : MonoBehaviour
    {
        private AudioSource source;
        public bool musicVolume;
        
        private void OnStart()
        {
            source = GetComponent<AudioSource>();
            AudioManager.Instance.VolumeSettingsChanged += () =>
            {
                source.volume = musicVolume ? AudioManager.Instance.MusicVolume : AudioManager.Instance.SFXVolume;
            };
        }

        private void OnDestroy()
        {
            AudioManager.Instance.VolumeSettingsChanged -= () =>
            {
                source.volume = musicVolume ? AudioManager.Instance.MusicVolume : AudioManager.Instance.SFXVolume;
            };
        }
    }
}