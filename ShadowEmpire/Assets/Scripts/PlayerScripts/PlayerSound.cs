using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

    public AudioClip SwordSlash;
    public AudioSource auidoS;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Slash()
    {
        auidoS.PlayOneShot(SwordSlash);
    }
}
