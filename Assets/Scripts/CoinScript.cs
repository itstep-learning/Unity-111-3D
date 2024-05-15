using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Animator animator;
    private float initialCoinHeight;

    void Start()
    {
        animator = GetComponent<Animator>();
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
        }
    }
    public void OnDisappear()   // On Animation Finished
    {
        Vector3 newPosition = transform.position + Vector3.forward * 3f;
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