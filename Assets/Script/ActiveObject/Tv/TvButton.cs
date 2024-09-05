using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class TvButton : MonoBehaviour
{
    [Range(0,3)]
    public int TypeButton;      // 0 - Setting
                                // 1 - Home
                                // 2 - Play
                                // 3 - Pause

    private GameObject _setting, _home, _play, _pause;

    private TvBase _tv;

    private void OnEnable()
    {
        _tv = GameObject.FindGameObjectWithTag("MainTv").GetComponent<TvBase>();

        _setting = _tv.Setting;
        _home = _tv.Home;
        _play = _tv.Play;
        _pause = _tv.Pause;
    }

    public void OnActivate()
    {
        switch(TypeButton)
        {
            case 0:
                
                _home.SetActive(true);
                _play.SetActive(true);
                _pause.SetActive(true);

                _setting.SetActive(false);

                break;
            case 1:

                _setting.SetActive(true);
                _play.SetActive(false);
                _pause.SetActive(false);

                _home.SetActive(false);

                break;
            case 2:

                _tv.OnPlayVideo();

                break;
            case 3:

                _tv.OnPauseVideo();

                break;
        }

        Tween.Scale(transform,transform.localScale.x - 0.2f, 0.4f, Ease.InOutCubic,cycleMode:CycleMode.Yoyo,cycles:2);

    }
}
