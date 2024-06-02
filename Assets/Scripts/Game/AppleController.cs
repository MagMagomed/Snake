using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class AppleController : MonoBehaviour
    {
        private BackGround _backGround;
        private SnakeController _snakeController;
        // Start is called before the first frame update
        public void Initialize(SnakeController snakeController, BackGround backGround)
        {
            _snakeController = snakeController;
            _backGround = backGround;
            if (_snakeController != null)
            {
                _snakeController.OnPostionAndRotationUpdated += ComparePositions;
            }
            SceneController.OnLose += StopAllCoroutines;
            SetPostion();
        }
        private void ComparePositions(Vector3 postion, Quaternion rotation)
        {
            if(transform.position == postion)
            {
                SetPostion();
                if (_snakeController != null)
                {
                    _snakeController.AddChainOnNextStep();
                }
            }
        }
        private void OnDestroy()
        {
            if (_snakeController != null)
            {
                _snakeController.OnPostionAndRotationUpdated -= ComparePositions;
            }
            SceneController.OnLose -= StopAllCoroutines;
        }
        private void SetPostion()
        {
            transform.position = GetPosition();
        }
        private Vector3 GetPosition()
        {
            System.Random rnd = new System.Random();

            var chainList = new List<Chain>();
            _snakeController.GetChainList(ref chainList);
            var points = chainList.Select(chain => (Vector2)chain.gameObject.transform.position).ToArray();

            var result = GiveMeAPoint(points);
            if (result == null)
            {
                SceneController.GoToMenu();
            }
            return result.Value;
        }

        private Vector2? GiveMeAPoint(Vector2[] exclude)
        {
            var range = _backGround.GetAccessPositions();
            List<int> indexes = new List<int>();
            for (int i = 0; i < range.Count; i++)
            {
                if (exclude.Any(item =>
                         Mathf.Approximately(item.x, range[i].x)
                         && Mathf.Approximately(item.y, range[i].y)))
                {
                    continue;
                }
                indexes.Add(i);
            }
            var random = new System.Random();

            var index = random.Next(0, indexes.Count - 1);
            var coordinateIndex = indexes[index];
            return range[coordinateIndex];
        }
    }
}

