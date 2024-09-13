using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [Header("Theme Music")]
    [SerializeField] private AudioSource ThemeMusicSource;
    [SerializeField] private AudioClip[] ThemeGameplayMusicClips;

    [Space(15)]
    [Header("UI Sounds")]
    [SerializeField] private AudioSource UISource;
    [SerializeField] private AudioClip TimerClip;
    [SerializeField] private AudioClip TimerUpClip;

    [Space(15)]
    [Header("Player Sounds")]
    [SerializeField] private AudioSource PlayerSource;
    [SerializeField] private AudioClip WalkClip;

    [Space(15)]
    [Header("Gameplay Sounds")]
    [SerializeField] private AudioSource GameplaySource1;
    [SerializeField] private AudioSource GameplaySource2;
    [SerializeField] private AudioSource GameplaySource3;
    [SerializeField] private AudioClip ItemSpawnClip;
    [SerializeField] private AudioClip ItemPickClip;
    [SerializeField] private AudioClip ItemDroppedClip;

    private void Awake()
    {
        instance = this;
    }

    // Theme Music
    public void StartGamePlayThemeMusic()
    {
        PlaySound(ThemeMusicSource, ThemeGameplayMusicClips[Random.Range(0, ThemeGameplayMusicClips.Length)]);
    }
    public void StopGamePlayThemeMusic()
    {
        StopSound(ThemeMusicSource);
    }


    // UI Sounds
    public void PlayTimer()
    {
        UISource.loop = true;
        PlaySound(UISource, TimerClip);
    }
    public void PlayerTimerUp()
    {
        UISource.loop = false;
        PlaySound(UISource, TimerUpClip);
    }


    // Player Sounds
    public void StartPlayerWalkSound()
    {
        if (!PlayerSource.isPlaying)
        {
            PlaySound(PlayerSource, WalkClip);
        }
        else
        {
            UnPausedSound(PlayerSource);
        }
    }
    public void StopPlayerWalkSound()
    {
        PauseSound(PlayerSource);
    }


    // Gameplay Sounds
    public void SpawnSound()
    {
        if (!GameplaySource1.isPlaying)
        {
            PlaySound(GameplaySource1, ItemSpawnClip);
        }
        else if (GameplaySource2.isPlaying)
        {
            PlaySound(GameplaySource2, ItemSpawnClip);
        }
        else
        {
            PlaySound(GameplaySource3, ItemSpawnClip);
        }
    }
    public void PickSound()
    {
        if (!GameplaySource1.isPlaying)
        {
            PlaySound(GameplaySource1, ItemPickClip);
        }
        else if (GameplaySource2.isPlaying)
        {
            PlaySound(GameplaySource2, ItemPickClip);
        }
        else
        {
            PlaySound(GameplaySource3, ItemPickClip);
        }
    }
    public void DropSound()
    {
        if (!GameplaySource1.isPlaying)
        {
            PlaySound(GameplaySource1, ItemDroppedClip);
        }
        else if (GameplaySource2.isPlaying)
        {
            PlaySound(GameplaySource2, ItemDroppedClip);
        }
        else
        {
            PlaySound(GameplaySource3, ItemDroppedClip);
        }
    }











    // Play Sounds Private Functions for Organization
    private void PlaySound(AudioSource AS, AudioClip AC)
    {
        AS.clip = AC;
        AS.Play();
    }
    private void PauseSound(AudioSource AS)
    {
        AS.Pause();
    }
    private void UnPausedSound(AudioSource AS)
    {
        AS.UnPause();
    }
    private void StopSound(AudioSource AS)
    {
        AS.Stop();
    }
}
