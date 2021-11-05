using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject placeCard;

    private Vector3 posCard;

    public bool isClickCard { get; private set; }

    private int countClick = 0;

    private void Start()
    {
        posCard = transform.position;
    }

    public void OnMouseEnter()
    {
        transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y + 1, transform.position.z);
    }

    private void OnMouseExit()
    {
        transform.position = posCard;
    }

    private void OnMouseOver()
    {     
            if (Input.GetMouseButtonDown(0))
            {
                if (countClick == 0)
                {
                    countClick += 1;
                    placeCard.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                    countClick = 0;
                    placeCard.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }                      
    }
}
