using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TvBase : MonoBehaviour
{
    public GameObject Setting, Home, Play, Pause;

    [SerializeField]
    private VideoPlayer _vide;

    public void OnPlayVideo()
    {
        _vide.Play();
    }

    public void OnPauseVideo()
    {
        _vide.Pause();
    }
}
