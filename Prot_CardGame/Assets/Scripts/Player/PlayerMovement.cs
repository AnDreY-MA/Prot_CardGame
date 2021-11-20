using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _checkMoveFront;
    [SerializeField] private Transform _checkMoveRight;
    [SerializeField] private Transform _checkMoveBack;
    [SerializeField] private Transform _checkMoveLeft;

    private void Update()
    {
        CheckInputMove();
    }

    private void CheckInputMove()
    {
        if (Input.GetKeyDown(KeyCode.W))
            transform.position = new Vector3(_checkMoveFront.position.x, _checkMoveFront.position.y, _checkMoveFront.position.z);   

        if(Input.GetKeyDown(KeyCode.D))
            transform.position = new Vector3(_checkMoveRight.position.x, _checkMoveRight.position.y, _checkMoveRight.position.z);

        if (Input.GetKeyDown(KeyCode.S))
            transform.position = new Vector3(_checkMoveBack.position.x, _checkMoveBack.position.y, _checkMoveBack.position.z);

        if (Input.GetKeyDown(KeyCode.A))
            transform.position = new Vector3(_checkMoveLeft.position.x, _checkMoveLeft.position.y, _checkMoveLeft.position.z);
    }
}
