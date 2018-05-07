using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ZombieBehaviourScript : MonoBehaviour {

        public float speed = 1;
        public AudioClip dyingSound;
        public AudioClip[] growlingSounds;

        private AudioClip _currentGrowlingSound;
        private AudioSource _currentGrowlingAudioSource;
        private Animator _animator;
        private GameObject _player;
        private GameManager _gameManager;
        private bool stop;

        // Use this for initialization
        private void Start () {

            System.Random rnd = new System.Random();
            int rndIndexGrowl = rnd.Next(0, growlingSounds.Length-1);

            _player = GameObject.FindGameObjectWithTag("Player");
            _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            _animator = GetComponent<Animator>();

            _currentGrowlingSound = growlingSounds[rndIndexGrowl];

            _currentGrowlingAudioSource = gameObject.GetComponentInChildren<AudioSource>();
            _currentGrowlingAudioSource.loop = true;
            _currentGrowlingAudioSource.clip = _currentGrowlingSound;
            _currentGrowlingAudioSource.Play();
            _animator.Play("walk");
        }
	
        // Update is called once per frame  
        private void Update () {
            float step = speed * Time.deltaTime;
            if (!stop)
                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, step);
            transform.LookAt(_player.transform);
        }

        public void ZombieHit()
        {
            StartCoroutine(ZombieDying());
            _gameManager.ZombieHit();
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                stop = true;
                _animator.Play("atack2");
            }
        }

        private IEnumerator ZombieDying()
        {
            _currentGrowlingAudioSource.Stop();
            _currentGrowlingAudioSource.clip = dyingSound;
            _currentGrowlingAudioSource.loop = false;
            _currentGrowlingAudioSource.Play();
            _animator.Play("death1");
            stop = true;
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
    }
}
