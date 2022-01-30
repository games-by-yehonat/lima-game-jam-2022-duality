using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{   
    public AudioSource sound;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {   
            sound.Play();
            LevelManager.singleton.CharacterChange();
        }
    }
}
