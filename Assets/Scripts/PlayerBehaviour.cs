using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PreFinishBehaviour _preFinishBehaviour;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _playerMove.enabled = false;
        _preFinishBehaviour.enabled = false;
    }

    public void Play()
    {
        _playerMove.enabled = true;
    }

    public void StartPreFinishBehaviour()
    {
        _playerMove.enabled = false;
        _preFinishBehaviour.enabled = true;
    }

    public void StartFinishBehaviour()
    {
        _preFinishBehaviour.enabled = false;
        _animator.SetTrigger("isDance");
    }
}
