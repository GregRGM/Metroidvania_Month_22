using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetector : MonoBehaviour
{
    PlayerMovement player;

    private void Start()
    {
        player = GetComponentInParent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ledge"))
        {
            Ledge ledge = other.GetComponent<Ledge>();
            player.GrabLedge(ledge);
            player.transform.position = ledge.hangPosition.transform.position;
        }
    }
}
