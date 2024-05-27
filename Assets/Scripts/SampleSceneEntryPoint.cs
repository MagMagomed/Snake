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
    private void Start()
    {
        var background = Instantiate(_backgroundPrefab);
        var snake = Instantiate(_snakePrefab);
        var apple = Instantiate(_applePrefab);

        background.Initialize();
        var startPosition = background.GetPosition(new Vector2Int(0, 0));
        snake.Initialize(startPosition, new MoveFX(background));
        apple.Initialize(snake, background);
    }
}
