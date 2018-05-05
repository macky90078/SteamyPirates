using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    public GameObject Player;
    public Transform CamPos;
    public Vector3 NewCamPos;

    public float CamHeight;
    public float CamHorizontal;
    
    // Use this for initialization
	void Start () {
        CamHeight = 1.18f; 
        CamHorizontal = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        NewCamPos = new Vector3(CamHorizontal, Player.transform.position.y, Player.transform.position.z);
        CamPos.position = NewCamPos;
	}
}
