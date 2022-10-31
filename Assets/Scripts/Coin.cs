using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]
public class Coin : MonoBehaviour
{
    private AudioSource _sound;
    private Coroutine _playSoundCouroutine;
    private SpriteRenderer _renderer;

    public bool CanDestroy => _sound.isPlaying == false;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Collected()
    {
        Color currentColor = _renderer.color;
        currentColor.a = 0f;
        _renderer.color = currentColor;

        if(_sound.isPlaying == false)
        {
            _sound.Play();
        }
    }
}
