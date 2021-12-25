using UnityEngine;

public enum TypeCard { ATTACK, HEAL }

public class Ability : MonoBehaviour
{
    [SerializeField] private Data_Card _cardData;
    [SerializeField] private Transform _place;
    [SerializeField] private Transform _activedCard;

    private bool _isActive = false;
    private bool _selectingEnemy = false;

    private SpriteRenderer _sprite;

    private Vector3 _startPosition;

    private ActiveSystem _systemActiveCard;

    private Enemy _enemy = null;

    #region Behavior

    private void Update()
    {
        //if(_selectingEnemy) 
        SelectEnemy();
        //CheckSelectEnemy();
    }

    private void LateUpdate()
    {
        if(_enemy != null) Debug.Log(_enemy.gameObject.transform.position);
    }
    private void OnEnable()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _systemActiveCard = FindObjectOfType<ActiveSystem>();
        _startPosition = _place.position;
        _sprite.sprite = _cardData.spriteCard;
    }

    private void OnMouseEnter()
    {
        if(_isActive == false) transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
    }

    private void OnMouseDown()
    {
        //_systemActiveCard.SetActiveCard(this);
        transform.position = _activedCard.position;
        _isActive = true;
    }

    private void OnMouseExit()
    {
        if(_isActive == false) transform.position = _startPosition;
    }
    #endregion

    private void CheckSelectEnemy()
    {
        _systemActiveCard.SetActiveCard(this);
        _enemy = null;
        transform.position = _startPosition;
        _isActive = false;   
    }

    private void SelectEnemy()
    {
        if (_isActive == true && Input.GetMouseButtonDown(0))
        {   
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                    {
                        _enemy = enemy;
                        CheckSelectEnemy();
                    }
                }
        }
    }

    public Data_Card GetDataCard()
    {
        return _cardData;
    }

    public Enemy GetEnemy()
    {
        return _enemy;
    }
}
