using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {
	public float moveSpeed;
	public Vector3 input;
	public Rigidbody rb;
	public GameObject car;
	public GameObject rar;
	GUIText g = new GUIText ();

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		moveSpeed = 40f;
		car = GetComponent<GameObject> ();

		rar = Resources.Load ("Asteroid") as GameObject;
		g.transform.position = new Vector3 (1645f, 5f, 501f);
		g.text = "";

	}
	int i = 1;
	
	// Update is called once per frame
	void Update () {
		
		input = new Vector3 (Input.GetAxis("Horizontal"), 0f, Input.GetAxis ("Vertical"));

		rb.AddForce (input * moveSpeed);

		if (Input.GetKey (KeyCode.Space)) {
			rb.AddForce (new Vector3 (0f, 0f, -50f));
		}
		if (i % 30 == 0) {
			for (int i = 0; i < 2; i++) {
				GameObject ast = Instantiate (rar) as GameObject;
				ast.transform.position = new Vector3 (Random.Range (500, 1500f), Random.Range (200f, 1500f), Random.Range (0f, 1500f));
				Rigidbody n = ast.AddComponent<Rigidbody> () as Rigidbody;
				BoxCollider j = ast.AddComponent<BoxCollider> () as BoxCollider;

				n.velocity = new Vector3 (0f, -300f, 0f);
			}
		}

		i += 1;
			
	}

	void OnCollisionEnter (Collision col){
//		var force = transform.position - col.transform.position;
//		force.Normalize();
//
//		rb.AddForce(force * col.relativeVelocity.magnitude * -10f);

		if (col.gameObject.name == "Asteroid") {
			Destroy (car);
			g.text = "Game Over Bruh";

		}
	}


}
