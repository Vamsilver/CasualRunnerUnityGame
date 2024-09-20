using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private GameObject _brickEffectPrefab;
    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();

        if(playerModifier is null)
        {
            return;
        }
        
        playerModifier.HitBarrier();
        Instantiate(_brickEffectPrefab, transform.position, transform.rotation * Quaternion.Euler(-25,0,0));
        Destroy(gameObject);
    }
}
