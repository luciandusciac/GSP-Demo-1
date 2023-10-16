using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform platform;
    public Transform startPos;
    public Transform endPos;

    public float speed = 5f;

    int direction = 1;

    private void Update()
    {
        Vector2 target = movementTarget();

        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)platform.position).magnitude;

        if(distance < 0.01f)
        {
            direction *= -1;
        }


    }

    private Vector2 movementTarget()
    {
        if(direction == 1)
        {
            return startPos.position;
        }
        else
        {
            return endPos.position;
        }
    }

}
