using Assets.Scripts.Game.Enums;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using System.Linq;

namespace Assets.Scripts.Game
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private float m_InputSensitivity = 1f;

        private MovementDirection _movementDirection;

        private Vector2 m_InputPosition;
        private Vector2 m_PreviousInputPosition;
        private bool m_HasInput;

        private float _horizontalAxis;
        private float _verticalAxis;

        public MovementDirection MovementDirection => _movementDirection;
        public void Initialize()
        {
            _movementDirection = MovementDirection.Up;
        }
        private void Update()
        {
            UpdateAxises();
            UpdateDirection();
        }

        private void UpdateAxises()
        {
            _horizontalAxis = Input.GetAxisRaw("Horizontal");
            _verticalAxis = Input.GetAxisRaw("Vertical");


            //if (Mouse.current.leftButton.isPressed)
            //{
            //    m_InputPosition = Mouse.current.position.ReadValue();
                
            //    if (!m_HasInput)
            //    {
            //        m_PreviousInputPosition = m_InputPosition;
            //    }
            //    m_HasInput = true;
            //}
            //else
            //{
            //    m_HasInput = false;
            //}

            if (Mouse.current.leftButton.isPressed || Input.touches.Count() > 0)
            {
                m_InputPosition = Mouse.current.leftButton.isPressed ? Mouse.current.position.ReadValue() : Input.touches.FirstOrDefault().position;

                if (!m_HasInput)
                {
                    m_PreviousInputPosition = m_InputPosition;
                }
                m_HasInput = true;
            }
            else
            {
                m_HasInput = false;
            }

            if (m_HasInput)
            {
                var horizontalAxis = (m_InputPosition.x - m_PreviousInputPosition.x);
                Debug.Log($"horizontal: {horizontalAxis}");
                if(Mathf.Abs(horizontalAxis) > m_InputSensitivity)
                {
                    _horizontalAxis = horizontalAxis;
                }
            }
            if (m_HasInput)
            {
                var verticalAxis = (m_InputPosition.y - m_PreviousInputPosition.y);
                Debug.Log($"vertical: {verticalAxis}");
                if (Mathf.Abs(verticalAxis) > m_InputSensitivity)
                {
                    _verticalAxis = verticalAxis;
                }
            }
            m_PreviousInputPosition = m_InputPosition;
        }
        private void UpdateDirection()
        {
            if (_horizontalAxis > 0)
            {
                SetRight();
            }
            else if (_horizontalAxis < 0)
            {
                SetLeft();
            }
            if (_verticalAxis > 0)
            {
                SetUp();
            }
            else if (_verticalAxis < 0)
            {
                SetDown();
            }
        }
        public void SetRight()
        {
            _movementDirection = MovementDirection.Right;
        }
        public void SetLeft()
        {
            _movementDirection = MovementDirection.Left;
        }
        public void SetUp()
        {
            _movementDirection = MovementDirection.Up;
        }
        public void SetDown()
        {
            _movementDirection = MovementDirection.Down;
        }
    }
}
