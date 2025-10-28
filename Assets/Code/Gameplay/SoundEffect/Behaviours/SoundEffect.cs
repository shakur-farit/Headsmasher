using UnityEngine;

namespace Assets.Code.Gameplay.SoundEffect.Behaviours
{
  public class SoundEffect : MonoBehaviour
  {
    [SerializeField] private AudioSource _audioSource;

    private int _lifetime;

    public void Setup(AudioClip audioClip, int lifetime)
    {
      _audioSource.clip = audioClip;

      _audioSource.Play();
      _lifetime = lifetime;
    }

    public int GetLifetime() =>
    _lifetime;
  }
}