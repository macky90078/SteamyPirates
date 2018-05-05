using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoldManager : MonoBehaviour
{
    public Text GoldText;

    public float m_fgold;

    private int m_iFingerCount;

    public GameObject Player;
    public Transform target;

    public float m_fFallSpeed = 0.01f;
    public float m_fRiseSpeed = 0.1f;
    public float m_fGoldThreshold = 10.0f;

    public bool m_bCollectedGold;
    public bool m_bDumpedGold;

    public bool m_bHasDumped = false;

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

        foreach(Touch touch in Input.touches)
        {
            if(touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                m_iFingerCount++;
            }
        }

        if(m_iFingerCount > 0)
        {
            DumpGold();
            //StartCoroutine(DumpGoldCo());
        }

        if (m_bCollectedGold)
        {
            transform.Translate(-Vector3.up * (m_fgold * m_fFallSpeed * Time.deltaTime));
        }
        if(m_bDumpedGold)
        {
            if(m_fgold <= m_fGoldThreshold && m_fgold > 0)
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
            //StartCoroutine(DumpGoldCo());
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
            m_fgold = m_fgold + 5.0f;
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

    IEnumerator DumpGoldCo()
    {
         // only dump gols if we have 
        if(m_fgold > 0)
        {
            m_bHasDumped = true;
            m_bDumpedGold = true;
            m_bCollectedGold = false;
            // decrease gold which will lighten ship weight
            m_fgold -= 1.0f;
            shipMovementScript.m_forwardSpeed += 0.1f;
        }
        yield return new WaitForSeconds(0.2f);
        m_bHasDumped = false;
    }

    void Reset()
    {
        SceneManager.LoadScene("RashadsScene");
    }
}
