using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulumScript : MonoBehaviour
{
    public float delta = 1.2f;  // Amount to move left and right from the start point
    public float speed = 1.4f;
    public float direction = 1;
    private Quaternion startPos;
    void Start()
    {
        startPos = transform.rotation;
    }
    void Update()
    {
        Quaternion a = startPos;
        a.x += direction * (delta * Mathf.Sin(Time.time * speed));
        transform.rotation = a;
    }
}
