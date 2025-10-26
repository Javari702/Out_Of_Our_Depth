using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [Header("Volumes")]
    [Range(0f, 1f)][SerializeField] float musicVolume = 1f;
    [Range(0f, 1f)][SerializeField] float sfxVolume = 1f;

    private bool isMuted;

    void Awake()
    {
        makeAudioManagerSingleton();
        makeMusicSourceLoopable();
        applyVolumes();
    }

    public void playSFX(AudioClip clip, float pitchLowRange, float pitchHighRange, float volume, float time = 0)
    {
        if (clip == null) return;

        AudioSource tempSource = gameObject.AddComponent<AudioSource>();
        tempSource.clip = clip;
        tempSource.volume = volume;
        tempSource.pitch = UnityEngine.Random.Range(pitchLowRange, pitchHighRange);
        tempSource.Play();

        if (time > 0f)
        {
            Destroy(tempSource, time);
        }
        else
        {
            Destroy(tempSource, clip.length / tempSource.pitch);
        }
    }

    public void playMusic(AudioClip clip)
    {
        if (clip == null) return;
        if (musicSource.clip == clip && musicSource.isPlaying) return;
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void setMuted(bool muted)
    {
        isMuted = muted;
        AudioListener.volume = muted ? 0f : 1f;
    }

    private void makeAudioManagerSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void makeMusicSourceLoopable()
    {
        musicSource.loop = true;
    }

    private void applyVolumes()
    {
        musicSource.volume = musicVolume;
        sfxSource.volume = sfxVolume;
    }
}
