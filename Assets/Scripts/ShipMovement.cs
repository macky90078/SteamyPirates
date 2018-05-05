using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public float m_forwardSpeed;

	[SerializeField]
	private float m_sideSpeed;

	private float m_sideMoveThreashold = 0.2f;
	private float m_sideMoveX = 0;
	private float m_iPx;


	// Use this for initialization
	void Start () 
	{
        Screen.orientation = ScreenOrientation.Portrait;
	}
	
	// Update is called once per frame
	void Update ()
    {
		transform.Translate (Input.acceleration.x, 0, 0);
		MoveShipForward ();
		//ShipGyro ();

	}

    private void MoveShipForward()
    {
		transform.Translate (Vector3.forward * ( m_forwardSpeed * Time.deltaTime));
    }

	private void ShipGyro()
	{
		m_iPx = Input.acceleration.x;

		if (Mathf.Abs (m_iPx) > m_sideMoveThreashold) 
		{
			m_sideMoveX = Mathf.Sign (m_iPx) * m_sideMoveX;
			transform.Translate (m_sideMoveX, 0, 0);
		}
	}
}
