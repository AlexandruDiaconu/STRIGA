using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetScript : MonoBehaviour {


    [SerializeField] AudioClip[] walkingSounds;

    private AudioClip currentWalkingSound;
    private AudioSource currentWalkingAudioSource;

    // Use this for initialization
    void Start () {
        System.Random rnd = new System.Random();
        int rndIndexWalk = rnd.Next(0, walkingSounds.Length - 1);
        currentWalkingSound = walkingSounds[rndIndexWalk];
        currentWalkingAudioSource = gameObject.GetComponentInChildren<AudioSource>();
        StartCoroutine(Walking());
    }

    // Update is called once per frame
    void Update () {

    }

    private IEnumerator Walking()
    {
        if (!currentWalkingAudioSource.isPlaying)
        {
            currentWalkingAudioSource.PlayOneShot(currentWalkingSound, 1);
        }
        yield return new WaitForSeconds(1);
    }
}
