using UnityEngine;
using System.Collections;

public class BTS : MonoBehaviour
{
	public GameObject bullet;
	private BulletTime bulletTime;

	public int sentryCount = 0;
	public int gunmanCount = 0;

	void Start()
	{
		bulletTime = GameObject.FindWithTag("Player").GetComponent<BulletTime>();

		sentryCount = GameObject.FindGameObjectsWithTag("Sentry").Length;
		gunmanCount = GameObject.FindGameObjectsWithTag("Gunman").Length;

		Debug.Log(sentryCount + "\n" + gunmanCount);
	}

	void Update()
	{

	}

	public void ShootBullet(Transform transform)
	{
		GameObject firedBullet = GameObject.Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		firedBullet.transform.localScale = new Vector3(firedBullet.transform.localScale.x * transform.localScale.x, firedBullet.transform.localScale.y, firedBullet.transform.localScale.z);
		firedBullet.GetComponent<Bullet>().direction = transform.right;

		//firedBullet.rigidbody2D.AddForce((Vector2.right * bulletTime.bulletSpeed) * -transform.localScale.x);
	}
}