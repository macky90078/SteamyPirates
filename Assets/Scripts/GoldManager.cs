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
    public float m_fGoldThreshold = 10.0f;
    public float goldup = 5.0f;

    public bool m_bCollectedGold;
    public bool m_bDumpedGold;

    ShipMovement shipMovementScript;

	// Use this for initialization
	void Start ()
    {
        text();
        m_fgold = 0.0f;
        shipMovementScript = GetComponent<ShipMovement>();
        m_bCollectedGold = false;
        m_bDumpedGold = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        text();

        int fingerCount = 0;
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                DumpGold();
            }
        }

        if(m_bCollectedGold)
        {
            transform.Translate(-Vector3.up * (m_fgold * m_fFallSpeed * Time.deltaTime));
        }
        if(m_bDumpedGold)
        {
            if(m_fgold <= m_fGoldThreshold)
            {
                transform.Translate(Vector3.up * (1/m_fgold * m_fRiseSpeed * Time.deltaTime));
            }
            if(m_fgold > m_fGoldThreshold)
            {
                transform.Translate(-Vector3.up * (m_fgold * 0.5f * m_fFallSpeed * Time.deltaTime));
            }  
        }
        

        if (Input.GetKey(KeyCode.M))
        {
            Reset();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            DumpGold();
        }
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
            m_fgold = m_fgold + goldup;
            m_bCollectedGold = true;
            m_bDumpedGold = false;
            shipMovementScript.m_forwardSpeed -= 0.1f;
        }
    }

    public void DumpGold()
    {
        // only dump gols if we have 
        if(m_fgold > 0)
        {
            m_bDumpedGold = true;
            m_bCollectedGold = false;
            // decrease gold which will lighten ship weight
            m_fgold -= 1.0f;
            shipMovementScript.m_forwardSpeed += 0.1f;
        }
    }

    void Reset()
    {
        SceneManager.LoadScene("RashadsScene");
    }
}
