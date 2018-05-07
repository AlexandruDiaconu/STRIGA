using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GunAction : MonoBehaviour
    {

        public ParticleSystem bloodSplatter;

        private Animation _animation;

        // Use this for initialization
        private void Start ()
        {
            _animation = GetComponent<Animation>();
        }
	
        // Update is called once per frame
        private void Update () {

            Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                _animation.Play();
                RaycastHit zombie;
                if (Physics.Raycast(gameObject.transform.position, fwd, out zombie, Mathf.Infinity))
                {
                    if (zombie.collider.tag == "Zombie")
                    {
                        bloodSplatter = Instantiate(bloodSplatter);
                        bloodSplatter.transform.position = zombie.point;
                        bloodSplatter.transform.LookAt(transform);
                        zombie.transform.GetComponent<ZombieBehaviourScript>().ZombieHit();

                    }
                }
            } 
        }
    }
}
