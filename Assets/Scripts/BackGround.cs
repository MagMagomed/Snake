using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackGround : MonoBehaviour
{
    [SerializeField] private BackGroundData _backGroundData;
    [SerializeField] private GameObject _fieldElementPref;
    public Vector2[,] Range { get; private set; }
    private void Start()
    {
        Init();
    }
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
        catch(IndexOutOfRangeException exception)
        {
            int rows = Range.GetUpperBound(0) + 1;    // количество строк
            int columns = Range.Length / rows;
            throw new IndexOutOfRangeException($"Range[{coordinates.x}, {coordinates.y}] при rows = {rows} && columns = {columns}");
        }
    }
    public Vector2Int GetCoordinates(Vector2Int coordinates)
    {
        int rows = Range.GetUpperBound(0) + 1;    // количество строк
        int columns = Range.Length / rows;
        if (coordinates.x == rows) coordinates.x = 0;
        if (coordinates.y == columns) coordinates.y = 0;
        if (coordinates.x < 0) coordinates.x = rows - 1;
        if (coordinates.y < 0) coordinates.y = columns - 1;
        return coordinates;
    }
    private void Init()
    {
        Range = GetRange();
        int rows = Range.GetUpperBound(0) + 1;    // количество строк
        int columns = Range.Length / rows;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var item = Instantiate(_fieldElementPref);
                item.transform.position = Range[i, j];
                item.transform.SetParent(gameObject.transform);
            }
        }
    }
}
