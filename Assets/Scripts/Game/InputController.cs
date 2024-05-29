using Assets.Scripts.Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class InputController : MonoBehaviour
    {
        private MovementDirection _movementDirection;

        public MovementDirection MovementDirection => _movementDirection;
        public void Initialize()
        {
            _movementDirection = MovementDirection.Up;
        }
        private void Update()
        {
            UpdateDirection();
        }
        private void UpdateDirection()
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                SetRight();
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                SetLeft();
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                SetUp();
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
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
