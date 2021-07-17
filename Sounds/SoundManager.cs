using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provide audio to the game.
/// </summary>
namespace Outscal.BasicUnity2DProject
{
    public class SoundManager : MonoBehaviour
    {
        [Header("Sound Settings")]
        private static SoundManager instance;
        public static SoundManager Instance { get { return instance; } }
        [SerializeField] private AudioSource soundEffect;
        [SerializeField] private AudioSource soundMusic;
        [SerializeField] private SoundType[] Sounds;
        public bool isMute = false;
        public float Volume = 1f;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            SetVolume(0.5f);
            PlayMusic(global::Sounds.Music);
        }

        public void Mute(bool status)
        {
            isMute = status;
        }

        public void SetVolume(float volume)
        {
            Volume = volume;
            soundEffect.volume = volume;
            soundMusic.volume = volume;
        }

        public void PlayMusic(Sounds sound)
        {
            if (isMute)
            {
                return;
            }

            AudioClip clip = getSoundClip(sound);
            if (clip != null)
            {
                soundMusic.clip = clip;
                soundMusic.Play();
            }
            else
            {
                Debug.LogError("Clip not found for sound type: " + sound);
            }
        }

        public void Play(Sounds sound)
        {
            if (isMute)
            {
                return;
            }

            AudioClip clip = getSoundClip(sound);
            if (clip != null)
            {
                soundEffect.PlayOneShot(clip);
            }
            else
            {
                Debug.LogError("Clip not found for sound type: " + sound);
            }
        }

        private AudioClip getSoundClip(Sounds sound)
        {
            SoundType item = Array.Find(Sounds, i => i.soundType == sound);
            if (item != null)
            {
                return item.soundClip;
            }
            return null;
        }
    }

    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip soundClip;
    }
}

public enum Sounds
{
    buttonClick,
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
    CollectItem,
    LevelCompleted,
    PlayerHurt,
    PlayerJump,
    PlayerLand,
}