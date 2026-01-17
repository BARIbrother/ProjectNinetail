using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillRevolverUI : MonoBehaviour
{
    [SerializeField] private RectTransform revolverRoot;
    [SerializeField] private float rotateDuration = 0.2f;

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
        float targetAngle = -ANGLE_PER_SLOT * index;

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
}