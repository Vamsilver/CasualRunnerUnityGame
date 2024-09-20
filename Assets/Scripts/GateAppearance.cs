using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GateAppearance : MonoBehaviour
{
    [SerializeField] private Image _topImage;
    [SerializeField] private Image _glassImage;

    [SerializeField] private Color _colorPositive = Color.green;
    [SerializeField] private Color _colorNegative = Color.red;
    [SerializeField] private Color _colorNeutral = Color.gray;

    [SerializeField] private GameObject _expandLabel;
    [SerializeField] private GameObject _shrinkLabel;
    [SerializeField] private GameObject _upLabel;
    [SerializeField] private GameObject _downLabel;

    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    public void UpdateVisual(int value, DeformationType deformationType)
    {
        SetText(value);
        SetDeformationImage(deformationType, value);
    }

    public void SetText(int value)
    {
        string prefix = "";

        if (value > 0)
        {
            SetColor(_colorPositive);
            prefix = "+";
        }
        else if (value == 0)
            SetColor(_colorNeutral);
        else
        {
            SetColor(_colorNegative);
        }

        _textMeshProUGUI.text = prefix + value.ToString();
    }

    public void SetDeformationImage(DeformationType deformationType, int value)
    {
        _upLabel.SetActive(false);
        _downLabel.SetActive(false);
        _expandLabel.SetActive(false);
        _shrinkLabel.SetActive(false);

        switch (deformationType)
        {
            case DeformationType.Height:
                if(value > 0)
                {
                    _upLabel.SetActive(true);
                }
                else
                {
                    _downLabel.SetActive(true);
                }
                break;
            case DeformationType.Width:
                if (value > 0)
                {
                    _expandLabel.SetActive(true);
                }
                else
                {
                    _shrinkLabel.SetActive(true);
                }
                break;
        }
    }

    private void SetColor(Color color)
    {
        _topImage.color = color;
        _glassImage.color = new Color(color.r, color.g, color.b, 0.5f);
    }
}
