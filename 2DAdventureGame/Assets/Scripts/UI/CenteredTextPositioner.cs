﻿
using UnityEngine;
public class CenteredTextPositioner : IFloatingTextPositioner
{
    public readonly float _speed;
    private float _textPosition;

    public CenteredTextPositioner(float speed)
    {
        _speed = speed;
    }

    public bool GetPosition(ref Vector2 position, GUIContent content, Vector2 size)
    {
        _textPosition += Time.deltaTime * _speed;
        if (_textPosition > 1)
            return false;
        position =new Vector3(Screen.width/2f-(size.x/2f),Mathf.Lerp(Screen.height/2+size.y,0,_textPosition));
        return true;
    }
}

