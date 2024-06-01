using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MapEngine
{
    /// <summary>
    /// Точка входа в редактор карты
    /// </summary>
    public class MapEngineEntryPoint: MonoBehaviour
    {
        [SerializeField] private MapEngineUIController _mapEnginUIControllerPrefab;
        private void Start()
        {
            MapEngineUIController mapEnginUIControllerPrefab = null;
            if (_mapEnginUIControllerPrefab != null) mapEnginUIControllerPrefab = Instantiate(_mapEnginUIControllerPrefab);

            mapEnginUIControllerPrefab.Initialize(Camera.main);
        }
    }
}
