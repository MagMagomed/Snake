using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    public IEnumerable<Vector2> Range { get; private set; }
    private void Start()
    {
        Range = GetRange();
    }
    public List<Vector2> GetRange()
    {
        var range = new List<Vector2>();
        for (float x = _minX; x <= _maxX; x++)
        {
            for (float y = _minY; y <= _maxY; y++)
            {
                range.Add(new Vector2(x, y));
            }
        }
        return range;
    }
}
