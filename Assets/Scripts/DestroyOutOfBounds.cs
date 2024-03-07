using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _zBoundTop = 30;
    private float _zBoundBottom = -10;
    private float _xBoundRange = 25;

    private void Update()
    {
        if (transform.position.z > _zBoundTop)
        {
            gameObject.SetActive(false); // Deactivate projectile
        }
        else if (transform.position.z < _zBoundBottom)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > _xBoundRange || transform.position.x < -_xBoundRange)
        {
            Destroy(gameObject);
        }
    }
}
