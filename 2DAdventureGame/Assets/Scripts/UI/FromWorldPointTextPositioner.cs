﻿using UnityEngine;
using System.Collections;

public class FromWorldPointTextPositioner : IFloatingTextPositioner {

    private readonly Camera _camera;
    private readonly Vector3 _worldPosition;
    private readonly float _speed;
    private float _timeToLive;
    private float _yOffSet;
    public FromWorldPointTextPositioner(Camera camera,Vector3 worldPosition,float timeToLive,float speed)
    {
        _camera = camera;
        _speed = speed;
        _timeToLive = timeToLive;
        _worldPosition = worldPosition;
    }
    
    public bool GetPosition(ref Vector2 position, GUIContent content, Vector2 size)
    {
        if ((_timeToLive -= Time.deltaTime) <= 0)
            return false;
        var screenPosition = _camera.WorldToScreenPoint(_worldPosition);
        position.x = screenPosition.x - (size.x / 2);
        position.y = Screen.height - screenPosition.y - _yOffSet;
        _yOffSet += Time.deltaTime * _speed;
        return true;
    }
}
