using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    [field: SerializeField] public int NumberOfCoins { get; private set; }

    private void Start()
    {
        NumberOfCoins = Progress.Instance.Coins; 
        _textMeshPro.text = NumberOfCoins.ToString();
    }

    public void AddCoin()
    {
        NumberOfCoins++;    
        _textMeshPro.text = NumberOfCoins.ToString();
    }

    public void SaveToProgress()
    {
        Progress.Instance.Coins = NumberOfCoins;
    }

    public bool RemoveCoins(int value)
    {
        if (value <= NumberOfCoins)
        {
            NumberOfCoins -= value;
            _textMeshPro.text = NumberOfCoins.ToString();
            return true;
        }

        return false;
    }
}
