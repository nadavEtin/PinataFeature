﻿using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.Utility;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class AudioManager : IAudioManager
    {
        private List<AudioSource> _audioSources;
        private AudioReference _audioRefs;
        private GameParameters _gameParams;

        public AudioManager()
        {
            _audioRefs = Resources.Load<AudioReference>("AudioReference");
            _gameParams = Resources.Load<GameParameters>("GameParams");
            _audioRefs.Init();
            _audioSources = new List<AudioSource>();
            var asContainer = new GameObject("AudioSources");
            var musicSource = asContainer.AddComponent<AudioSource>();
            musicSource.clip = _audioRefs.SingleAudioClipTypes[AudioTypes.ThemeMusic];
            musicSource.loop = true;
            musicSource.volume = _gameParams.MusicVolume;
            _audioSources.Add(musicSource);
            _audioSources.Add(asContainer.AddComponent<AudioSource>());
        }

        public void PlaySound(AudioTypes type)
        {
            //Validation that at least one clip was assigned to the audio type
            if (!_audioRefs.SingleAudioClipTypes.ContainsKey(type) && !_audioRefs.MultipleAudioClipTypes.ContainsKey(type))
            {
                Debug.LogError("missing audio type clips");
                return;
            }

            AudioClip desiredClip = null;
            if (_audioRefs.SingleAudioClipTypes.ContainsKey(type))
                desiredClip = _audioRefs.SingleAudioClipTypes[type];
            else
                desiredClip = _audioRefs.MultipleAudioClipTypes[type][Randomizer.GetNumberInRange(0, _audioRefs.MultipleAudioClipTypes[type].Count)];
            FindAvailableSource(desiredClip);
        }

        private void FindAvailableSource(AudioClip clip)
        {
            //Locate a free audio source if one is available
            var availableSource = _audioSources.FirstOrDefault(s => !s.isPlaying);
            if (availableSource != null)
            {
                availableSource.clip = clip;
                availableSource.Play();
            }
            else
            {
                //Create a new audio source if all existing ones are in use
                var newAs = _audioSources[0].gameObject.AddComponent<AudioSource>();
                _audioSources.Add(newAs);
                newAs.clip = clip;
                newAs.Play();
            }
        }
    }
}