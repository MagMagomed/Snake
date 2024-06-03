using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Game.Enums;
using UnityEngine.UI;
using Assets.Scripts.MapEditor;
using Unity.VisualScripting.Dependencies.NCalc;
using System.Linq;
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
#if UNITY_EDITOR
        var pointDatas = _mapController.GetPointDatas();
        var map = new Map();

        map.PointData = JsonUtility.ToJson(pointDatas);
        map.BackGroundData = _mapController.GetBackGroundData();
        var assets = UnityEditor.AssetDatabase.FindAssets("", new string[] { "Assets/Maps" });
        UnityEditor.AssetDatabase.CreateAsset(map, "Assets/Maps/Map_" + (assets.Length + 1) + ".asset");
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();
        UnityEditor.EditorUtility.FocusProjectWindow();
        UnityEditor.Selection.activeObject = map;
#endif
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
