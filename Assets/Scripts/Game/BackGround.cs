using Assets.Scripts.MapEditor;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class BackGround : MonoBehaviour
    {
        private Assets.Scripts.MapEditor.Map _map;
        [SerializeField] private GameObject _fieldElementPref;
        public Vector2[,] Range { get; private set; }
        public Vector2[,] GetRange()
        {
            var pointData = JsonUtility.FromJson<PointDataCollection>(_map.PointData);
            var range = new Vector2[(int)(_map.BackGroundData.MaxX * 2 + 1), (int)(_map.BackGroundData.MaxY * 2 + 1)];
            int k = 0;
            for (int i = 0; i <= _map.BackGroundData.MaxX * 2; i++)
            {
                for (int j = 0; j <= _map.BackGroundData.MaxY * 2; j++)
                {
                    k++;
                    if(k == pointData.Data.Count) break;
                    range[i, j] = pointData.Data[k].Position;
                }
                if (k == pointData.Data.Count) break;
            }
            return range;
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
                throw new IndexOutOfRangeException($"Range[{coordinates.x}, {coordinates.y}] при rows = {rows} && columns = {columns}");
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
        public void Initialize(Assets.Scripts.MapEditor.Map map)
        {
            _map = map;
            Range = GetRange();
            int rows = Range.GetUpperBound(0) + 1;
            int columns = Range.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var item = Instantiate(_fieldElementPref);
                    item.transform.position = Range[i, j];
                    item.transform.SetParent(gameObject.transform, true);
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