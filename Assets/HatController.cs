using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    [SerializeField] private PlayerHatThrower m_HatThrower;
    [SerializeField] float m_ThrowForce = 1000f, m_ThrowSpeed = 1000f, m_ThrowBackSpeed = 1000f, m_ThrowDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetThrowValues(float throwForce, float throwSpeed, float throwBackSpeed, float throwDistance)
    {
        m_ThrowForce = throwForce;
        m_ThrowSpeed = throwSpeed;
        m_ThrowBackSpeed = throwBackSpeed;
        m_ThrowDistance = throwDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_HatThrower.m_IsHatThrown)
        {
            /* transform.position = m_HatThrower.transform.position;
            transform.rotation = m_HatThrower.transform.rotation; */
        }
    }

    //Lerp thrown hat across Throw Distance and return to player when it reaches the end
    public void LerpHat()
    {
        StartCoroutine(ThrowForwardCoroutine());
    }

    IEnumerator ThrowForwardCoroutine()
    {
        float t = 0;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = m_HatThrower.transform.position;
        while(t < 1)
        {
            t += Time.deltaTime * m_ThrowSpeed;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
        m_HatThrower.m_IsHatThrown = false;
    }

    IEnumerator ThrowReturnCoroutine()
    {
        float t = 0;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = m_HatThrower.transform.position;
        while(t < 1)
        {
            t += Time.deltaTime * m_ThrowSpeed;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
        m_HatThrower.m_IsHatThrown = false;
    }
}
