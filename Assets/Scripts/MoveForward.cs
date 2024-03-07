using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField]private float _speed = 10.0f;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }
}
