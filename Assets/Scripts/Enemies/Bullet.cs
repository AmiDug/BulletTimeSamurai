using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    SpriteRenderer renderer;
    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();

        if (renderer == null)
        {
            Debug.Log("DAMN IT");
        }

    }

    void Update()
    {
        if (!renderer.isVisible)
        {
            DestroyObject(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

    }

    void Remove()
    {
        DestroyObject(this.gameObject);
    }
}
