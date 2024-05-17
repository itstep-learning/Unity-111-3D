using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    private float speed = 3f;
    private AudioSource stepsSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        stepsSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        int moveState = 0;
        float dx = Input.GetAxis("Horizontal") * speed;
        float dy = Input.GetAxis("Vertical") * speed;        
        // new Vector3(dx, 0, dy) - по Світових координатах: Х - завжди по "клітинках"
        // вимагається - рух у відповідності до повороту камери
        // осі камери задаються векторами forward та right
        Vector3 step =
            Camera.main.transform.forward * dy +
            Camera.main.transform.right * dx;
        if(step.magnitude < 0.01f)
        {
            moveState = 0;
        }
        else if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            step *= 2f;
            moveState = 2;  // RunForward
        }
        else
        {
            moveState = 1;
        }
        characterController.SimpleMove(step);
        animator.SetInteger("State", moveState);
        if(moveState == 1)
        {
            if ( ! stepsSound.isPlaying)
            {
                stepsSound.Play();
            }
        }
        else
        {
            stepsSound.Stop();
        }

        // повертаємо персонаж поглядом у напрямі камери
        Vector3 f = Camera.main.transform.forward;  // вектор камери може бути нахиленим
        f.y = 0f;   // проєкція на горизонтальну площину
        f = f.normalized;  // призводимо до довжини = 1
        this.transform.forward = f;
    }

    public void PlayOneStepSound()
    {
        // Debug.Log("Step Sound");
    }
}
/* Д.З. Композиція локації
 * Реалізувати дизайн локації - ландшафт, 
 * топологію, декорації. Використовувати
 * Asset Store
 */
