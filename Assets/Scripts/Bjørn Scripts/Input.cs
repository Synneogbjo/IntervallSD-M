using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    [HideInInspector] public bool hasGuessed;
    [HideInInspector] public int digit;
    
    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            hasGuessed = true;
            digit = 0;
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            hasGuessed = true;
            digit = 1;
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            hasGuessed = true;
            digit = 2;
        }
        else if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            hasGuessed = true;
            digit = 3;
        }
        else if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            hasGuessed = true;
            digit = 4;
        }
        else if (Keyboard.current.digit6Key.wasPressedThisFrame)
        {
            hasGuessed = true;
            digit = 5;
        }
        else if (Keyboard.current.digit7Key.wasPressedThisFrame)
        {
            hasGuessed = true;
            digit = 6;
        }
        else if (Keyboard.current.digit8Key.wasPressedThisFrame)
        {
            hasGuessed = true;
            digit = 7;
        }
    }
}
