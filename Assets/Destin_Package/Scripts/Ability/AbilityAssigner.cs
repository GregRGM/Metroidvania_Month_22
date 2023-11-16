using UnityEngine;

public class AbilityAssigner : MonoBehaviour
{
    public Ability ability;

    public AbilityManager abilityManager;
    
    public void AssignAbility()
    {
        abilityManager.activeAbility = ability;
    }
}
