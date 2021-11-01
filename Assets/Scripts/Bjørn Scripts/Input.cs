using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    private GameController _Controller;

    private void Start()
    {
        _Controller = GetComponent<GameController>();
    }

    private void Update()
    {
        if (!_Controller.HasGuessed)
        {
            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                _Controller.SetGuess(0);
            }
            else if (Keyboard.current.digit2Key.wasPressedThisFrame)
            {
                _Controller.SetGuess(1);
            }
            else if (Keyboard.current.digit3Key.wasPressedThisFrame)
            {
                _Controller.SetGuess(2);
            }
            else if (Keyboard.current.digit4Key.wasPressedThisFrame)
            {
                _Controller.SetGuess(3);
            }
            else if (Keyboard.current.digit5Key.wasPressedThisFrame)
            {
                _Controller.SetGuess(4);
            }
            else if (Keyboard.current.digit6Key.wasPressedThisFrame)
            {
                _Controller.SetGuess(5);
            }
            else if (Keyboard.current.digit7Key.wasPressedThisFrame)
            {
                _Controller.SetGuess(6);
            }
            else if (Keyboard.current.digit8Key.wasPressedThisFrame)
            {
                _Controller.SetGuess(7);
            }
        }
    }
}
