using Assets.Scripts.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    internal class ObstacleController : FieldController, ILoseIfTouch
    {
        private SnakeController _controller;
        public void Initialize(SnakeController snakeController)
        {
            _controller = snakeController;
            _controller.OnPostionAndRotationUpdated += CheckNewPosition;
        }
        private void CheckNewPosition(Vector3 position, Quaternion rotation)
        {
            if(ComparePosition(position, transform.position))
            {
                Lose();
            }
        }
        public bool ComparePosition(Vector3 position1, Vector3 position2)
        {
            if (position1 == null || position2 == null) return false;
            if (position1 == position2) return true;
            return false;
        }

        public void Lose()
        {
            SceneController.Lose();
        }
    }
}
