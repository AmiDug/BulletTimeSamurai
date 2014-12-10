using UnityEngine;
using System.Collections;

public class SwingParticle : MonoBehaviour
{
	Transform transform;
	SpriteRenderer color;
	Color opacity;

	float playerVelocity;
	public float particleSpeed = 30f;

	// Use this for initialization
	void Start()
	{
		transform = GetComponent<Transform>();
		color = GetComponent<SpriteRenderer>();
		playerVelocity = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.x;

		if (transform == null)
		{
			Debug.Log("IT GONE");
		}

		if (GetComponent<SpriteRenderer>() == null)
		{
			Debug.Log("IT GONE 2");
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.Translate(particleSpeed * transform.localScale.x * Time.deltaTime, 0f, 0f, Space.Self);

		float oldOpacity = color.color.a;
		color.color = new Color(1f, 1f, 1f, Mathf.Lerp(oldOpacity, 0f, 0.35f));

		StartCoroutine(removeTimer());
	}

	IEnumerator removeTimer()
	{
		yield return new WaitForSeconds(0.25f);

		DestroyObject(this.gameObject);
		yield return null;
	}
}
