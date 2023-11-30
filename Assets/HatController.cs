using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    [SerializeField] private PlayerHatThrower m_HatThrower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_HatThrower.IsHatThrown)
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
            t += Time.deltaTime * m_HatThrower.ThrowSpeed;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
        m_HatThrower.IsHatThrown = false;
    }

    IEnumerator ThrowReturnCoroutine()
    {
        float t = 0;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = m_HatThrower.transform.position;
        while(t < 1)
        {
            t += Time.deltaTime * m_HatThrower.ThrowSpeed;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
        m_HatThrower.IsHatThrown = false;
    }
}
