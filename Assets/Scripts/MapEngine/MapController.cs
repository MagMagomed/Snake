using Assets.Scripts.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MapEngine
{
    /// <summary>
    /// Класс, который создаст и будет хранить состояние карты с точками
    /// </summary>
    internal class MapController : MonoBehaviour
    {
        [SerializeField] private PointController _pointPrefab;
        [SerializeField] private BackGroundData _backGroundData;
        [SerializeField] private BrushController _brushController;
        [SerializeField] private GameObject _mapDiv;
        private List<PointData> _pointDataMap;
        public void Initialize()
        {
            _pointDataMap = new List<PointData>();
            BuildMap();
        }
        public void BuildMap()
        {
            var canvas = GetComponent<Canvas>();
            var range = GetRange();
            foreach (var point in range)
            {
                var pointObject = Instantiate(_pointPrefab, _mapDiv.transform);
                pointObject.transform.SetParent(_mapDiv.transform, false);
                pointObject.transform.Translate(point * 50);
                pointObject.Initialize(_brushController);
                var pointData = pointObject.GetPointData();
                pointData.Position = point;
                _pointDataMap.Add(pointData);
            }
        }
        public Vector2[,] GetRange()
        {
            var range = new Vector2[(int)(_backGroundData.MaxX * 2 + 1), (int)(_backGroundData.MaxY * 2 + 1)];
            for (int i = 0; i <= _backGroundData.MaxX * 2; i++)
            {
                float x = _backGroundData.MinX + i;

                for (int j = 0; j <= _backGroundData.MaxY * 2; j++)
                {
                    float y = _backGroundData.MinY + j;
                    range[i, j] = new Vector2(x, y);
                }
            }
            return range;
        }
    }
}
