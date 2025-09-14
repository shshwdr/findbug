using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : Singleton<SFXManager>
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBugAppear()
    {
        PlaySFX("bugappear");
    }

    public void PlayBugFailed()
    {
        PlaySFX("bugfail");
    }
    public void PlayBugSuccess()
    {
        PlaySFX("bugsuccess");
    }
    public void PlayError()
    {
        PlaySFX("bugappear");
    }
    
    
    public void PlayHint()
    {
        PlaySFX("hint");
    }

    public void PlayOpenMenu()
    {
        PlaySFX("openmenu");
    }

    public void PlayClick()
    {
        PlaySFX("buttonclick");
    }
    public void PlaySFX(string name)
    {
        audioSource.PlayOneShot(Resources.Load<AudioClip>("SFX/"+name));
    }
    
    public void PlaySFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
