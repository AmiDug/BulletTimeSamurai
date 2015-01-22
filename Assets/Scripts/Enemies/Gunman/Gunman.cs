using UnityEngine;
using System.Collections;

public class Gunman : MonoBehaviour
{
	BTS global;
	BulletTime bulletTime;
	Transform gunTransforms;
	Transform playerT;
	public float gunRotationSpeed = 0.1f;

	//public float i = 0;
	//public int timeToShoot = 1;

	void Start()
	{
		playerT = GameObject.FindGameObjectWithTag("Player").transform;
		global = GameObject.Find("GameScripts").GetComponent<BTS>();
		bulletTime = GameObject.FindGameObjectWithTag("Player").GetComponent<BulletTime>();
		gunTransforms = this.GetComponentInChildren<Transform>();

		foreach (Transform t in gunTransforms)
		{
			if (t.gameObject.name == "Gun")
			{
				gunTransforms = t;
				return;
			}
		}
	}

	void Update()
	{
		Vector3 direction = -(playerT.position - gunTransforms.position);
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		gunTransforms.rotation = Quaternion.Slerp(gunTransforms.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * gunRotationSpeed);
	}

}