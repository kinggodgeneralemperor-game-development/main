using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrownPlantScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        float randomForcex = Random.Range(-120, 120);
        float randomForcey = Random.Range(70, 120);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomForcex, randomForcey));
        Invoke("triggerDestroy", 3);
    }

    void triggerDestroy()
    {
        Destroy(gameObject);
    }
}
