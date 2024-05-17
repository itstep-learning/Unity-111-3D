using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounderScript : MonoBehaviour
{
    private AudioSource dayAmbientSound;
    private AudioSource dayMusic;

    void Start()
    {
        // ������ �� ������ ���������� ����������
        AudioSource[] sources = GetComponents<AudioSource>();
        // ������� � ����� ������� ������� � ���������
        dayMusic = sources[0];           // ������������� �������� ��������
        dayAmbientSound = sources[1];    // ���� ������ ������

        dayAmbientSound.Play();
        dayMusic.Play();
    }

    void Update()
    {
        
    }
}
