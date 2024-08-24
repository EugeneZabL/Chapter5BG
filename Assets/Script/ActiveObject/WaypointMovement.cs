using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _waypointPref;

    private GameObject _point;

    public void OnActivate(Vector3 hit)
    {
        if(_point==null)
            _point = Instantiate(_waypointPref);

        _point.transform.position = hit;
    }
}
