using System;

namespace DefaultNamespace
{
    public class AudioManager
    {
        private static AudioManager instance;

        public static AudioManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AudioManager();
                }

                return instance;
            }
        }

        public Action VolumeSettingsChanged;
        
        public float MusicVolume = 1f;
        public float SFXVolume = 1f;

        
        public void ChangeAudioSettings(float newMusicVolume, float newSFXVolume)
        {
            MusicVolume = newMusicVolume / 100;
            SFXVolume = newSFXVolume / 100;
            VolumeSettingsChanged?.Invoke();
        }
        
        
        
        
    }
}