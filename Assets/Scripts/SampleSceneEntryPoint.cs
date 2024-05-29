using Assets.Scripts;
using Assets.Scripts.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private AppleController _applePrefab;
    [SerializeField] private BackGround _backgroundPrefab;
    [SerializeField] private SnakeController _snakePrefab;
    [SerializeField] private InputController _inputPrefab;
    private void Start()
    {
        var background = Instantiate(_backgroundPrefab);
        var snake = Instantiate(_snakePrefab);
        var apple = Instantiate(_applePrefab);
        var input = Instantiate(_inputPrefab);

        input.Initialize();
        background.Initialize();
        var startPosition = background.GetPosition(new Vector2Int(0, 0));
        snake.Initialize(startPosition, new MoveFX(background), input);
        apple.Initialize(snake, background);
    }
}
