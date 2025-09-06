using UnityEngine;
using UnityEngine.EventSystems;

public class FocusFix : MonoBehaviour
{
    void Start()
    {
        Application.focusChanged += OnFocusChanged;
        FocusGameWindow();
    }

    void OnFocusChanged(bool hasFocus)
    {
        if (!hasFocus)
            FocusGameWindow();
    }

    void FocusGameWindow()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLInput.captureAllKeyboardInput = true;
#endif
    }
}
