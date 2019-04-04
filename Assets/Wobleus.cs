using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobleus : MonoBehaviour
{
    public float min;
    public float max;
    public float speed;
    public float lerpPadding;

    [ReadOnly]
    public float currentOffset = 0;
    [ReadOnly]
    public bool isIncreasing = false;

    private float headOffset;

    private void Start()
    {
        headOffset = transform.localPosition.y;
    }


    void Update()
    {
        float target;

        if (isIncreasing)
            target = max;
        else
            target = min;

        currentOffset = Mathf.Lerp(currentOffset, target, speed * Time.deltaTime);

        transform.localPosition = new Vector3(transform.localPosition.x, headOffset + currentOffset, transform.localPosition.z);

        if (isIncreasing)
        {
            if (currentOffset > max - lerpPadding)
                isIncreasing = false;
        }
        else
        {
            if (currentOffset < min + lerpPadding)
                isIncreasing = true;
        }
    }
}
