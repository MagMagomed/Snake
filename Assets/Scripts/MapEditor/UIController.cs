using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Game.Enums;
using UnityEngine.UI;
using Assets.Scripts.MapEditor;
/// <summary>
/// Контролирует UI редактора карты
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField] private BrushController _brushController;
    [SerializeField] private MapController _mapController;
    [SerializeField] private Canvas _canvas;
    public void Initialize(Camera camera)
    {
        _canvas.worldCamera = camera;
        _brushController.Initialize();
        _mapController.Initialize();
    }
    public void ChooseBackgroundBrush ()
    {
        _brushController.BrushState = BrushState.BackgroundElement;
    }
    public void ChooseObstacle()
    {
        _brushController.BrushState = BrushState.ObstacleElement;
    }
}
