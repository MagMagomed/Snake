using Assets.Scripts.Game.Interfaces;
using Assets.Scripts.MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class BackGround : MonoBehaviour
    {
        private Map _map;
        private PointDataCollection _points;
        [SerializeField] private ObstacleController _obstacleElementPrefab;
        [SerializeField] private FieldController _fieldElementPref;
        public Vector2[,] Range { get; private set; }
        public Vector2[,] GetRange()
        {
            _points = JsonUtility.FromJson<PointDataCollection>(_map.PointData);
            var range = new Vector2[(int)(_map.BackGroundData.MaxX * 2 + 1), (int)(_map.BackGroundData.MaxY * 2 + 1)];
            int k = 0;
            for (int i = 0; i <= _map.BackGroundData.MaxX * 2; i++)
            {
                for (int j = 0; j <= _map.BackGroundData.MaxY * 2; j++)
                {
                    if(k == _points.Data.Count) break;
                    range[i, j] = _points.Data[k].Position;
                    k++;
                }
                if (k == _points.Data.Count) break;
            }
            return range;
        }
        public List<Vector2> GetAccessPositions()
        {
            return _points.Data.Where(data => data.CurrentState != Enums.BrushState.ObstacleElement).Select(data => data.Position).ToList();
        }
        public Vector2 GetPosition(Vector2Int coordinates)
        {
            try
            {
                return Range[coordinates.x, coordinates.y];
            }
            catch (IndexOutOfRangeException exception)
            {
                int rows = Range.GetUpperBound(0) + 1;
                int columns = Range.Length / rows;
                var newException = new IndexOutOfRangeException($"Range[{coordinates.x}, {coordinates.y}] при rows = {rows} && columns = {columns}", exception);
                throw newException;
            }
        }
        public Vector2Int GetCoordinates(Vector2Int coordinates)
        {
            int rows = Range.GetUpperBound(0) + 1;
            int columns = Range.Length / rows;
            if (coordinates.x == rows) coordinates.x = 0;
            if (coordinates.y == columns) coordinates.y = 0;
            if (coordinates.x < 0) coordinates.x = rows - 1;
            if (coordinates.y < 0) coordinates.y = columns - 1;
            return coordinates;
        }
        public void Initialize(Map map, SnakeController snake)
        {
            _map = map;
            Range = GetRange();
            int rows = Range.GetUpperBound(0) + 1;
            int columns = Range.Length / rows;
            foreach (var point in _points.Data)
            {
                switch(point.CurrentState)
                {
                    case Enums.BrushState.ObstacleElement:
                        var obstacle = Instantiate(_obstacleElementPrefab);
                        obstacle.transform.position = point.Position;
                        obstacle.transform.SetParent(gameObject.transform, true);
                        obstacle.Initialize(snake);
                        break;
                    case Enums.BrushState.BackgroundElement: 
                        var field = Instantiate(_fieldElementPref);
                        field.transform.position = point.Position;
                        field.transform.SetParent(gameObject.transform, true);
                        break;
                }
            }
            SceneController.OnLose += StopAllCoroutines;
        }

        private void OnDestroy()
        {
            SceneController.OnLose -= StopAllCoroutines;
        }
    }
}