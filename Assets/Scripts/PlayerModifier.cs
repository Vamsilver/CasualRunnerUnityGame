using System;
using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Transform _topSpine;
    [SerializeField] private Transform _bottomSpine;
    [SerializeField] private Transform _colliderTransform;

    [SerializeField] private AudioSource _increaseSound;

    private float _widthMultiplier = 0.0005f;
    private float _heightMultiplier = 0.01f;

    private void Start()
    {
        SetWidth(Progress.Instance.Width);
        SetHeight(Progress.Instance.Height);
    }

    private void Update()
    {
        float offsetY = _height * _heightMultiplier + 0.17f;
        _topSpine.position = _bottomSpine.position + new Vector3(0, offsetY, 0);
        _colliderTransform.localScale = new Vector3(1, 1.84f + _height * _heightMultiplier, 1);

        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     AddWidth(20);
        // }
        // if (Input.GetKeyDown(KeyCode.H))
        // {
        //     AddHeight(20);
        // }
    }

    public void AddWidth(int value)
    {
        _width += value;
        UpdateWidth();
        
        if(value > 0) _increaseSound.Play();
    }

    public void AddHeight(int value)
    {
        _height += value;
        
        if(value > 0) _increaseSound.Play();
        // UpdateHeight(value);
    }

    private void SetWidth(int value)
    {
        _width = value;
        UpdateWidth();
    }

    private void SetHeight(int value)
    {
        _height = value;
    }

    // private void UpdateHeight(int value)
    // {
    //     float offsetY = _height * _heightMultiplier + 0.17f;
    //
    //     if (value > 0)
    //     {
    //         _topSpine.position = _bottomSpine.position + new Vector3(0, offsetY, 0);
    //         _colliderTransform.localScale = new Vector3(1, 1.84f + _height * _heightMultiplier, 1);
    //     }
    //     else
    //     {
    //         _topSpine.position = _topSpine.position - new Vector3(0, offsetY, 0);
    //         _colliderTransform.localScale = new Vector3(1, 1.84f + _height * _heightMultiplier, 1);
    //     }
    // }

    public void HitBarrier()
    {
        if (_height >= 50)
        {
            _height -= 50;
            // UpdateHeight(-50);
        }
        else if (_width >= 50)
        {
            _width -= 50;
            UpdateWidth();
        }
        else
        {
            Die();
        }
    }

    void UpdateWidth()
    {
        _renderer.material.SetFloat("_PushValue", _width * _widthMultiplier);
    }

    void Die()
    {
        FindObjectOfType<GameManager>().ShowFinishWindow();
        Destroy(gameObject);
    }


    //private void UpdateHeight(int sign)
    //{
    //    float offsetY = _height * _heightMultiplier * sign + 0.17f;


    //    _topSpine.position = _bottomSpine.position + new Vector3(0, offsetY, 0);
    //    _colliderTransform.localScale = new Vector3(1, 1.84f + _height * _heightMultiplier, 1);
    //}
}
