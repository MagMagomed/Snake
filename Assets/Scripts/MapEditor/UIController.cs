using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Game.Enums;
using UnityEngine.UI;
using Assets.Scripts.MapEditor;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor;
/// <summary>
/// Контролирует UI редактора карты
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField] private BrushController _brushController;
    [SerializeField] private MapController _mapController;
    [SerializeField] private Canvas _canvas;
    public void Initialize()
    {
        _canvas.renderMode = RenderMode.ScreenSpaceCamera;
        _canvas.worldCamera = Camera.main;
        _brushController.Initialize();
        _mapController.Initialize();
    }
    public void SavePointDatas()
    {
        var pointDatas = _mapController.GetPointDatas();
        var map = new Map();
        
        map.PointData = new List<PointData>();
        foreach (var pointData in pointDatas)
        {
            map.PointData.Add(pointData);
        }
        map.BackGroundData = _mapController.GetBackGroundData();
        AssetDatabase.CreateAsset(map, "Assets/Maps/" + map.Name + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = map;
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
