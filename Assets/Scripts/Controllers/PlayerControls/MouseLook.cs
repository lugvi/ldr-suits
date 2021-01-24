using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{

    public Transform playerCamera;

    public float lookSensitivity;

    public CursorLockMode lockCursor;
    GameplayControls controls;
    Vector2 rotation;

    int lockState;

    private void OnEnable()
    {
        controls = InputManager.instance.gc;
        controls.Gameplay.Look.performed += OnLook;
        controls.Gameplay.UnlockMouse.performed += (_) => Cursor.lockState = (CursorLockMode)(lockState++ % 3); ;
    }

    private void OnDisable()
    {
        controls.Gameplay.Look.performed -= OnLook;
    }

    void OnLook(InputAction.CallbackContext c)
    {
        Vector2 delta = c.ReadValue<Vector2>();
        rotation.x -= delta.y * lookSensitivity * Time.deltaTime;
        rotation.x = Mathf.Clamp(rotation.x, -90, 90);
        playerCamera.localEulerAngles = rotation;
        transform.Rotate(Vector3.up, delta.x * lookSensitivity * Time.deltaTime);
    }

}