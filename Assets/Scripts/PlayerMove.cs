using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private float _mouseSensivity = 1f;
    [SerializeField] private Animator _animator;

    private float _oldMousePositionsX;
    private float _eulerY;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _oldMousePositionsX = Input.mousePosition.x;
            _animator.SetBool("isRun", true);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 newPos = transform.position + transform.forward * _speed * Time.deltaTime;
            newPos.x = Mathf.Clamp(newPos.x, -2f, 2f);

            transform.position = newPos;

            float deltaX = Input.mousePosition.x - _oldMousePositionsX;
            _oldMousePositionsX = Input.mousePosition.x;

            _eulerY += deltaX * _mouseSensivity;

            _eulerY = Mathf.Clamp(_eulerY, -70f, 70f);

            transform.eulerAngles = new Vector3(0, _eulerY, 0);
        }

        if(Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("isRun", false);
        }
    }
}
