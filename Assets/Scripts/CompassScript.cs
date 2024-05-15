using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassScript : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private Image arrow;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 v = coin.transform.position - character.transform.position;
        v.y = 0;
        arrow.transform.eulerAngles = new Vector3 (0, 0, 
            Vector3.SignedAngle(
                character.transform.forward,
                v,
                Vector3.down)
        );

    }
}
