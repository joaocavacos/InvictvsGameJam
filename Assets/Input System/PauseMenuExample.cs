using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuExample : MonoBehaviour
{
    //podes meter static e metes este script num lugar aonde n seja disabled
    public static CharacterControls pauseControls;
    private PauseMenu _pauseMenu;

    void Awake()
    {
        _pauseMenu = GetComponent<PauseMenu>();
        pauseControls = new CharacterControls();
        pauseControls.Enable();
        //da enable para comecar a ser lido
        pauseControls.HUDControls.Pause.Enable();
        //assim cria um evento para quando o botao e clicado
        pauseControls.HUDControls.Pause.performed += Pause_performed;
    }

    private void Pause_performed(InputAction.CallbackContext obj)
    {
        //o evento, faz o q quiseres
        Debug.Log("Pause menu open");
        _pauseMenu.OpenPause();
    }

    // Update is called once per frame
    private void OnDisable()
    {
        //Para nao ficar abandonado
        pauseControls.HUDControls.Pause.Disable();
    }
}
