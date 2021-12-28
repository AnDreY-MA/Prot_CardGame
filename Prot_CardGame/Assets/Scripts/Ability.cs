using UnityEngine;

public enum TypeCard { ATTACK, HEAL, DEFEND }
public enum TypeAttack { NONE, CLOSE, RANGE }

public class Ability : MonoBehaviour
{
    [SerializeField] private Data_Card _cardData;
    [SerializeField] private Transform _place;
    [SerializeField] private ActivedCard _activedCard;

    private bool _isActive = false;

    private SpriteRenderer _sprite;

    private Vector3 _startPosition;

    private ActiveSystem _systemActiveCard;

    private Enemy _enemy = null;

    #region Behavior

    private void Awake() => _startPosition = _place.position;

    private void Update() => SelectEnemy();

    private void OnEnable()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _systemActiveCard = FindObjectOfType<ActiveSystem>();       
        _sprite.sprite = _cardData.spriteCard;
        _activedCard = FindObjectOfType<ActivedCard>();
    }

    private void OnMouseEnter()
    {
        if(_isActive == false) 
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
    }

    private void OnMouseDown()
    {
        if (_activedCard.ActivededCard == null)
        {
            transform.position = _activedCard.gameObject.transform.position;
            _isActive = true;
            _activedCard.SetAbilityCard(this);
        }
    }

    private void OnMouseExit()
    {
        if(_isActive == false) transform.position = _startPosition;
    }
    #endregion

    private void CheckSelectEnemy()
    {
        _systemActiveCard.SetActiveCard(this);
        _activedCard.RemoveAbilityCard();
        _enemy = null;
        transform.position = _startPosition;
        _isActive = false;   
    }

    private void SelectEnemy()
    {
        if (_isActive == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit) && hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                        _enemy = enemy;
                        CheckSelectEnemy();
                }
            }

            else if (Input.GetMouseButtonDown(1))
            {
                _isActive = false;
                transform.position = _startPosition;
                _activedCard.RemoveAbilityCard();
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

    public void SetStartPlace(Transform place) => _place = place;
}
