using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D collision) {

		if (collision.gameObject.CompareTag("Bullet"))
		{
			Debug.Log("Damage Taken");
		}
	}

	private void OnCollisionStay2D(Collision2D collision) {

		if (collision.gameObject.name == "box")
		{
			Debug.Log("Stay");
		}
	}

	private void OnCollisionExit2D(Collision2D collision) {

		if (collision.gameObject.name == "box")
		{
			Debug.Log("Exit");
		}
	}

	


}
