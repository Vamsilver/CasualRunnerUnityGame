using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private DeformationType _deformationType;
    [SerializeField] private GateAppearance _gateAppearance;

    public delegate void OnEnter();
    public OnEnter onEnter;

    private void OnValidate()
    {
        _gateAppearance.UpdateVisual(_value, _deformationType);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = null;
        try
        {
            playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
        }
        catch
        {
            // ignored
        }

        if (playerModifier is null)
            return;

        onEnter?.Invoke();
        
        if (_deformationType == DeformationType.Height)
            playerModifier.AddHeight(_value);
        else if(_deformationType == DeformationType.Width)
            playerModifier.AddWidth(_value);
    }
}
