using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    PlayerState State;

    void Awake()
    {
        State = GetComponent<PlayerState>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(Keyboard.current.wKey.isPressed)
        {
            transform.position += new Vector3(0,1,0) * State.stats.moveSpeed * Time.deltaTime;
            State.direction = 0;
        }
        if(Keyboard.current.aKey.isPressed)
        {
            transform.position += new Vector3(-1,0,0) * State.stats.moveSpeed * Time.deltaTime;
            State.direction = 3;
        }
        if(Keyboard.current.sKey.isPressed)
        {
            transform.position += new Vector3(0,-1,0) * State.stats.moveSpeed * Time.deltaTime;
            State.direction = 2;
        }
        if(Keyboard.current.dKey.isPressed)
        {
            transform.position += new Vector3(1,0,0) * State.stats.moveSpeed * Time.deltaTime;
            State.direction = 1;
        }
    }
}
