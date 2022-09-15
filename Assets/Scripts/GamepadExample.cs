using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadExample : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        if (Gamepad.current != null)
        {
            Debug.Log("Gamepadはあります");
        }
        if (Joystick.current != null)
        {
            Debug.Log("Joystickはあります");
        }
        if (Keyboard.current != null)
        {
            Debug.Log("Keyboardはあります");
        }

        if (Mouse.current != null)
        {
            Debug.Log("Mouseはあります");
        }
    }

    void Update()
    {
        if (Gamepad.current != null)
        {
            if (Gamepad.current.buttonNorth.wasPressedThisFrame)
            {
                Debug.Log("Button Northが押された！");
            }
            if (Gamepad.current.buttonSouth.wasReleasedThisFrame)
            {
                Debug.Log("Button Southが離された！");
            }
        }


    }

    void OnGUI()
    {
        if (Gamepad.current == null) return;

        GUILayout.Label($"leftStick: {Gamepad.current.leftStick.ReadValue()}");
        GUILayout.Label($"buttonNorth: {Gamepad.current.buttonNorth.isPressed}");
        GUILayout.Label($"buttonSouth: {Gamepad.current.buttonSouth.isPressed}");
        GUILayout.Label($"buttonEast: {Gamepad.current.buttonEast.isPressed}");
        GUILayout.Label($"buttonWest: {Gamepad.current.buttonWest.isPressed}");
        GUILayout.Label($"leftShoulder: {Gamepad.current.leftShoulder.ReadValue()}");
        GUILayout.Label($"leftTrigger: {Gamepad.current.leftTrigger.ReadValue()}");
        GUILayout.Label($"rightShoulder: {Gamepad.current.rightShoulder.ReadValue()}");
        GUILayout.Label($"rightTrigger: {Gamepad.current.rightTrigger.ReadValue()}");
    }
}
