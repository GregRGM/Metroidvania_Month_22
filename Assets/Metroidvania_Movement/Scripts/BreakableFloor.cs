using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class BreakableFloor : MonoBehaviour
{
    public void Break()
    {
        Destroy(this.gameObject); // do something cooler than just destroy it. 
    }
}
