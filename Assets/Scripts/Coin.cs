using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private float _speed = 2f;
    void Update()
    {
        transform.eulerAngles += new Vector3(0,30,20) * (_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<CoinManager>().AddCoin();
        Instantiate(_effectPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
