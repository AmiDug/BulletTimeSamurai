using UnityEngine;
using System.Collections;

public class Gunman : MonoBehaviour
{

	Vector3 bulletStartPostition;
	public GameObject bullet;
	Rigidbody2D bulletRB;
	BulletTime bulletTime;

	void Start()
	{
		bulletStartPostition = GameObject.Find("BulletStartPosition").transform.position;
		bulletTime = GameObject.FindGameObjectWithTag("Player").GetComponent<BulletTime>();
	}

	void Update()
	{

	}

	public void Shoot()
	{
		GameObject firedBullet = GameObject.Instantiate(bullet, bulletStartPostition, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
		bulletRB = firedBullet.GetComponent<Rigidbody2D>();
		bulletRB.AddForce((Vector2.right * -bulletTime.bulletSpeed) * transform.localScale.x);
	}
}