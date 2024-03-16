using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//POLYMORPHISM
public interface BoxMotion
{
    public abstract Vector3 Move(Vector3 position);
}

public class NoMotionBox : BoxMotion
{
    public Vector3 Move(Vector3 position) { return position; }
}

public class SingleAxisMotion : BoxMotion
{
    public float _max;

    public float _min;

    private float _speed;

    private Vector3 _direction;

    private bool _forward = true;

    private bool initialPositionRecorded = false;

    private Vector3 InitialPosition;

    private float _delay;

    public SingleAxisMotion(bool forward, float max, float min, float speed, Vector3 direction, float delay)
    {
        _forward = forward;
        _max = max;
        _min = min;
        _speed = speed;
        _direction = direction;
        _delay = delay;
    }

    public Vector3 Move(Vector3 position)
    {
        if (initialPositionRecorded is false)
        {
            InitialPosition = position;
            initialPositionRecorded = true;
        }

        _delay -= Time.deltaTime;

        if (_delay > 0)
        {
            return position;
        }

        var sign = _forward ? 1 : -1;

        var _linearDelta = _speed * Time.deltaTime * sign;

        position = position + _direction * _linearDelta;

        var distanceVector = position - InitialPosition;

        var distanceInMotionDirection = Vector3.Dot(distanceVector, _direction);

        if (distanceInMotionDirection > _max)
        {
            var overage = distanceInMotionDirection - _max;

            var correction = -2 * overage;

            position = position + _direction * correction;

            _forward = false;
        }

        if (distanceInMotionDirection < _min)
        {
            var overage = distanceInMotionDirection - _min;

            var correction = -2 * overage;

            position = position + _direction * correction;

            _forward = true;
        }

        return position;
    }
}

//INHERITANCE
public class LateralMotionBox : SingleAxisMotion
{
    public LateralMotionBox(bool forward, float distance, float speed) : base(forward, distance, -distance, speed, new Vector3(0,0,1), 0)
    {

    }
}


public class BobbingMotionBox :  SingleAxisMotion
{
    public BobbingMotionBox(float distance, float speed, float delay) : base(true, distance, 0, speed, new Vector3(0, 1, 0), delay)
    {

    }
}
