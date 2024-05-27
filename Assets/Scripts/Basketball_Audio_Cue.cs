using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball_Audio_Cue : MonoBehaviour
{
    public AudioClip basketball; // The audio clip to be played
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            Debug.Log("Flor");
            audioSource.clip = basketball;
            audioSource.Play();
        }
    }
}
