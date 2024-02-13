using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundScore : MonoBehaviour
{

    AudioSource source;

    Collider2D soundTrigger;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            source.Play();
        }
    }
}
