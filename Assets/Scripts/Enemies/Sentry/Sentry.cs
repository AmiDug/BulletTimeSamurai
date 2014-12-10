using UnityEngine;
using System.Collections;

public class Sentry : MonoBehaviour
{
	GameObject player;
	public GameObject bullet;
	Vector3 bulletPosition;
	Rigidbody2D bulletRB;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindWithTag("Player");
		bulletPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.35f, transform.localPosition.z);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			FireBullet();
		}
	}

	void FireBullet()
	{
		GameObject firedBullet = GameObject.Instantiate(bullet, bulletPosition, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;

		bulletRB = firedBullet.GetComponent<Rigidbody2D>();
		bulletRB.AddForce((Vector2.right * -20000f) * transform.localScale.x);
	}
}
