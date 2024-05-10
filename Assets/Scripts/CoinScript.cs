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
    }
}
/* Д.З. Забезпечити випадкове переміщення монети:
 * - не ближче ніж 20 одиниць відстані від початкового положення
 * - не далі 40
 * - не ближче 100 до країв Terrain
 * Додати анімацію рук для кліпу "Рух вперед"
 */