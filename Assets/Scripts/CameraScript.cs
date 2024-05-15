using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraAnchor;

    float angleX;  // Кути повороту камери, що є 
    float angleY;  // накопиченням зрушень миші
    Vector3 rod;   // "стрижень" - відстань від камери до точки кріплення (cameraAnchor)
    float rodFactor = 1f;  // множник віддалі від персонажа

    void Start()
    {
        angleX = transform.eulerAngles.x;   // початкові значення - 
        angleY = transform.eulerAngles.y;   // як у редакторі
        rod = this.transform.position - cameraAnchor.transform.position;
    }

    void LateUpdate()
    {
        float mx = Input.GetAxis("Mouse X");  // delta X
        float my = Input.GetAxis("Mouse Y");  // delta Y
        angleX -= my;
        angleY += mx;
        this.transform.eulerAngles = new Vector3(angleX, angleY, 0);

        Vector2 wheel = Input.mouseScrollDelta;  // wheel.y - обертання колеса миші вперед/назад, як правило wheel.y = +/- 1 
        // if (wheel != Vector2.zero) { Debug.Log(wheel); }
        if (wheel.y != 0)
        {
            if (wheel.y < 0)  // віддалення - збільшуємо множник
            {
                rodFactor += 0.05f;
                if (rodFactor > 2) rodFactor = 2f;
            }
            else  // наближення - зменшуємо множник
            {
                rodFactor -= 0.05f;
                if (rodFactor < 0) rodFactor = 0f;
            }
        }

        this.transform.position = cameraAnchor.transform.position +
            Quaternion.Euler(0,angleY,0) * rod * rodFactor;
    }
}
