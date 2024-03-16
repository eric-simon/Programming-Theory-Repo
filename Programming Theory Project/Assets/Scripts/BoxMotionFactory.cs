using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMotionFactory
{
    public static BoxMotion SpawnBoxMotion(int level, int index)
    {
        //first box never moves
        if (0 == index)
        {
            return new NoMotionBox();
        }

        //first level is all lateral
        if (1 == level)
        {
            return SpawnLateralMotioBox();
        }

        //second level is all bobbing
        if (2 == level)
        {
            return SpawnBobbingMotionBox();
        }

        //after that, all levels are random
        var rnd = new System.Random();

        if (rnd.Next(0, 2) == 0)
        {
            return SpawnLateralMotioBox();
        }
        else
        {
            return SpawnBobbingMotionBox();
        }
    }

    public static BoxMotion SpawnLateralMotioBox()
    {
        var rnd = new System.Random();

        bool forward = rnd.Next(0, 2) == 0 ? true : false;

        float maxDistance = 7;

        float speed = 3;

        return new LateralMotionBox(forward, maxDistance, speed);
    }

    public static BoxMotion SpawnBobbingMotionBox()
    {
        float maxDistance = 3;

        float speed = 3;

        var delay = Random.Range(0, 2);

        return new BobbingMotionBox(maxDistance, speed, delay);
    }
}
