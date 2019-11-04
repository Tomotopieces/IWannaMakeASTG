using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    static AudioManager currentAudio;

    [Header("EnvironmentSound")]
    public AudioClip mainBGM;

    [Header("EnemySound")]
    public AudioClip enemyDeathClip;

    [Header("PlayerSound")]
    public AudioClip shootClip;
    public AudioClip playerDeathClip;

    private AudioSource BGMSource;
    private AudioSource environmentSource;
    private AudioSource enemySource;
    private AudioSource playerSource;

    private void Awake()
    {
        currentAudio = this;
        DontDestroyOnLoad(gameObject);
        currentAudio.BGMSource = gameObject.AddComponent<AudioSource>();
        currentAudio.environmentSource = gameObject.AddComponent<AudioSource>();
        currentAudio.enemySource = gameObject.AddComponent<AudioSource>();
        currentAudio.playerSource = gameObject.AddComponent<AudioSource>();

        StartupAudio();
    }

    private void StartupAudio()
    {
        currentAudio.BGMSource.clip = mainBGM;
        currentAudio.BGMSource.loop = true;
        currentAudio.BGMSource.Play();
    }

    public static void PlayShootAudio()
    {
        currentAudio.playerSource.clip = currentAudio.shootClip;
        currentAudio.playerSource.Play();
    }

    public static void PlayPlayerDeathAudio()
    {
        currentAudio.playerSource.clip = currentAudio.playerDeathClip;
        currentAudio.BGMSource.Stop();
        currentAudio.playerSource.Play();
    }

    public static void PlayEnemyDeathAudio()
    {
        currentAudio.enemySource.clip = currentAudio.enemyDeathClip;
        currentAudio.enemySource.Play();
    }
}
