using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

	[SerializeField]
	private float m_forwardSpeed;

	[SerializeField]
	private float m_sideSpeed;

	private float m_sideMoveThreashold = 0.2f;
	private float m_sideMoveX;
	private float m_iPx;


	// Use this for initialization
	void Start () 
	{
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

	private void ShipGyro()
	{
		m_sideMoveX = 0;
		m_iPx = Input.acceleration.x;

		if (Mathf.Abs (m_iPx) > m_sideMoveThreashold) 
		{
			m_sideMoveX = Mathf.Sign (m_iPx) * m_sideMoveX;
			transform.Translate (m_sideMoveX, 0, 0);
		}
	}
}
