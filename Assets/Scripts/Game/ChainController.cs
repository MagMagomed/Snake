using Assets.Scripts;
using Assets.Scripts.Game.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    public class ChainController : Chain, ILoseIfTouch
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
        private void SetNextPostion(Vector3 nextPostion)
        {
            if(ComparePosition(_snakeController.transform.position, transform.position))
            {
                Lose();
            }
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

        public bool ComparePosition(Vector3 position1, Vector3 position2)
        {
            if(position1 == null || position2 == null) return false;
            if(position1 == position2) return true;
            return false;
        }

        public void Lose()
        {
            SceneController.Lose();
        }
    }
}