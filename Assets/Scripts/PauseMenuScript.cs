using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private GameObject compass;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            content.SetActive( ! content.activeSelf );
        }
    }

    public void OnCompassToggle(Boolean value)
    {
        compass.SetActive(value);
    }
}
/* �.�. ���� ����� �� ������������
 * ���������� ���� ������:
 * - ����������� �� ���
 * - ������� �������� (�����)
 * - ³������� ������������ �� �����������
 * - �������� ������������
 * ! �������� �������� �������� �� �������
 * ������� - ����� �������� �� ���������� 
 * ��������� 
 * + ϳ������ ����� (���������� �� ���������� �������)
 * - ������ ������
 * - ������ ������ (�����, �������� ������ ����)
 */