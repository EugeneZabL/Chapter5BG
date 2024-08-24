using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class Point : MonoBehaviour
{
    [SerializeField]
    private Transform _marker;

    private Transform _player;

    private void FixedUpdate()
    {
        _marker.LookAt(_player);
        _marker.localPosition = new Vector3(0,_marker.position.y,0);
    }

    void OnEnable()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        Tween.Scale(_marker,new Vector3(0.8f,0.8f,0.8f),2f,Ease.InOutBack,cycleMode:CycleMode.Yoyo,cycles:-1);
        Tween.LocalPositionY(_marker, 0.8f, 2f, Ease.InOutBack, cycleMode: CycleMode.Yoyo, cycles: -1);
    }

    public void OnActivate()
    {
        Tween.Position(_player, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),0.7f,Ease.OutExpo).OnComplete(()=> Destroy(transform.parent.gameObject));
    }

}
