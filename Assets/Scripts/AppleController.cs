using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    [SerializeField] private SnakeController _snakeController;
    [SerializeField] private BackGround _backGround;
    // Start is called before the first frame update
    private void Start()
    {
        if( _snakeController != null )
        {
            _snakeController.OnPostionAndRotationUpdated += ComparePositions;
        }
    }
    private void ComparePositions(Vector3 postion, Quaternion rotation)
    {
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider != null )
        {
            SetPostion();
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

        if (_snakeController != null)
        {
            _snakeController.AddChainOnNextStep();
        }
    }
    private Vector3 GetPosition()
    {
        System.Random rnd = new System.Random();
        
        var chainList = new List<Chain>();
        _snakeController.GetChainList(ref chainList);
        var points = chainList.Select(chain => (Vector2)chain.gameObject.transform.position).ToArray();

        var result = GiveMeAPoint(points);
        if(result == null)
        {
            throw new NullReferenceException("Пенис");
        }
        return result.Value;
    }

    private Vector2? GiveMeAPoint(Vector2[] exclude)
    {
        var range = _backGround.Range;

        Vector2? result = null;
        List<Vector2> included = new List<Vector2>();
        included.AddRange(
            range.Where(
                point => !exclude.Any(
                    excludedPoint =>
                        Mathf.Approximately(point.x, excludedPoint.x) 
                        && Mathf.Approximately(point.y, excludedPoint.y)
                    )
                )
            );

        if (included.Count == 0) { return result; }
        var random = new System.Random();
        var index = random.Next(0, included.Count - 1);
        return included[index];
    }
}
