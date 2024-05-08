using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private CharacterController characterController;
    private float speed = 3f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float dx = Input.GetAxis("Horizontal") * speed;
        float dy = Input.GetAxis("Vertical") * speed;
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            dx *= 2f;
            dy *= 2f;
        }
        // new Vector3(dx, 0, dy) - по Світових координатах: Х - завжди по "клітинках"
        // вимагається - рух у відповідності до повороту камери
        // осі камери задаються векторами forward та right
        characterController.SimpleMove(
            Camera.main.transform.forward * dy +
            Camera.main.transform.right * dx);

        // повертаємо персонаж поглядом у напрямі камери
        Vector3 f = Camera.main.transform.forward;  // вектор камери може бути нахиленим
        f.y = 0f;   // проєкція на горизонтальну площину
        f = f.normalized;  // призводимо до довжини = 1
        this.transform.forward = f;
    }
}
/* Д.З. Композиція локації
 * Реалізувати дизайн локації - ландшафт, 
 * топологію, декорації. Використовувати
 * Asset Store
 */
