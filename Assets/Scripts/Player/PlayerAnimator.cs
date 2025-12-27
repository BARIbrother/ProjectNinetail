using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    PlayerState State;
    void Start()
    {
        animator = GetComponent<Animator>();
        State = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("direction", State.direction);
    }
}
