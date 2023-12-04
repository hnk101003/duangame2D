using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public GameObject prefab;

    public AudioClip coin;
    private AudioSource coinsource;
    public AudioClip goomba;
    private AudioSource goombasource;
    public AudioClip breakBlock;
    private AudioSource breakBlocksource;
    public AudioClip pipe;
    private AudioSource pipesource;

    public AudioClip jump;
    private AudioSource jumpsource;
    public AudioClip megaJump;
    private AudioSource megaJumpsource;

    public AudioClip death;
    private AudioSource deathsource;
    public AudioClip flag;
    private AudioSource flagsource;
    public AudioClip win;
    private AudioSource winsource;

    public AudioClip beep;
    private AudioSource beepsource;
    public AudioClip bump;
    private AudioSource bumpsource;
    public AudioClip theme;
    private AudioSource themesource;
    // Start is called before the first frame update

    private void Awake()
    {
        instance= this;
    }

    public void PlaySound(AudioClip clip, float volume, bool isLookback)
    {
        if(clip == this.theme)
        {
            Play(clip, ref themesource, volume, isLookback);
        }
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        if (clip == this.beep)
        {
            Play(clip, ref beepsource, volume);
            return;
        }
        if (clip == this.breakBlock)
        {
            Play(clip, ref breakBlocksource, volume);
            return;
        }
        if (clip == this.bump)
        {
            Play(clip, ref bumpsource, volume);
            return;
        }
        if (clip == this.coin)
        {
            Play(clip, ref coinsource, volume);
            return;
        }
        if (clip == this.death)
        {
            Play(clip, ref deathsource, volume);
            return;
        }
        if (clip == this.flag)
        {
            Play(clip, ref flagsource, volume);
            return;
        }
        if (clip == this.pipe)
        {
            Play(clip, ref pipesource, volume);
            return;
        }
        if (clip == this.jump)
        {
            Play(clip, ref jumpsource, volume);
            return;
        }
        if (clip == this.megaJump)
        {
            Play(clip, ref megaJumpsource, volume);
            return;
        }
        if (clip == this.win)
        {
            Play(clip, ref winsource, volume);
            return;
        }
        if (clip == this.theme)
        {
            Play(clip, ref themesource, volume);
            return;
        }
    }

    private void Play(AudioClip clip, ref AudioSource audioSource, float volume, bool isLookback = false)
    {
        if(audioSource != null && audioSource.isPlaying) 
        {
            return;
        }
        audioSource = Instantiate(instance.prefab).GetComponent<AudioSource>();

        audioSource.volume = volume;
        audioSource.loop= isLookback;
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }

    public void StopSound(AudioClip clip)
    {
        if(clip == this.beep)
        {
            beepsource?.Stop();return;
        }
        if (clip == this.breakBlock)
        {
            breakBlocksource?.Stop(); return;
        }
        if (clip == this.bump)
        {
            bumpsource?.Stop(); return;
        }
        if (clip == this.coin)
        {
            coinsource?.Stop(); return;
        }
        if (clip == this.flag)
        {
            flagsource?.Stop(); return;
        }
        if (clip == this.death)
        {
            deathsource?.Stop(); return;
        }
        if (clip == this.jump)
        {
            jumpsource?.Stop(); return;
        }
        if (clip == this.megaJump)
        {
            megaJumpsource?.Stop(); return;
        }
        if (clip == this.theme)
        {
            themesource?.Stop(); return;
        }
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
