using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _music;

    [SerializeField]
    private AudioSource _efx;

    [SerializeField]
    private AudioClip[] _clips;

    public void Play(int idClip = 0, float volume = 1)
    {
        _efx.PlayOneShot(_clips[idClip], volume);
    }

    public void PlayInterface()
    {
        Play(0);
    }

    public void VolumeEfx(float volume)
    {
        _efx.volume = volume;

        Play(0, 0.3f);
    }

    public void VolumeMusic(float volume)
    {
        _music.volume = volume;
    }
}
