// GENERATED AUTOMATICALLY FROM 'Assets/Input System/CharacterControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CharacterControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterControls"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""642ec693-5652-46ba-a9b9-b9f951ef1126"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""8eb4d06d-852f-4d37-8d1b-0188244ec123"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Direction"",
                    ""type"": ""Value"",
                    ""id"": ""6ed57682-a25d-435e-adcb-e71cb2d36eff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""fc9d23db-76d3-4ffd-9369-4db9ec2146dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""1986f0a2-ef72-49b2-a2fe-a980ac91d149"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""a550f823-0975-4de9-aa39-a610133b39f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Style0"",
                    ""type"": ""Button"",
                    ""id"": ""c7eab315-e3c4-45f5-b1b5-cdad9e44280f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Style1"",
                    ""type"": ""Button"",
                    ""id"": ""28363806-f288-4133-89e1-559113a75664"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Style2"",
                    ""type"": ""Button"",
                    ""id"": ""763136d5-cece-4f31-83f5-094db479a6bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Style3"",
                    ""type"": ""Button"",
                    ""id"": ""07eac3ef-9f57-4db5-973c-36f40382c3ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c7df3474-8ee0-4b5e-a782-42d4c01ea933"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""386c2690-72b3-4538-9a9d-59a7e206965a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""889de17b-e47b-43f8-be04-db557b519f34"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4dfcc198-e8e7-4647-9d98-aef5e2cc21c9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6a50f89f-750a-48ba-8d03-39feefb90e9b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5728f114-db4a-4e14-b884-bc02a55510b1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c2368f7a-5cd4-4457-a416-a0f5e48e9a66"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58bfc42b-7fbb-4275-8e8b-e7a552e3d253"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2,ScaleVector2"",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6302437-04c5-4b47-a087-066093ef3eac"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f42baade-38cd-4201-ab5b-8b988295d889"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91da8d94-d59d-4f99-b4b3-ce0b31dcbaf7"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c7c619c-53ed-484d-8cfa-c3376df13141"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff4019bf-2e41-4def-894b-a8e3aa30984f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf192f66-472a-4d76-b62a-55b6a6f862a8"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aaf73b83-cdca-4576-9e17-e9925ff710ad"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock"",
                    ""action"": ""Style0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea1630e8-2716-4901-b175-621331493dfb"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Style0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51383df3-c1c1-4179-b7ed-644ce3f9bcb0"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock"",
                    ""action"": ""Style1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d20fa542-a153-4789-bd99-8a678ba0587f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Style1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb156511-0503-452e-a696-37874375d5d5"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock"",
                    ""action"": ""Style2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0288f0a-382e-485a-b2c6-a6843faa519b"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Style2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01d57353-d495-47a7-a557-ac4d7bedee82"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dualshock"",
                    ""action"": ""Style3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fdf6e54e-3bc2-46dd-8608-f47821b7e1d9"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Style3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Dualshock"",
            ""bindingGroup"": ""Dualshock"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Character
        m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
        m_Character_Movement = m_Character.FindAction("Movement", throwIfNotFound: true);
        m_Character_Direction = m_Character.FindAction("Direction", throwIfNotFound: true);
        m_Character_Roll = m_Character.FindAction("Roll", throwIfNotFound: true);
        m_Character_Block = m_Character.FindAction("Block", throwIfNotFound: true);
        m_Character_Attack = m_Character.FindAction("Attack", throwIfNotFound: true);
        m_Character_Style0 = m_Character.FindAction("Style0", throwIfNotFound: true);
        m_Character_Style1 = m_Character.FindAction("Style1", throwIfNotFound: true);
        m_Character_Style2 = m_Character.FindAction("Style2", throwIfNotFound: true);
        m_Character_Style3 = m_Character.FindAction("Style3", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Character
    private readonly InputActionMap m_Character;
    private ICharacterActions m_CharacterActionsCallbackInterface;
    private readonly InputAction m_Character_Movement;
    private readonly InputAction m_Character_Direction;
    private readonly InputAction m_Character_Roll;
    private readonly InputAction m_Character_Block;
    private readonly InputAction m_Character_Attack;
    private readonly InputAction m_Character_Style0;
    private readonly InputAction m_Character_Style1;
    private readonly InputAction m_Character_Style2;
    private readonly InputAction m_Character_Style3;
    public struct CharacterActions
    {
        private @CharacterControls m_Wrapper;
        public CharacterActions(@CharacterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Character_Movement;
        public InputAction @Direction => m_Wrapper.m_Character_Direction;
        public InputAction @Roll => m_Wrapper.m_Character_Roll;
        public InputAction @Block => m_Wrapper.m_Character_Block;
        public InputAction @Attack => m_Wrapper.m_Character_Attack;
        public InputAction @Style0 => m_Wrapper.m_Character_Style0;
        public InputAction @Style1 => m_Wrapper.m_Character_Style1;
        public InputAction @Style2 => m_Wrapper.m_Character_Style2;
        public InputAction @Style3 => m_Wrapper.m_Character_Style3;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                @Direction.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDirection;
                @Direction.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDirection;
                @Direction.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDirection;
                @Roll.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRoll;
                @Block.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnBlock;
                @Block.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnBlock;
                @Block.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnBlock;
                @Attack.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAttack;
                @Style0.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStyle0;
                @Style0.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStyle0;
                @Style0.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStyle0;
                @Style1.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStyle1;
                @Style1.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStyle1;
                @Style1.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStyle1;
                @Style2.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStyle2;
                @Style2.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStyle2;
                @Style2.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStyle2;
                @Style3.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStyle3;
                @Style3.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStyle3;
                @Style3.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStyle3;
            }
            m_Wrapper.m_CharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Direction.started += instance.OnDirection;
                @Direction.performed += instance.OnDirection;
                @Direction.canceled += instance.OnDirection;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Style0.started += instance.OnStyle0;
                @Style0.performed += instance.OnStyle0;
                @Style0.canceled += instance.OnStyle0;
                @Style1.started += instance.OnStyle1;
                @Style1.performed += instance.OnStyle1;
                @Style1.canceled += instance.OnStyle1;
                @Style2.started += instance.OnStyle2;
                @Style2.performed += instance.OnStyle2;
                @Style2.canceled += instance.OnStyle2;
                @Style3.started += instance.OnStyle3;
                @Style3.performed += instance.OnStyle3;
                @Style3.canceled += instance.OnStyle3;
            }
        }
    }
    public CharacterActions @Character => new CharacterActions(this);
    private int m_DualshockSchemeIndex = -1;
    public InputControlScheme DualshockScheme
    {
        get
        {
            if (m_DualshockSchemeIndex == -1) m_DualshockSchemeIndex = asset.FindControlSchemeIndex("Dualshock");
            return asset.controlSchemes[m_DualshockSchemeIndex];
        }
    }
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface ICharacterActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnDirection(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnStyle0(InputAction.CallbackContext context);
        void OnStyle1(InputAction.CallbackContext context);
        void OnStyle2(InputAction.CallbackContext context);
        void OnStyle3(InputAction.CallbackContext context);
    }
}
