using UnityEngine;

public class DragLayer : MonoBehaviour
{
    public static DragLayer Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
