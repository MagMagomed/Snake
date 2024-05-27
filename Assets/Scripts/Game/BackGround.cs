using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Assets.Scripts.Game
{
    public class BackGround : MonoBehaviour
    {
        [SerializeField] private BackGroundData _backGroundData;
        [SerializeField] private GameObject _fieldElementPref;
        public Vector2[,] Range { get; private set; }
        public Vector2[,] GetRange()
        {
            var range = new Vector2[(int)(_backGroundData.MaxX * 2 + 1), (int)(_backGroundData.MaxY * 2 + 1)];
            for (int i = 0; i <= _backGroundData.MaxX * 2; i++)
            {
                float x = _backGroundData.MinX + i;

                for (int j = 0; j <= _backGroundData.MaxY * 2; j++)
                {
                    float y = _backGroundData.MinY + j;
                    range[i, j] = new Vector2(x, y);
                }
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
        public void Initialize()
        {
            InitBackgroundData();
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
        }

        private void InitBackgroundData()
        {
            Camera camera = Camera.main;
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // bottom-left corner
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // top-right corner

            _backGroundData = new BackGroundData()
            {
                MinX = min.x + 0.5f,
                MaxX = max.x,
                MinY = min.y + 0.5f,
                MaxY = max.y - 0.5f
            };
        }
    }
}