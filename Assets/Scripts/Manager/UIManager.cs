using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        bool next = !inventoryPanel.activeSelf;
        inventoryPanel.SetActive(next);
    }
}
