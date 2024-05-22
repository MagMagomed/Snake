using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ChainController : Chain
{
    public Chain PreviousChain { get; set; }
    private Vector3 _nextPosition;
    private Quaternion _nextRotation;

    // Start is called before the first frame update
    private void Start()
    {
        SetNextPostion(PreviousChain.gameObject.transform.position);
        SetNextRotation(PreviousChain.gameObject.transform.rotation);
        SetActionHandler();
    }
    private void OnDestroy()
    {
        DeleteActionHandler();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player") { throw new Exception("Ура! Победа!"); }
    }
    private void SetNextPostion(Vector3 nextPostion)
    {
        _nextPosition = nextPostion;
    }
    private void SetNextRotation(Quaternion nextRotation)
    {
        _nextRotation = nextRotation;
    }
    private void UpdatePostion()
    {
        transform.position = _nextPosition;
        transform.rotation = _nextRotation;
        if (OnPostionAndRotationUpdated != null)
        {
            OnPostionAndRotationUpdated.Invoke(transform.position, transform.rotation);
        }
    }
    private void SetActionHandler()
    {
        if (PreviousChain != null)
        {
            PreviousChain.OnPostionAndRotationUpdated += OnUpdatePostionHandler;
        }
    }
    private void DeleteActionHandler()
    {
        if (PreviousChain != null)
        {
            PreviousChain.OnPostionAndRotationUpdated -= OnUpdatePostionHandler;
        }
    }
    private void OnUpdatePostionHandler(Vector3 nextPostion, Quaternion nextRotation)
    {
        UpdatePostion();
        SetNextPostion(nextPostion);
        SetNextRotation(nextRotation);
    }
}
