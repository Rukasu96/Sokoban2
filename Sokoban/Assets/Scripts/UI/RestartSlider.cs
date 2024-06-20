using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;

public class RestartSlider : MonoBehaviour
{
    [SerializeField] private CanvasGroup resetCanvas;
    [SerializeField] private Slider resetSlider;
    [SerializeField] private SceneLoader SceneLoader;
    private PlayerInput input = null;
    private bool tryToReset = false;

    private void Awake()
    {
        input = new PlayerInput();
    }
   
    void Update()
    {
        if (tryToReset)
        {
            resetCanvas.DOFade(1f, 0.5f);
            resetSlider.value += Time.deltaTime;

            if (resetSlider.value == 3)
            {
                SceneLoader.RestartLevel();
            }
        }
        else
        {
            resetCanvas.DOFade(0f, 0.3f);
            resetSlider.value = 0;
        }
    }

    private void OnEnable()
    {
        input.Enable();
        input.UI.ResetButton.performed += (InputAction.CallbackContext value) => tryToReset = true;
        input.UI.ResetButton.canceled += (InputAction.CallbackContext value) => tryToReset = false;
        
    }
    private void OnDestroy()
    {
        input.Disable();
        input.UI.ResetButton.performed -= (InputAction.CallbackContext value) => tryToReset = true;
        input.UI.ResetButton.canceled -= (InputAction.CallbackContext value) => tryToReset = false;
        
    }
}
