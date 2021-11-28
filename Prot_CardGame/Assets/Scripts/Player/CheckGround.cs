using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool AbleMove { get; private set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<WayPoint>(out WayPoint ground))
        {
            if (ground.TypeGround == TypeGround.AbleMove)
                AbleMove = true;
            else if(ground.TypeGround == TypeGround.UnAbleMove)
                AbleMove = false;

        }
        print(gameObject.name + " " + AbleMove);
    }
}
