using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

	void Start()
	{
		StartCoroutine(removeTimer());
	}

	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		
	}

	IEnumerator removeTimer()
	{
		yield return new WaitForSeconds(4.0f);

		DestroyObject(this.gameObject);
		yield return null;
	}
}
