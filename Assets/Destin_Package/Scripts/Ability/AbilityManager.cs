using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public int currentSlot = 4;

    public AbilitySlotRuntimeSet runtimeSet;
    public Ability activeAbility;
   
    private void Start()
    {
        runtimeSet.Items[currentSlot].BecomeSelected();
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentSlot > 0)
            {
                runtimeSet.Items[currentSlot].BecomeDeselected();
                currentSlot--;
                runtimeSet.Items[currentSlot].BecomeSelected();
            }

            else
            {
                runtimeSet.Items[currentSlot].BecomeDeselected();
                currentSlot = 4;
                runtimeSet.Items[currentSlot].BecomeSelected();
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentSlot < 4)
            {
                runtimeSet.Items[currentSlot].BecomeDeselected();
                currentSlot++;
                runtimeSet.Items[currentSlot].BecomeSelected();
            }

            else
            {
                runtimeSet.Items[currentSlot].BecomeDeselected();
                currentSlot = 0;
                runtimeSet.Items[currentSlot].BecomeSelected();
            }
        }

        if (Input.GetKeyDown("e"))
        {
            DoAbility();
        }
    }

    void DoAbility()
    {
        if (runtimeSet.Items[currentSlot].gameObject.GetComponent<AbilitySlot>().abiltity != null)
        {
            runtimeSet.Items[currentSlot].gameObject.GetComponent<AbilitySlot>().abiltity.DoAbility();
        }
    }

    public void AddNewAbility()
    {
        for (int i = runtimeSet.Items.Count - 1; i >= 0; i--)
        {
            if (runtimeSet.Items[i].abiltity == null)
            {
                runtimeSet.Items[i].abiltity = activeAbility;
                break;
            }
        }
    }
}
