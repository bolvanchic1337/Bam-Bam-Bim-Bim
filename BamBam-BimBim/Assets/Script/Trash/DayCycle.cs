using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayCycle : MonoBehaviour
{
    [System.Serializable]
    public struct DayAndNightMark
    {
        public float timeRatio;
        public Color color;
        public float intensity;
    }
    [SerializeField] private DayAndNightMark[] _marks;
    [SerializeField] private float _cycleLength = 24; // in seconds
    [SerializeField] private Light2D _light; // in seconds

    private float _currentCycleTime;
    private int _currentMarkIndex, _nextMarkIndex;
    private float _currentMarkTime, _nextMarkTime;
    private const float _TIME_CHECK_EPSILON = 0.1f;
    private float _marksTimeDifference;



    void Start() 
    {
        _currentMarkIndex = -1;
        _CycleMarks();

    }
    private void _CycleMarks() 
    {
        _currentMarkIndex = (_currentMarkIndex + 1) % _marks.Length;
        _nextMarkIndex = (_currentMarkIndex + 1) % _marks.Length;
        _currentMarkTime = _marks[_currentMarkIndex].timeRatio * _cycleLength;
        _nextMarkTime = _marks[_nextMarkIndex].timeRatio * _cycleLength;
        _marksTimeDifference = _nextMarkTime - _currentMarkTime;
        if (_marksTimeDifference < 0)
            _marksTimeDifference += _cycleLength;
    }
    private void Update()
    {
        _currentCycleTime = (_currentCycleTime + Time.deltaTime) % _cycleLength;

        // blend color/intensity
        float t = (_currentCycleTime - _currentMarkTime) / _marksTimeDifference;
        DayAndNightMark cur = _marks[_currentMarkIndex], next = _marks[_nextMarkIndex];
        _light.color = Color.Lerp(cur.color, next.color, t);
        _light.intensity = Mathf.Lerp(cur.intensity, next.intensity, t);
        // passed player mark?


        if (Mathf.Abs(_currentCycleTime - _nextMarkTime) < _TIME_CHECK_EPSILON)
        {
            _light.color = next.color;
            _light.intensity = next.intensity;
            _CycleMarks();

        }

    }

}