using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkillRevolverUI : MonoBehaviour
{
    [SerializeField] private RectTransform revolverRoot;
    [SerializeField] private float rotateDuration = 0.2f;

    [SerializeField] private RevolverLogic revolver;
    [SerializeField] private List<Image> revolverUISlots;

    const int SLOT_COUNT = 5;
    const float ANGLE_PER_SLOT = 360f / SLOT_COUNT;

    int currentIndex = 0;
    Coroutine rotateCoroutine;

    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            RotateNext();
        }
    }
    public void RotateNext()
    {
        currentIndex = (currentIndex + 1) % 5;
        RotateToIndex(currentIndex);
    }

    void RotateToIndex(int index)
    {
        float targetAngle = ANGLE_PER_SLOT * index;

        if (rotateCoroutine != null)
            StopCoroutine(rotateCoroutine);

        rotateCoroutine = StartCoroutine(RotateSmooth(targetAngle));
    }

    IEnumerator RotateSmooth(float targetAngle)
    {
        float startAngle = revolverRoot.localEulerAngles.z;
        float time = 0f;

        while (time < rotateDuration)
        {
            time += Time.deltaTime;
            float t = time / rotateDuration;

            float angle = Mathf.LerpAngle(startAngle, targetAngle, t);
            revolverRoot.localEulerAngles = new Vector3(0, 0, angle);

            yield return null;
        }

        revolverRoot.localEulerAngles = new Vector3(0, 0, targetAngle);
    }

    public void Refresh()
    {
        for(int i = 0; i < 5; i ++)
        {
            SkillData data = revolver.skills[i].data; 

            revolverUISlots[i].enabled = data != null;
            if (data != null) 
                revolverUISlots[i].sprite = data.icon; // icon later
        }
    }
}