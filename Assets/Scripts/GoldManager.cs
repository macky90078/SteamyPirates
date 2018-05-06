using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoldManager : MonoBehaviour
{
    public Text m_tGoldText;

    public float m_fGold;

    private int m_iFingerCount;

    public GameObject Player;
    public Transform target;

    public float m_fFallSpeed = 0.01f;
    public float m_fRiseSpeed = 0.1f;
    public float m_fGoldThreshold = 50.0f;
    public float goldup = 5.0f;

    public bool m_bCollectedGold;
    public bool m_bDumpedGold;

    public bool m_bHasDumped = false;

    ShipMovement shipMovementScript;
    GoldBags goldBagScript;

    public AudioSource m_audioSource;
    public AudioClip[] goldpick;
    private AudioClip goldpickclip;
    public AudioClip[] golddump;
    private AudioClip golddumpclip;

    // Use this for initialization
    void Start ()
    {
        text();
        //m_fgold = 0.0f;
        shipMovementScript = GetComponent<ShipMovement>();
        goldBagScript = GetComponent<GoldBags>();
        m_bCollectedGold = false;
        m_bDumpedGold = false;
        m_audioSource = gameObject.GetComponent<AudioSource>();
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

        // this will alow the ship to rise continuously is gold is 0
        //if (m_fGold <= 0)
        //{
        //    transform.Translate(Vector3.up * (m_fRiseSpeed * Time.deltaTime));
        //}

        //if (m_bCollectedGold)
        //{
        //    if (m_fgold <= m_fGoldThreshold && m_fgold > 0)
        //    {
        //        transform.Translate(Vector3.up * (1 / m_fgold * 5 * m_fRiseSpeed * Time.deltaTime));
        //    }
        //    if (m_fgold > m_fGoldThreshold)
        //    {
        //        transform.Translate(-Vector3.up * (m_fgold * 0.5f * m_fFallSpeed * Time.deltaTime));
        //    }
        //}
        //if(m_bDumpedGold)
        //{
        //    if(m_fgold <= m_fGoldThreshold && m_fgold > 0)
        //    {
        //        transform.Translate(Vector3.up * (1/m_fgold * 5 * m_fRiseSpeed * Time.deltaTime));
        //    }
        //    if(m_fgold > m_fGoldThreshold)
        //    {
        //        transform.Translate(-Vector3.up * (m_fgold * 0.5f * m_fFallSpeed * Time.deltaTime));
        //    }  
        //}
        if (Input.GetKeyUp(KeyCode.W))
        {
            DumpGold();
            //StartCoroutine(DumpGoldCo());
        }
    }

    void text()
    {
        m_tGoldText.text = "Gold: " + m_fGold;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            m_fGold = m_fGold + goldup;

            int index = Random.Range(0, goldpick.Length);
            goldpickclip = goldpick[index];
            m_audioSource.clip = goldpickclip;
            m_audioSource.Play();
            goldBagScript.AddGoldBagToShip();

            shipMovementScript.m_fUpforce -= 2.5f;
            shipMovementScript.m_fDownForce += 2.5f;
            shipMovementScript.m_forwardSpeed -= 1f;
        }
    }

    public void DumpGold()
    {
        // only dump gols if we have 
        if(m_fGold > 0)
        {
            // decrease gold which will lighten ship weight
            m_fGold -= 5.0f;

            shipMovementScript.m_fDownForce -= 1.33f;
            shipMovementScript.m_fUpforce += 1.33f;
            shipMovementScript.m_forwardSpeed += 0.5f;
            goldBagScript.RemoveGoldBagFromShip();
            
            int index = Random.Range(0, golddump.Length);
            golddumpclip = golddump[index];
            m_audioSource.clip = golddumpclip;
            m_audioSource.Play();
        }
    }

    IEnumerator DumpGoldCo()
    {
         // only dump gols if we have 
        if(m_fGold > 0)
        {
            m_bHasDumped = true;
            m_bDumpedGold = true;
            m_bCollectedGold = false;
            // decrease gold which will lighten ship weight
            m_fGold -= 1.0f;
            shipMovementScript.m_forwardSpeed += 0.1f;
        }
        yield return new WaitForSeconds(0.2f);
        m_bHasDumped = false;
    }
}
