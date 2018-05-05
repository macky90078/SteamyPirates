using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour {
    public Transform player;
    public Vector3 Raised;

    public float ventstrength;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Raised = new Vector3(player.transform.position.x, ventstrength, player.transform.position.z);
            player.position = Raised; 
        }
    }
}
