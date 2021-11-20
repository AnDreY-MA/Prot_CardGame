using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "CardPlace")
        {
            Debug.Log("Hit");
        }

    }
}
