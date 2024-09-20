using System;
using UnityEngine;

public class PairOfGates : MonoBehaviour
{
    [SerializeField] private GameObject _gateLeft;
    [SerializeField] private GameObject _gateRight;
    private void OnEnable()
    {
        _gateLeft.GetComponent<Gate>().onEnter += DestroyRight;
        _gateRight.GetComponent<Gate>().onEnter += DestroyLeft;
    }

    private void OnDisable()
    {
        _gateLeft.GetComponent<Gate>().onEnter += DestroyRight;
        _gateRight.GetComponent<Gate>().onEnter += DestroyLeft;
    }

    private void DestroyRight()
    {
        Destroy(_gateRight);
        Debug.Log("delete right");
        Destroy(gameObject);
    }
    private void DestroyLeft()
    {
        Destroy(_gateLeft);
        Debug.Log("delete left");
        Destroy(gameObject);
    }
}
