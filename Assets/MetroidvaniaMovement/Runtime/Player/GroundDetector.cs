using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private PlayerMovement _player;

    private void Start()
    {
        _player = GetComponentInParent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        BreakableFloor breakableFloor = other.GetComponent<BreakableFloor>();

        if (other.CompareTag("Ground") && breakableFloor != null) // if you hit the ground and it has a breakablefloor component
        {
            if (_player.Stomping() == true) // if you are stomping
            {
                //_player.IsGrounded();
                breakableFloor.Break();//break the floor 
                _player.BounceOff(); // bounce up
            }
            else if(_player.Stomping() == false)
            {
                _player.IsGrounded();
            }
        }
        else if(other.CompareTag("Ground") && breakableFloor == null) // if its just a ground floor
        {
            _player.IsGrounded(); // you're grounded
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            _player.NotGrounded(); // flips groundeded to true
        }
    }
}
