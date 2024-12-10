using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnTrigger : MonoBehaviour
{
    public AudioClip chop_meat_sound;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UnchoppedMeat")
        {
            if (source != null){
                source.PlayOneShot(chop_meat_sound);
            }
            
        }
    }
}
