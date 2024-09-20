using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private int _heightCost = 20;
    [SerializeField] private int _widthCost = 20;

    [SerializeField] private int _heightAward = 25;
    [SerializeField] private int _widthAward = 25;
    
    [SerializeField] private CoinManager _coinManager;

    private PlayerModifier _playerModifier;

    private void Start()
    {
        _playerModifier = FindObjectOfType<PlayerModifier>();
    }

    public void BuyWidth()
    {
        if (_coinManager.NumberOfCoins < _widthCost)
            return;

        _coinManager.RemoveCoins(_widthCost);
        Progress.Instance.Coins = _coinManager.NumberOfCoins;
        Progress.Instance.Width += _widthAward;
        _playerModifier.AddWidth(_widthAward);
    }
    
    public void BuyHeight()
    {
        if (_coinManager.NumberOfCoins < _heightCost)
            return;

        _coinManager.RemoveCoins(_heightCost);
        Progress.Instance.Coins = _coinManager.NumberOfCoins;
        Progress.Instance.Height += _heightAward;
        _playerModifier.AddHeight(_heightAward);
    }
}
