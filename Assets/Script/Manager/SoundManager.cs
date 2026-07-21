using UnityEngine;

public enum eSoundType
{
    StampSound, CatSound
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Source")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip[] clips;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip)
            return;

        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    //public void PlaySFX(AudioClip clip)
    public void PlaySFX(eSoundType type)
    {
        sfxSource.PlayOneShot(clips[(int)type]);
    }
}