using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoldManager : MonoBehaviour
{
    public Text GoldText;

    public float m_fgold;

    public GameObject Player;
    public Transform target;

    public float m_fFallSpeed = 0.01f;
    public float m_fRiseSpeed = 0.1f;

	// Use this for initialization
	void Start ()
    {
        text();
        m_fgold = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {   
        text();

        if(m_fgold > 0)
        {
            transform.Translate(-Vector3.up * (m_fgold * m_fFallSpeed * Time.deltaTime));
        }

        if(m_fgold <= 0)
        {
            transform.Translate(Vector3.up * (m_fRiseSpeed * Time.deltaTime));
        }
        

        if (Input.GetKey(KeyCode.M))
        {
            Reset();
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            DumpGold();
        }

        //if(Input.GetKey(KeyCode.S))
        //{
        //    MoveShipDownwards();
        //}
    }

    void text()
    {
        GoldText.text = "Gold: " + m_fgold;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            m_fgold = m_fgold + 10.0f;
            // need to increase wieght of ship here
            //MoveShipDownwards();
        }
    }

    public void DumpGold()
    {
        // decrease gold which will lighten ship weight
        m_fgold -= 5.0f;
    }

    void Reset()
    {
        SceneManager.LoadScene("Main");
    }

    //public void IncreaseShipWeight()
    //{
    //    m_fcurrentShipWeight += m_fcurrentShipWeight + m_fgold;
    //}

    //public void MoveShipUpwards()
    //{
    //    transform.Translate(Vector3.up * (5 * Time.deltaTime));
    //}

    //public void MoveShipDownwards()
    //{
    //    Vector3 targetPosition = target.TransformPoint(new Vector3(transform.position.x, -3, transform.position.z));
    //    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.3f);
    //    //transform.Translate(-Vector3.up * (m_fgold * Time.deltaTime));
    //}
}
