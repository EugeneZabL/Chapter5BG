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

        //_marker.gameObject.SetActive(true);

        Tween.Scale(_marker,new Vector3(0.8f,0.8f,0.8f),2f,Ease.InOutBack,cycleMode:CycleMode.Yoyo,cycles:-1);
        Tween.LocalPositionY(_marker, 0.8f, 2f, Ease.InOutBack, cycleMode: CycleMode.Yoyo, cycles: -1);
    }

    public void OnActivate()
    {
        //_marker.gameObject.SetActive(false);
        Tween.Position(_player, new Vector3(transform.position.x, transform.position.y + _player.GetComponent<CharacterController>().height, transform.position.z), 0.7f, Ease.OutExpo).OnComplete(()=>  transform.parent.gameObject.SetActive(false));
    }

}
