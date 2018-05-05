using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour {
    private GameObject player;
    public Vector3 m_Raised;

    public float m_fventstrength = 3f;

    public bool m_bVent;

	// Use this for initialization
	void Start () {
        m_bVent = false;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(m_bVent)
        {

        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_bVent = true;
            player.transform.Translate(Vector3.up * (m_fventstrength * Time.deltaTime));
            //Raised = new Vector3(player.transform.position.x, ventstrength, player.transform.position.z);
            //player.position = Raised; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_bVent = false;

            //Raised = new Vector3(player.transform.position.x, ventstrength, player.transform.position.z);
            //player.position = Raised; 
        }
    }
}
