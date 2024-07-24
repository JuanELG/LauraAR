using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public event Action OnTouchPerformed; 
    
    private InputActions inputActions = null;
    
    private Vector2 pointerPosition = Vector2.zero;
    
    private void Awake()
    {
        // ---------- SINGLETON ---------------
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        // ---------- INPUT ---------------
        inputActions = new InputActions();
    }

    private void OnEnable()
    {
        inputActions.Interactions.Enable();
        inputActions.Interactions.Touch.performed += HandleTouchPerformed;
    }

    private void OnDisable()
    {
        inputActions.Interactions.Touch.performed -= HandleTouchPerformed;
        inputActions.Interactions.Disable();
    }

    private void Update()
    {
        pointerPosition = inputActions.Interactions.PointerPosition.ReadValue<Vector2>();
    }

    private void HandleTouchPerformed(InputAction.CallbackContext context)
    {
        OnTouchPerformed?.Invoke();
    }

    public Vector2 GetPointerPosition()
    {
        return pointerPosition;
    }
}
