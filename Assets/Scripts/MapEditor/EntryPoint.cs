using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MapEditor
{
    /// <summary>
    /// Точка входа в редактор карты
    /// </summary>
    public class EntryPoint: MonoBehaviour
    {
        [SerializeField] private UIController _mapEnginUIControllerPrefab;
        private void Start()
        {
            UIController mapEnginUIControllerPrefab = null;
            if (_mapEnginUIControllerPrefab != null) mapEnginUIControllerPrefab = Instantiate(_mapEnginUIControllerPrefab);

            mapEnginUIControllerPrefab.Initialize(Camera.main);
        }
    }
}
