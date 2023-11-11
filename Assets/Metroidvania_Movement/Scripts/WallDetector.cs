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
        if(other.CompareTag("ClimbUp"))
        {
            _player.ClimbUp();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            _player.NotOnWall(); // flips groundeded to true
        }
    }
}
