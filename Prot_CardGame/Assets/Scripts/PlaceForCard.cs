using UnityEngine;

public class PlaceForCard : MonoBehaviour
{
    private SpriteRenderer spRender;

    private void Start()
    {
        spRender = GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            spRender.color = Color.red;
    }
}
