using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else
        {
            other.gameObject.SetActive(false); //Deactivate projectile
            gameObject.GetComponent<AnimalHunger>().FeedAnimal(1);
        }
    }
}
