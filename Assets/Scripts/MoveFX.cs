using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveFX : MonoBehaviour
{
    [SerializeField] private BackGround _backGround;
    private Vector2Int _currentPosition;
    private Dictionary<float, MovementDirection> directions;
    // Start is called before the first frame update
    private void Start()
    {
        directions = new Dictionary<float, MovementDirection>();
        directions.Add(-90f, MovementDirection.Right);
        directions.Add(270f, MovementDirection.Right);
        directions.Add(90f, MovementDirection.Left);
        directions.Add(0f, MovementDirection.Up);
        directions.Add(180f, MovementDirection.Down);
        _currentPosition = Vector2Int.zero;
    }
    public Vector2 GetNextPosition(float currentRotationZ)
    {
        if (!directions.TryGetValue(currentRotationZ, out MovementDirection direction)) throw new Exception($"Ќе удалось определить направление движени€ дл€ currentRotationZ = {currentRotationZ}");
        
        if(direction == MovementDirection.Up)
        {
            _currentPosition.y += 1;
        }
        if (direction == MovementDirection.Down)
        {
            _currentPosition.y -= 1;
        }
        if (direction == MovementDirection.Right)
        {
            _currentPosition.x += 1;
        }
        if (direction == MovementDirection.Left)
        {
            _currentPosition.x -= 1;
        }
        _currentPosition = _backGround.GetCoordinates(_currentPosition);
        return _backGround.GetPosition(_currentPosition);
    }
    private enum MovementDirection
    {
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3
    }
}
