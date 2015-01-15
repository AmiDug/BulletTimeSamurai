using UnityEngine;
using System.Collections;

public class BTS : MonoBehaviour
{
	public GameObject bullet;
	private BulletTime bulletTime;

	void Start()
	{
		bulletTime = GameObject.FindWithTag("Player").GetComponent<BulletTime>();
	}

	void Update()
	{

	}

	public void ShootBullet(Transform transform)
	{
		GameObject firedBullet = GameObject.Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		firedBullet.transform.localScale = new Vector3(transform.localScale.x, 0.55f, 1f);
		firedBullet.GetComponent<Bullet>().direction = transform.right;

		//firedBullet.rigidbody2D.AddForce((Vector2.right * bulletTime.bulletSpeed) * -transform.localScale.x);
	}
}