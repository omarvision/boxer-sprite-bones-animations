using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingBodyPart : MonoBehaviour
{
    public string sndHit = "punch bag"; //the name of the audio file in resource folder
    private bool _canHit = false;
    private AudioSource audioHit = null;

    //this is a property with ONLY a set
    public bool CanHit
    {
        set
        {
            //when the caller sets the value we turn the Collider2D on/off appropriately
            _canHit = value;
            if (_canHit == true)
            {
                this.GetComponent<Collider2D>().enabled = true;
            }
            else
            {
                this.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
    private void Start()
    {
        //make and reference the audio component (punch sound)
        audioHit = CreateAudioSource(sndHit);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //play the punch sound
        audioHit.Play();
    }
    private AudioSource CreateAudioSource(string filename)
    {
        //add an audio component to the gameobject
        AudioSource audio = this.gameObject.AddComponent<AudioSource>();

        //load a sound into the audio component
        audio.clip = Resources.Load<AudioClip>(filename);

        return audio;
    }
}