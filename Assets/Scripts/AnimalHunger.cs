using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    [SerializeField] private Slider _hungerSlider;
    [SerializeField] private Vector3 _scaleSlider = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] private Vector3 _offsetSlider = new Vector3(0, 2.5f, 0);
    [SerializeField] private int _amountToBeFed;
    private GameManager _gameManager;
    private int _currentFedAmount = 0;

    private void Start()
    {
        _hungerSlider.maxValue = _amountToBeFed;
        _hungerSlider.value = 0;
        _hungerSlider.fillRect.gameObject.SetActive(false);
        _hungerSlider.transform.localScale = _scaleSlider;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        _hungerSlider.transform.position = gameObject.transform.position + _offsetSlider;
    }

    public void FeedAnimal(int amount)
    {
        _currentFedAmount += amount;
        _hungerSlider.fillRect.gameObject.SetActive(true);
        _hungerSlider.value = _currentFedAmount;

        if(_currentFedAmount >= _amountToBeFed)
        {
            _gameManager.AddScore(_amountToBeFed);
            Destroy(gameObject);
        }
    }
}
