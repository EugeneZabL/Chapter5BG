using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class AnimateDestroy : MonoBehaviour
{
    public void OnActivate()
    {
        Tween.Scale(transform,new Vector3(0f,0f,0f),1f,Ease.InOutElastic).OnComplete(()=> Destroy(this));
    }
}
