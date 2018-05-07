using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour {

        public AudioClip dyingSound;

        // Use this for initialization
        private void Start () {
            Cursor.lockState = CursorLockMode.Locked;
        }
	
        // Update is called once per frame
        private void Update () {

            gameObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.tag == "Zombie")
                gameObject.GetComponent<AudioSource>().PlayOneShot(dyingSound, 1);
        }
    }
}
