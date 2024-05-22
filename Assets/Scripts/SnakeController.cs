using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeController : Chain
{
    private Vector3 _currentPosition;
    private Quaternion _currentRotation;
    private Quaternion _newRotation;
    private void Start()
    {
        StartCoroutine(MoveForwardAnimation(0.2f));
        SetCurrentPosition();
    }
    private void Update()
    {
        UpdateNewRotation();
    }
    private IEnumerator MoveForwardAnimation(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            transform.rotation = _newRotation;
            transform.position += transform.rotation * Vector3Int.up;
            SetCurrentPosition();
        }
    }
    private void UpdateNewRotation()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)
            && transform.rotation != Quaternion.Euler(0f, 0f, 90f))
        {
            _newRotation = Quaternion.Euler(0f, 0f, 270f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)
            && transform.rotation != Quaternion.Euler(0f, 0f, 270f))
        {
            _newRotation = Quaternion.Euler(0f, 0f, 90f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) 
            && transform.rotation != Quaternion.Euler(0f, 0f, 180f))
        {
            _newRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)
            && transform.rotation != Quaternion.Euler(0f, 0f, 0f))
        {
            _newRotation = Quaternion.Euler(0f, 0f, 180f);
        }
    }
    private void SetCurrentPosition()
    {
        _currentPosition = transform.position;
        _currentRotation = transform.rotation;
        if(OnPostionAndRotationUpdated != null)
        {
            OnPostionAndRotationUpdated.Invoke(_currentPosition, _currentRotation);
            if (_addChainOnNextStep) 
                AddChain();
        }
    }
}
