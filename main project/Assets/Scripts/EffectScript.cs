using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    Vector3 targetposition;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        targetposition = gameObject.transform.position + new Vector3(0, 1, 0);
        velocity = Vector3.zero;
        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetposition, ref velocity, 1f);
    }
    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(0.3f);
        Color c = gameObject.GetComponent<SpriteRenderer>().color;
        for (float i = 1f; i >= 0f; i -= 0.1f)
        {
            c.a = i;
            gameObject.GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
