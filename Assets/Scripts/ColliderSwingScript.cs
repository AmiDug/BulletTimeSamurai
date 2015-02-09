using UnityEngine;
using System.Collections;

public class ColliderSwingScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		//collider = this.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	    {
		Debug.Log (other.tag);
		if(other.gameObject.tag == "Swing")
		   {
			//meObject.SetActive(false);
			collider2D.enabled = false;

		   }
		}
}