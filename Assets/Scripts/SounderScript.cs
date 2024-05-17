using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounderScript : MonoBehaviour
{
    private AudioSource dayAmbientSound;
    private AudioSource dayMusic;

    void Start()
    {
        // Доступ до кількох однотипних компонентів
        AudioSource[] sources = GetComponents<AudioSource>();
        // Порядок у масиві відповідає порядку в інспекторі
        dayMusic = sources[0];           // рекомендується створити іменовані
        dayAmbientSound = sources[1];    // змінні замість масиву

        dayAmbientSound.Play();
        dayMusic.Play();
    }

    void Update()
    {
        
    }
}
