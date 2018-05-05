using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

	[SerializeField]
	private float m_forwardSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		MoveShipForward ();
	}

    private void MoveShipForward()
    {
		transform.Translate (Vector3.forward * ( m_forwardSpeed * Time.deltaTime));
    }
}
