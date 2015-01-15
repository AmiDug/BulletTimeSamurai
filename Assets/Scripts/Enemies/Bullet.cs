using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	SpriteRenderer renderer;
	Transform trans;
	[HideInInspector]
	public Vector2 direction = Vector2.zero;
	BulletTime bulletTime;

	void Start()
	{
		trans = this.transform;
		renderer = this.GetComponent<SpriteRenderer>();
		bulletTime = GameObject.FindWithTag("Player").GetComponent<BulletTime>();

		if (renderer == null)
		{
			Debug.Log("DAMN IT");
		}

	}

	void Update()
	{
		trans.Translate(direction * bulletTime.bulletSpeed * Time.deltaTime, Space.Self);

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
