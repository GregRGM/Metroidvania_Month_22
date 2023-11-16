using UnityEngine;

[CreateAssetMenu]
public class Ability : ScriptableObject
{
    public FloatVariable time;
    public FloatVariable speed;

    public bool active;

    public enum AbilityState
    {
        dash,
        teleport,
        timeSlow,
        becomeInvisible
    }

    public AbilityState abilityState;

    public void DoAbility()
    {
        switch (abilityState)
        {
            case AbilityState.dash:
                DashAbility();
                break;
            case AbilityState.teleport:
                TeleportAbility();
                break;
            case AbilityState.timeSlow:
                break;
            case AbilityState.becomeInvisible:
                BecomeInvisibleAbility();
                break;
        }
    }

    public void DashAbility()
    {
        Debug.Log("Dash performed");
    }

    public void TeleportAbility()
    {
        Debug.Log("Teleport performed");
    }

    public void TimeSlowAbility()
    {
        Debug.Log("Time Slow performed");
    }

    public void BecomeInvisibleAbility()
    {
        Debug.Log("Become Invisible Performed");
    }
}
