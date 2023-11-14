using UnityEngine;
using UnityEngine.UIElements;

public class WallDetector : MonoBehaviour
{
    private PlayerMovement _player;

    private void Start()
    {
        _player = GetComponentInParent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            _player.OnWall();
        }

        if(other.CompareTag("Climbable"))
        {
            Climbable climbable = other.GetComponent<Climbable>();

            _player.OnClimbable(climbable); // obtain reference to this current climbable
        }
        if(other.CompareTag("ClimbUp")) ///NEEDS WORK
        {
            if (_player.transform.position.y > other.transform.position.y)
            {
                Debug.Log("Hit from above");
            }
            else if(_player.transform.position.y < other.transform.position.y)
            {
                _player.ClimbUp();
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            _player.NotOnWall(); // flips groundeded to true
        }
        if (other.CompareTag("Climbable"))
        {
            _player.LeftClimbable();
        }

    }
}
