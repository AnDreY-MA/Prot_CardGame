using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CheckGround _checkMoveFront;
    [SerializeField] private CheckGround _checkMoveRight;
    [SerializeField] private CheckGround _checkMoveBack;
    [SerializeField] private CheckGround _checkMoveLeft;

    private void Update()
    {
        CheckInputMove();
    }

    private void CheckInputMove()
    {
        if (Input.GetKeyDown(KeyCode.W) && _checkMoveFront.AbleMove)
            transform.position += Vector3.forward * 4;

        if (Input.GetKeyDown(KeyCode.D) && _checkMoveRight.AbleMove)
            transform.position += Vector3.right * 2.5f;

        else if (Input.GetKeyDown(KeyCode.S) && _checkMoveBack.AbleMove)
            transform.position += Vector3.back * 4;

        else if (Input.GetKeyDown(KeyCode.A) && _checkMoveLeft.AbleMove)
            transform.position += Vector3.left * 2.5f;
    }
}
