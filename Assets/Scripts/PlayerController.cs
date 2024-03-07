using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 15.0f;
    private float _horizontalInput;
    private float _verticalInput;
    private float _xBoundRange = 10;
    private float _zBoundTop = 15;
    private float _zBoundBottom = 0;
    private GameObject _pooledProjectile;
    private Vector3 _projectileOffset = new Vector3(0, 1, 1);


    private void Update()
    {
        // Check bounds
        if (transform.position.x < -_xBoundRange)
            transform.position = new Vector3(-_xBoundRange, transform.position.y, transform.position.z);

        if (transform.position.x > _xBoundRange)
            transform.position = new Vector3(_xBoundRange, transform.position.y, transform.position.z);

        if (transform.position.z < _zBoundBottom)
            transform.position = new Vector3(transform.position.x, transform.position.y, _zBoundBottom);

        if (transform.position.z > _zBoundTop)
            transform.position = new Vector3(transform.position.x, transform.position.y, _zBoundTop);

        // Player movement
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * _horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * _speed * _verticalInput);

        //Shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Get an object object from the pool
            _pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (_pooledProjectile != null)
            {
                _pooledProjectile.SetActive(true); // activate it
                _pooledProjectile.transform.position = transform.position + _projectileOffset; // position it at player
            }
        }
    }
}
