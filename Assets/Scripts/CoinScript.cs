using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Animator animator;
    private float initialCoinHeight;
    private AudioSource collectCoinSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        collectCoinSound = GetComponent<AudioSource>();

        initialCoinHeight = transform.position.y - 
            Terrain.activeTerrain.SampleHeight(transform.position);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsCollected", true);
            collectCoinSound.Play();
        }
    }
    public void OnDisappear()   // On Animation Finished
    {
        Vector3 newPosition ;
        do
        {
            newPosition = transform.position + new Vector3(
                Random.Range(-40f, 40f),
                0f,
                Random.Range(-40f, 40f));
        }
        while ((newPosition - transform.position).magnitude < 20f
        || (newPosition - transform.position).magnitude > 40f
        || newPosition.x < 100f
        || newPosition.x > 900f
        || newPosition.z < 100f
        || newPosition.z > 900f);

        newPosition.y = Terrain.activeTerrain.SampleHeight(newPosition) + 
            initialCoinHeight;
        transform.position = newPosition;
        animator.SetBool("IsCollected", false);
        GameState.coins += 1;
    }
}
/* Д.З. Реалізувати анімацію руху та бігу боком
 * Додати анімації до контролера
 * Забезпечити перемикання усіх станів анімації
 * Прикласти відеозапис роботи
 */