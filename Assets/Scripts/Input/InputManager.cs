using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public GameplayControls gc;
    private void Awake()
    {
        instance = this;
        gc = new GameplayControls();
    }


    private void OnEnable()
    {
        gc.Gameplay.Enable();
    }
    private void OnDisable()
    {
        gc.Gameplay.Disable();
    }
}
