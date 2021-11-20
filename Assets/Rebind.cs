using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rebind : MonoBehaviour
{
    private InputActionRebindingExtensions.RebindingOperation rebinding;
    // Start is called before the first frame update
    public void RebindAttackGamepad(GameObject caller)
    {
        Player._controls.Character.Attack.Disable();
        rebinding = Player
            ._controls
            .Character
            .Attack
            .PerformInteractiveRebinding()
            .WithControlsExcluding("Keyboard")
            .WithControlsExcluding("Mouse")
            .WithBindingGroup("Dualshock")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => Dispose(caller.GetComponentInChildren<TextMeshProUGUI>(), InputControlPath.ToHumanReadableString(Player._controls.Character.Attack.bindings[0].effectivePath)))
            .Start();
        Player._controls.Character.Attack.Enable();

        Debug.Log(InputControlPath.ToHumanReadableString(Player._controls.Character.Attack.bindings[0].effectivePath));
        Debug.Log(InputControlPath.ToHumanReadableString(Player._controls.Character.Attack.bindings[1].effectivePath));
    }

    public void RebindRollGamepad(GameObject caller)
    {
        Player._controls.Character.Roll.Disable();
        rebinding = Player
            ._controls
            .Character
            .Roll
            .PerformInteractiveRebinding()
            .WithControlsExcluding("Keyboard")
            .WithControlsExcluding("Mouse")
            .WithBindingGroup("Dualshock")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => Dispose(caller.GetComponentInChildren<TextMeshProUGUI>(), InputControlPath.ToHumanReadableString(Player._controls.Character.Roll.bindings[0].effectivePath)))
            .Start();
        Player._controls.Character.Roll.Enable();
        Debug.Log(InputControlPath.ToHumanReadableString(Player._controls.Character.Roll.bindings[0].effectivePath));
        Debug.Log(InputControlPath.ToHumanReadableString(Player._controls.Character.Roll.bindings[1].effectivePath));
    }

    public void RebindBlockGamepad(GameObject caller)
    {
        Player._controls.Character.Block.Disable();
        rebinding = Player
            ._controls
            .Character
            .Block
            .PerformInteractiveRebinding()
            .WithControlsExcluding("Keyboard")
            .WithControlsExcluding("Mouse")
            .WithBindingGroup("Dualshock")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => Dispose(caller.transform.GetComponentInChildren<TextMeshProUGUI>(), InputControlPath.ToHumanReadableString(Player._controls.Character.Block.bindings[0].effectivePath)))
            .Start();
        Player._controls.Character.Block.Enable();

        Debug.Log(InputControlPath.ToHumanReadableString(Player._controls.Character.Block.bindings[0].effectivePath));
        Debug.Log(InputControlPath.ToHumanReadableString(Player._controls.Character.Block.bindings[1].effectivePath));
    }

    public void RebindAttackKM(GameObject caller)
    {
        Player._controls.Character.Attack.Disable();
        rebinding = Player
            ._controls
            .Character
            .Attack
            .PerformInteractiveRebinding()
            .WithControlsExcluding("Gamepad")
            .WithBindingGroup("KeyboardAndMouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => Dispose(caller.GetComponentInChildren<TextMeshProUGUI>(), InputControlPath.ToHumanReadableString(Player._controls.Character.Attack.bindings[1].effectivePath)))
            .Start();
        Player._controls.Character.Attack.Enable();

        Debug.Log(InputControlPath.ToHumanReadableString(Player._controls.Character.Attack.bindings[0].effectivePath));
        Debug.Log(InputControlPath.ToHumanReadableString(Player._controls.Character.Attack.bindings[1].effectivePath));
    }

    public void RebindRollKM(GameObject caller)
    {
        Player._controls.Character.Roll.Disable();
        rebinding = Player
            ._controls
            .Character
            .Roll
            .PerformInteractiveRebinding()
            .WithControlsExcluding("Gamepad")
            .WithBindingGroup("KeyboardAndMouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => Dispose(caller.GetComponentInChildren<TextMeshProUGUI>(), InputControlPath.ToHumanReadableString(Player._controls.Character.Roll.bindings[1].effectivePath)))
            .Start();
        Player._controls.Character.Roll.Enable();
        Debug.Log(InputControlPath.ToHumanReadableString(Player._controls.Character.Roll.bindings[0].effectivePath));
        Debug.Log(InputControlPath.ToHumanReadableString(Player._controls.Character.Roll.bindings[1].effectivePath));
    }

    public void RebindBlockKM(GameObject caller)
    {
        Player._controls.Character.Block.Disable();
        rebinding = Player
            ._controls
            .Character
            .Block
            .PerformInteractiveRebinding()
            .WithControlsExcluding("Gamepad")
            .WithBindingGroup("KeyboardAndMouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => Dispose(caller.transform.GetComponentInChildren<TextMeshProUGUI>(), InputControlPath.ToHumanReadableString(Player._controls.Character.Block.bindings[1].effectivePath)))
            .Start();
        Player._controls.Character.Block.Enable();
    }

    private void Dispose(TextMeshProUGUI target, string text)
    {
        rebinding.Dispose();
        Debug.Log(text);
        target.text = text;
    }


}
