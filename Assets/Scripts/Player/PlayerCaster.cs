using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCaster : MonoBehaviour
{
    public GameObject revolver_object;
    public RevolverLogic revolver;
    void Start()
    {
        revolver = revolver_object.GetComponent<RevolverLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            UseCurrentSkill();
        }   
    }

    void UseCurrentSkill()
    {
        revolver.skills[1]?.buff.ApplyBuff(revolver.skills[0], gameObject);
        revolver.skills[4]?.buff.ApplyBuff(revolver.skills[0], gameObject);
        revolver.skills[0]?.CastSkill();
        revolver.skills[4]?.buff.RemoveBuff(revolver.skills[0], gameObject);
        revolver.skills[1]?.buff.RemoveBuff(revolver.skills[0], gameObject);

        revolver.revolve();

        revolver.skills[1]?.passive.ExitPsssive(gameObject);
        revolver.skills[3]?.passive.EnterPassive(gameObject);
    }
}

