using UnityEngine;

namespace AnimalChaos.Manager
{
	public class AudioManager : MonoBehaviour
	{

		[Header("Audio Sources")]
		[SerializeField] private AudioSource bgmSource;
		[SerializeField] private AudioSource eatSFXSource;
		[SerializeField] private AudioSource dieSFXSource;
		[SerializeField] private AudioSource uiSFXSource;
		[SerializeField] private AudioSource gameOverSFXSound;

		[Header("Audio Clips")]
		[SerializeField] private AudioClip uIClickButtonClip;
		[SerializeField] private AudioClip throwFoodClip;
		[SerializeField] private AudioClip eatClip;
		[SerializeField] private AudioClip destroyAnimalClip;
		[SerializeField] private AudioClip gameOverClip;

		public AudioClip ThrowFoodClip { get => throwFoodClip; }
		public AudioClip EatClip { get => eatClip; }
		public AudioClip DestroyAnimalClip { get => destroyAnimalClip; }

		public void PlayButtonSFX ()
		{
			if (uiSFXSource.clip != uIClickButtonClip)
			{
				uiSFXSource.clip = uIClickButtonClip;
			}

			uiSFXSource.Play();
		}

		public void PlayGameOverSFX ()
		{
			gameOverSFXSound.Play();
		}

		public void PlayEatSFX ()
		{
			eatSFXSource.Play();
		}

		public void PlayAnimalFullSFX ()
		{
			dieSFXSource.Play();
		}

		internal void StopAllAudio ()
		{
			bgmSource.Stop();
			uiSFXSource.Stop();
		}
	}

}