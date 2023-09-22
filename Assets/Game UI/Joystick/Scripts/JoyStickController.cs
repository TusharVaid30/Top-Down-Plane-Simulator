using UnityEngine;
using UnityEngine.UI;

public class JoyStickController : MonoBehaviour
{
    [SerializeField] private Image joystickBase;
    [SerializeField] private Image joystick;

    private Vector3 _startPos;
    private RectTransform _rect;
    
    private void Start()
    {
        _rect = GetComponent<RectTransform>();
        _startPos = _rect.position;
    }

    private void Update()
    {
        if (PlaneCollisions.PlaneDestroyed)
        {
            HideJoystick();
            return;
        }
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                ShowJoystick();
            else if (touch.phase == TouchPhase.Canceled)
                HideJoystick();
        }

        if (Input.GetMouseButtonDown(0))
            ShowJoystick();
        else if (Input.GetMouseButtonUp(0))
            HideJoystick();
    }

    private void ShowJoystick()
    {
        _rect.position = Input.mousePosition;
        joystick.enabled = true;
        joystickBase.enabled = true;
    }

    private void HideJoystick()
    {
        _rect.position = _startPos;
        joystick.enabled = false;
        joystickBase.enabled = false;
    }
}
