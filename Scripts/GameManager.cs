using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour {

        public GameObject _zombie;
        public int ZombieCount;
        public Text text;
        public Image backImage;
        public GameObject group1;
        public GameObject group2;
        public GameObject gun;

        private GameObject player;
        private const int minDistanceToSpawn = 30;
        private const int maxDistanceToSpawn = 32;
        private GroupSoundScript firstZombieGroup;
        private GroupSoundScript secondZombieGroup;

        private int _count;
        private int _zombieHitCount;

        private bool _level2;

        private GameObject _mainLightObject;
        private GameObject _mainLight;

        private GameObject _headLight;

        private GameObject _light1;
        private GameObject _light2;
        private GameObject _light3;
        private GameObject _light4;
        private GameObject _light5;
        private GameObject _light6;
        private GameObject _light7;
        private GameObject _light8;


        // Use this for initialization
        private void Start ()
        {
            player = GameObject.FindGameObjectWithTag("Player");

            _light1 = GameObject.FindGameObjectWithTag("light1");
            _light2 = GameObject.FindGameObjectWithTag("light2");
            _light3 = GameObject.FindGameObjectWithTag("light3");
            _light4 = GameObject.FindGameObjectWithTag("light4");
            _light5 = GameObject.FindGameObjectWithTag("light5");
            _light6 = GameObject.FindGameObjectWithTag("light6");
            _light7 = GameObject.FindGameObjectWithTag("light7");
            _light8 = GameObject.FindGameObjectWithTag("light8");

            _mainLightObject = GameObject.FindGameObjectWithTag("mainlight");
            _mainLight = GameObject.FindGameObjectWithTag("mainlight").GetComponentInChildren<Light>().gameObject;

            _headLight = GameObject.FindGameObjectWithTag("headlight");

            firstZombieGroup = group1.GetComponent<GroupSoundScript>();
            secondZombieGroup = group2.GetComponent<GroupSoundScript>();

            StartCoroutine(StartStory());
        }
	
        // Update is called once per frame
        private void Update () {
		
        }

        private IEnumerator StartStory()
        {
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(3);

            text.text = "It has been more than two decades since\nthe S.T.R.I.G.A. virus started to spread";

            StartCoroutine(FadeTo(1.0f, 1f, false));
            yield return new WaitForSeconds(7);
            StartCoroutine(FadeTo(0.0f, 1f, false));


            yield return new WaitForSeconds(2);

            text.text = "Media tried to warn the\npeople but it was too late";

            StartCoroutine(FadeTo(1.0f, 1f, false));
            yield return new WaitForSeconds(6);
            StartCoroutine(FadeTo(0.0f, 1f, false));

            yield return new WaitForSeconds(2);

            text.text = "The disease caused instant death,\nbut the bodies were still functional";

            StartCoroutine(FadeTo(1.0f, 1f, false));
            yield return new WaitForSeconds(6);
            StartCoroutine(FadeTo(0.0f, 1f, false));

            yield return new WaitForSeconds(2);

            text.text = "They started to act violently and attack people";

            StartCoroutine(FadeTo(1.0f, 1f, false));
            yield return new WaitForSeconds(6);
            StartCoroutine(FadeTo(0.0f, 1f, false));

            yield return new WaitForSeconds(2);

            text.text = "Quarantine programs failed and\n98% of humanity became infected";

            StartCoroutine(FadeTo(1.0f, 1f, false));
            yield return new WaitForSeconds(6);
            StartCoroutine(FadeTo(0.0f, 1f, false));

            yield return new WaitForSeconds(2);

            text.text = "A global defense organization\nwas created to fight them";

            StartCoroutine(FadeTo(1.0f, 1f, false));
            yield return new WaitForSeconds(6);
            StartCoroutine(FadeTo(0.0f, 1f, false));

            yield return new WaitForSeconds(2);

            text.text = "But it failed";

            StartCoroutine(FadeTo(1.0f, 1f, false));
            yield return new WaitForSeconds(3);
            StartCoroutine(FadeTo(0.0f, 1f, false));

            yield return new WaitForSeconds(2);

            text.text = "We still have weapons ... but not enough bullets";

            StartCoroutine(FadeTo(1.0f, 1f, false));
            yield return new WaitForSeconds(6);
            StartCoroutine(FadeTo(0.0f, 5f, true));

            yield return new WaitForSeconds(3);
            gun.SetActive(true);
            StartCoroutine(Level1());
        }

        public void ZombieHit()
        {
            _zombieHitCount++;
            switch (_zombieHitCount)
            {
                case 5:
                    StartCoroutine(Level2());
                    break;
                case 10:
                    StartCoroutine(Level3());
                    break;
            }
        }

        private IEnumerator Level1()
        {
            yield return new WaitForSeconds(1);
            firstZombieGroup.playGroupSounds();

            yield return new WaitForSeconds(1);
            _light1.GetComponentInChildren<Light>().gameObject.SetActive(false);
            _light1.GetComponentInChildren<ParticleSystem>().Play();
            _light1.GetComponent<LightPostSounds>().PlayBlowOutSound();

            yield return new WaitForSeconds(1);
            _light2.GetComponentInChildren<Light>().gameObject.SetActive(false);
            _light2.GetComponentInChildren<ParticleSystem>().Play();
            _light2.GetComponent<LightPostSounds>().PlayBlowOutSound();

            yield return new WaitForSeconds(1.3f);
            _light3.GetComponentInChildren<Light>().gameObject.SetActive(false);
            _light3.GetComponentInChildren<ParticleSystem>().Play();
            _light3.GetComponent<LightPostSounds>().PlayBlowOutSound();

            yield return new WaitForSeconds(0.7f);
            _light4.GetComponentInChildren<Light>().gameObject.SetActive(false);
            _light4.GetComponentInChildren<ParticleSystem>().Play();
            _light4.GetComponent<LightPostSounds>().PlayBlowOutSound();

            yield return new WaitForSeconds(1.2f);
            _light5.GetComponentInChildren<Light>().gameObject.SetActive(false);
            _light5.GetComponentInChildren<ParticleSystem>().Play();
            _light5.GetComponent<LightPostSounds>().PlayBlowOutSound();

            yield return new WaitForSeconds(1);
            _mainLightObject.GetComponent<LightPostSounds>().PlayFlickerSound();
            _mainLight.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            _mainLightObject.GetComponent<LightPostSounds>().StopFlickerSound();

            firstZombieGroup.reduceVolume();
            secondZombieGroup.playGroupSounds();

            yield return new WaitForSeconds(2f);
            _light6.GetComponentInChildren<Light>().gameObject.SetActive(false);
            _light6.GetComponentInChildren<ParticleSystem>().Play();
            _light6.GetComponent<LightPostSounds>().PlayBlowOutSound();

            yield return new WaitForSeconds(0.6f);
            _light7.GetComponentInChildren<Light>().gameObject.SetActive(false);
            _light7.GetComponentInChildren<ParticleSystem>().Play();
            _light7.GetComponent<LightPostSounds>().PlayBlowOutSound();

            yield return new WaitForSeconds(1f);
            _light8.GetComponentInChildren<Light>().gameObject.SetActive(false);
            _light8.GetComponentInChildren<ParticleSystem>().Play();
            _light8.GetComponent<LightPostSounds>().PlayBlowOutSound();

            yield return new WaitForSeconds(2);
            Destroy(GameObject.FindGameObjectWithTag("outobjects"));
            yield return new WaitForSeconds(5);
            firstZombieGroup.reduceVolume();

            // Light coming back
            _mainLightObject.GetComponent<LightPostSounds>().PlayFlickerSound();
            _mainLight.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            _mainLight.SetActive(false);
            _mainLightObject.GetComponent<LightPostSounds>().StopFlickerSound();
            yield return new WaitForSeconds(0.5f);
            _mainLightObject.GetComponent<LightPostSounds>().PlayFlickerSound();
            _mainLight.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            _mainLight.SetActive(false);
            _mainLightObject.GetComponent<LightPostSounds>().StopFlickerSound();
            yield return new WaitForSeconds(0.6f);
            _mainLightObject.GetComponent<LightPostSounds>().PlayFlickerSound();
            _mainLight.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            _mainLight.SetActive(false);
            _mainLightObject.GetComponent<LightPostSounds>().StopFlickerSound();
            yield return new WaitForSeconds(0.6f);
            _mainLightObject.GetComponent<LightPostSounds>().PlayFlickerSound();
            _mainLight.SetActive(true);
            yield return new WaitForSeconds(1f);
            _mainLightObject.GetComponent<LightPostSounds>().StopFlickerSound();

            yield return new WaitForSeconds(3);
            StartCoroutine(SpawnZombies());
            yield return new WaitForSeconds(10);
        }

        private IEnumerator Level2()
        {

            // Light coming back
            _mainLightObject.GetComponent<LightPostSounds>().PlayFlickerSound();
            _mainLight.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            _mainLight.SetActive(false);
            _mainLightObject.GetComponent<LightPostSounds>().StopFlickerSound();
            yield return new WaitForSeconds(0.5f);
            _mainLightObject.GetComponent<LightPostSounds>().PlayFlickerSound();
            _mainLight.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            _mainLight.SetActive(false);
            _mainLightObject.GetComponent<LightPostSounds>().StopFlickerSound();
            yield return new WaitForSeconds(0.6f);
            _mainLightObject.GetComponent<LightPostSounds>().PlayFlickerSound();
            _mainLight.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            _mainLight.SetActive(false);
            _mainLightObject.GetComponent<LightPostSounds>().StopFlickerSound();
            yield return new WaitForSeconds(0.6f);
            _mainLightObject.GetComponent<LightPostSounds>().PlayFlickerSound();
            _mainLight.SetActive(true);
            yield return new WaitForSeconds(1f);
            _mainLightObject.GetComponent<LightPostSounds>().StopFlickerSound();
            _mainLight.SetActive(false);
            _mainLightObject.GetComponent<LightPostSounds>().PlayBlowOutSound();

            yield return new WaitForSeconds(5);
            _headLight.GetComponent<Light>().enabled = true;
            _headLight.GetComponent<LightPostSounds>().PlayFlickerSound();
            yield return new WaitForSeconds(3);
            _count = 0;
            StartCoroutine(SpawnZombies());
        }

        private IEnumerator Level3()
        {

            // Light coming back
            _headLight.GetComponent<LightPostSounds>().PlayFlickerSound();
            _headLight.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(0.2f);
            _headLight.GetComponent<Light>().enabled = false;
            _headLight.GetComponent<LightPostSounds>().StopFlickerSound();
            yield return new WaitForSeconds(0.5f);
            _headLight.GetComponent<LightPostSounds>().PlayFlickerSound();
            _headLight.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(0.3f);
            _headLight.GetComponent<Light>().enabled = false;
            _headLight.GetComponent<LightPostSounds>().StopFlickerSound();
            yield return new WaitForSeconds(0.6f);
            _headLight.GetComponent<LightPostSounds>().PlayFlickerSound();
            _headLight.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(0.2f);
            _headLight.GetComponent<Light>().enabled = false;
            _headLight.GetComponent<LightPostSounds>().StopFlickerSound();
            yield return new WaitForSeconds(0.6f);
            _headLight.GetComponent<LightPostSounds>().PlayFlickerSound();
            _headLight.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(1f);
            _headLight.GetComponent<LightPostSounds>().StopFlickerSound();
            _headLight.GetComponent<Light>().enabled = false;
            _headLight.GetComponent<LightPostSounds>().PlayBlowOutSound();

            yield return new WaitForSeconds(5);
            StartCoroutine(SpawnZombies());
        }

        private IEnumerator FadeTo(float value, float time, bool background)
        {
            float alpha = text.color.a;
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
            {
                Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, value, t));
                text.color = newColor;

                if (background)
                {
                    Color newBackColor = new Color(0, 0, 0, Mathf.Lerp(alpha, value, t));
                    backImage.color = newBackColor;
                }  

                yield return null;
            }
        }

        private void MakeZombies()
        {
            System.Random rnd = new System.Random();
            int rndNo = rnd.Next(minDistanceToSpawn, maxDistanceToSpawn);
            int rndNoBetw = rnd.Next(1,3) == 1 ? Random.Range(0, 13) : Random.Range(155, 360);

            GameObject prefabZombie = Instantiate(_zombie, player.transform.position, Quaternion.Euler(0, rndNoBetw, 0));
            prefabZombie.transform.position = prefabZombie.transform.forward * rndNo;
        }


        private IEnumerator SpawnZombies()
        {
            secondZombieGroup.reduceVolume();
            while (true)
            {
                if (_count < ZombieCount)
                {
                    MakeZombies();
                    _count++;
                }
                else
                {
                    yield break;
                }
                yield return new WaitForSeconds(5);
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}
