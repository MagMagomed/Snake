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
            var range = _backGround.Range;
            int rows = range.GetUpperBound(0) + 1;    // количество строк
            int columns = range.Length / rows;
            List<Vector2Int> indexes = new List<Vector2Int>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (exclude.Any(item =>
                        Mathf.Approximately(item.x, range[i, j].x)
                        && Mathf.Approximately(item.y, range[i, j].y)))
                    {
                        continue;
                    }
                    indexes.Add(new Vector2Int(i, j));
                }
            }
            var random = new System.Random();

            var index = random.Next(0, indexes.Count - 1);
            var coordinates = indexes[index];
            return range[coordinates.x, coordinates.y];
        }
    }
}

