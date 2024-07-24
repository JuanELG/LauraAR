using UnityEngine;

public class ARInteraction : MonoBehaviour
{
    private void OnEnable()
    {
        InputManager.Instance.OnTouchPerformed += CreateObject;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnTouchPerformed -= CreateObject;
    }

    private void CreateObject()
    {
        Vector2 touchScreenPosition = InputManager.Instance.GetPointerPosition();
        //CreateRaycast
        
    }
}
