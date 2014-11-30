using UnityEngine;
using System.Collections;

public class PlayerEventHandler : MonoBehaviour
{
	Transform trans;
	Rigidbody2D rigid;
	public bool alive = true;

	// Use this for initialization
	void Start()
	{
		trans = this.transform;
		rigid = this.rigidbody2D;


	}

	// Update is called once per frame
	void Update()
	{

	}

	void KillPlayer()
	{
		Debug.Log("Player is kill :(");

		alive = false;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Bullet")
		{
			Destroy(coll.gameObject);
			KillPlayer();
		}
	}
}
