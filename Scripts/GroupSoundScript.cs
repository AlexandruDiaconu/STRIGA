using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupSoundScript : MonoBehaviour {

    [SerializeField] AudioClip groupSound;

    private AudioSource _source;

    // Use this for initialization
    private void Start () {

        _source = gameObject.GetComponent<AudioSource>();
        _source.clip = groupSound;
    }
	
	// Update is called once per frame
    private void Update () {
		
	}

    public void playGroupSounds()
    {
        _source.Play();
    }

    public void reduceVolume()
    {
        _source.volume = 0.2f;
    }
}
