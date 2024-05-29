using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Game
{
    public class SnakeController : Chain
    {
        private Vector3 _currentPosition;
        private Quaternion _currentRotation;
        private Quaternion _newRotation;
        private MoveFX _moveFX;
        private InputController _inputController;
        public void Initialize(Vector2 position, MoveFX moveFX, InputController inputController)
        {
            transform.position = position;
            _moveFX = moveFX;
            _snakeController = this;
            _inputController = inputController;
            SceneController.OnLose += StopAllCoroutines;
        }
        private void Start()
        {
            StartCoroutine(MoveForwardAnimation(0.2f));
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
                transform.position = _moveFX.GetNextPosition(_currentRotation.eulerAngles.z);
                SetCurrentPosition();
            }
        }
        private void UpdateNewRotation()
        {
            if (_inputController.MovementDirection == Enums.MovementDirection.Right
                && transform.rotation != Quaternion.Euler(0f, 0f, 90f))
            {
                _newRotation = Quaternion.Euler(0f, 0f, -90f);
            }
            if (_inputController.MovementDirection == Enums.MovementDirection.Left
                && transform.rotation != Quaternion.Euler(0f, 0f, -90f))
            {
                _newRotation = Quaternion.Euler(0f, 0f, 90f);
            }

            if (_inputController.MovementDirection == Enums.MovementDirection.Up
                && transform.rotation != Quaternion.Euler(0f, 0f, -180f)
                && transform.rotation != Quaternion.Euler(0f, 0f, 180f))
            {
                _newRotation = Quaternion.Euler(0f, 0f, 0f);
            }
            if (_inputController.MovementDirection == Enums.MovementDirection.Down
                && transform.rotation != Quaternion.Euler(0f, 0f, 0f))
            {
                _newRotation = Quaternion.Euler(0f, 0f, 180f);
            }
        }
        private void SetCurrentPosition()
        {
            _currentPosition = transform.position;
            _currentRotation = transform.rotation;
            if (OnPostionAndRotationUpdated != null)
            {
                OnPostionAndRotationUpdated.Invoke(_currentPosition, _currentRotation);
                if (_addChainOnNextStep)
                    AddChain(_snakeController);
            }
        }
        private void OnDestroy()
        {
            SceneController.OnLose -= StopAllCoroutines;
        }
    }
}