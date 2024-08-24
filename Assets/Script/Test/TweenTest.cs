using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class TweenTest : MonoBehaviour
{
    public GameObject Cube;
    void Start()
    {
        Tween.Scale(Cube.transform,2,5f);
        Tween.Scale(Cube.transform, 0, 5f);
    }

}
