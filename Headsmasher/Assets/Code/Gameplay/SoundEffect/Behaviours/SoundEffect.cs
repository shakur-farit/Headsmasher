using UnityEngine;

namespace Assets.Code.Gameplay.SoundEffect.Behaviours
{
  public class SoundEffect : MonoBehaviour
  {
    [SerializeField] private AudioSource _audioSource;

    public void Setup(AudioClip audioClip)
    {
      _audioSource.clip = audioClip;

      _audioSource.Play();
    }
  }
}