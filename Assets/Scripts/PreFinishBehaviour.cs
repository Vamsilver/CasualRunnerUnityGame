using UnityEngine;

public class PreFinishBehaviour : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        
        float x = Mathf.MoveTowards(position.x, 0, Time.deltaTime * 2f);
        float z = position.z + 3f * Time.deltaTime;
        position = new Vector3(x, 0, z);
        transform.position = position;

        float rotationY = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, Time.deltaTime * 100f);
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
    }
}
