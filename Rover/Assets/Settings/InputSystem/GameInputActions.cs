// GENERATED AUTOMATICALLY FROM 'Assets/Settings/InputSystem/GameInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace InputActions
{
    public class GameInputActions : IInputActionCollection
    {
        private InputActionAsset asset;
        public GameInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputActions"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""f2ba4a44-8f0e-4248-ab62-dc70cf5d1eef"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""id"": ""83e75cfb-28c4-4781-901a-d4fea28cad09"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""Move"",
                    ""id"": ""b19e1afd-03a2-4b5b-80fb-c9676270256a"",
                    ""expectedControlLayout"": """",
                    ""continuous"": true,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fe995352-f6d0-4467-954f-feff81069a35"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";MouseAndKeyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""f3e691bc-651a-4366-9fe9-e58ca170302c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c355e73f-1463-46b5-94b6-88d2c04f06fb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""down"",
                    ""id"": ""796454ca-d37a-426d-897f-e7fb6412b7cf"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c09d1f3d-27b8-401a-ac76-77c1d73584de"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5d98b126-c521-41bb-a1ce-e984e1a802ae"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""95f81e4e-a5b7-4688-a9ec-526259fb4751"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d17e4ce7-3abd-4f79-a78f-e40e756188a4"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""down"",
                    ""id"": ""36b0aefe-4337-43cf-922b-da303a0b7e41"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""left"",
                    ""id"": ""80c55d86-3d0c-45fc-abf6-25b500b6c09f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""right"",
                    ""id"": ""582b6c11-3420-4bb3-841d-db2452f3128b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseAndKeyboard"",
            ""basedOn"": """",
            ""bindingGroup"": ""MouseAndKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Character
            m_Character = asset.GetActionMap("Character");
            m_Character_Jump = m_Character.GetAction("Jump");
            m_Character_Move = m_Character.GetAction("Move");
        }

        ~GameInputActions()
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

        public ReadOnlyArray<InputControlScheme> controlSchemes
        {
            get => asset.controlSchemes;
        }

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
        private InputActionMap m_Character;
        private ICharacterActions m_CharacterActionsCallbackInterface;
        private InputAction m_Character_Jump;
        private InputAction m_Character_Move;
        public struct CharacterActions
        {
            private GameInputActions m_Wrapper;
            public CharacterActions(GameInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Jump { get { return m_Wrapper.m_Character_Jump; } }
            public InputAction @Move { get { return m_Wrapper.m_Character_Move; } }
            public InputActionMap Get() { return m_Wrapper.m_Character; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled { get { return Get().enabled; } }
            public InputActionMap Clone() { return Get().Clone(); }
            public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterActions instance)
            {
                if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
                {
                    Jump.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    Jump.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    Jump.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    Move.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    Move.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    Move.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                }
                m_Wrapper.m_CharacterActionsCallbackInterface = instance;
                if (instance != null)
                {
                    Jump.started += instance.OnJump;
                    Jump.performed += instance.OnJump;
                    Jump.canceled += instance.OnJump;
                    Move.started += instance.OnMove;
                    Move.performed += instance.OnMove;
                    Move.canceled += instance.OnMove;
                }
            }
        }
        public CharacterActions @Character
        {
            get
            {
                return new CharacterActions(this);
            }
        }
        private int m_MouseAndKeyboardSchemeIndex = -1;
        public InputControlScheme MouseAndKeyboardScheme
        {
            get
            {
                if (m_MouseAndKeyboardSchemeIndex == -1) m_MouseAndKeyboardSchemeIndex = asset.GetControlSchemeIndex("MouseAndKeyboard");
                return asset.controlSchemes[m_MouseAndKeyboardSchemeIndex];
            }
        }
        public interface ICharacterActions
        {
            void OnJump(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
        }
    }
}
