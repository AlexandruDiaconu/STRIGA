using UnityEngine;

namespace Assets.Scripts
{
    public class LightPostSounds : MonoBehaviour {

        public AudioClip Flicker;
        public AudioClip BlowOut;
        private AudioSource _source;

        private void Start()
        {
            _source = gameObject.GetComponent<AudioSource>();
        }

        public void PlayFlickerSound()
        {
            _source.PlayOneShot( Flicker, 1 );
        }

        public void StopFlickerSound()
        {
            _source.Stop();
        }

        public void PlayBlowOutSound()
        {
            _source.PlayOneShot( BlowOut, 1 );
        }
    }
}
