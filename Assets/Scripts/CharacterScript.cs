using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        // new Vector3(dx, 0, dy) - �� ������� �����������: � - ������ �� "��������"
        // ���������� - ��� � ���������� �� �������� ������
        // �� ������ ��������� ��������� forward �� right
        characterController.SimpleMove(
            Camera.main.transform.forward * dy +
            Camera.main.transform.right * dx);

        // ��������� �������� �������� � ������ ������
        Vector3 f = Camera.main.transform.forward;  // ������ ������ ���� ���� ���������
        f.y = 0f;   // ������� �� ������������� �������
        f = f.normalized;  // ���������� �� ������� = 1
        this.transform.forward = f;
    }
}
/* �.�. �������� ���� ������������� ��������
 * ������ (����� ��������� �����)
 * ������� ����: �� 25..30 (����) �� -35..-40 (�����)
 * �� ���������� - ��� ��������, ��� ���� ��� ���������� 
 * ����� 360, �� ���������� - ������� 360. ��������� ����
 * ����� -360
 */
