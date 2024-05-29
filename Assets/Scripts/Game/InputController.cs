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
            UpdateNewRotation();
        }
        private void UpdateNewRotation()
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                _movementDirection = MovementDirection.Right;
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                _movementDirection = MovementDirection.Left;
            }

            if (Input.GetAxisRaw("Vertical") > 0)
            {
                _movementDirection = MovementDirection.Up;
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                _movementDirection = MovementDirection.Down;
            }
        }
    }
}
