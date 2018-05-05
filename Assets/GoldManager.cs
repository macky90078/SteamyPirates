using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoldManager : MonoBehaviour {

    public Text GoldText;

    public int gold;

    public GameObject Player;

	// Use this for initialization
	void Start () {
        text();
        gold = 0;
	}
	
	// Update is called once per frame
	void Update () {
        text();

        if (Input.GetKey(KeyCode.M))
        {
            Reset();
        }
    }

    void text()
    {
        GoldText.text = "Gold: " + gold;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            gold = gold + 10;
        }
    }

    void Reset()
    {
        SceneManager.LoadScene("Main");
    }
}
