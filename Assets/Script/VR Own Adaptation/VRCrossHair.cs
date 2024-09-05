using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;
using UnityEngine.UI;

public class VRCrossHair : MonoBehaviour
{
    private float _RETICLE_MAX_DISTANCE = 10f;

    public LayerMask InteractionLayer = 1 << 8;

    public LayerMask ActionLayer = 1 << 8;

    private Slider _slider;

    private GameObject _gazedAtObject = null;

    private Tween _tweenRotate, _tweenFill;

    private RaycastHit _hit;


    void Start()
    {
        _slider = transform.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool IsInteractive(GameObject gameObject)
    {
        return (1 << gameObject?.layer & InteractionLayer) != 0;
    }

    private bool IsAction(GameObject gameObject)
    {
        return (1 << gameObject?.layer & ActionLayer) != 0;
    }

    private void SetParams(GameObject gameObject)
    {
        if(IsAction(gameObject))
        {
            _tweenRotate = Tween.LocalRotation(transform,new Vector3(0,0,45),0.6f);
            _tweenFill = Tween.UISliderValue(_slider, 1f, 1.7f,startDelay:0.5f).OnComplete(() => CursorAction());
        }
        else if(IsInteractive(gameObject))
        {
            _tweenRotate = Tween.LocalRotation(transform, new Vector3(0, 0, 45), 0.6f);
        }
    }

    private void CursorAction()
    {
        _gazedAtObject.SendMessage("OnActivate",_hit.point);
        ResetParams();
    }

    private void ResetParams()
    {
        _tweenFill.Stop();
        _tweenRotate.Stop();

        _tweenFill = Tween.UISliderValue(_slider, 0f, 0.3f);
        _tweenRotate = Tween.LocalRotation(transform, new Vector3(0, 0, 0), 0.2f);
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit, _RETICLE_MAX_DISTANCE))
        {
            Debug.Log(_hit.transform.position);
            // GameObject detected in front of the camera.
            if (_gazedAtObject != _hit.transform.gameObject)
            {
                // New GameObject.
                if (IsInteractive(_gazedAtObject))
                {
                   // _gazedAtObject?.SendMessage("OnPointerExit");
                }

                ResetParams();

                _gazedAtObject = _hit.transform.gameObject;

                SetParams(_gazedAtObject);

                if (IsInteractive(_gazedAtObject))
                {
                    //_gazedAtObject.SendMessage("OnPointerEnter");
                }
            }
        }
        else
        {
            if (_gazedAtObject != null)
            {
                // No GameObject detected in front of the camera.
                if (IsInteractive(_gazedAtObject))
                {
                     //_gazedAtObject?.SendMessage("OnPointerExit");
                }

                _gazedAtObject = null;
                ResetParams();
            }
        }

    }
}
