using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CheckGround _checkMoveFront;
    [SerializeField] private CheckGround _checkMoveRight;
    [SerializeField] private CheckGround _checkMoveBack;
    [SerializeField] private CheckGround _checkMoveLeft;

    private bool _isDialog;

    private void Update()
    {
        CheckInputMove();
    }

    private void CheckInputMove()
    {
        if (_isDialog == false)
        {
            if (Input.GetKeyDown(KeyCode.W) && _checkMoveFront.AbleMove)
                transform.position += Vector3.forward * 4;

            if (Input.GetKeyDown(KeyCode.D) && _checkMoveRight.AbleMove)
                transform.position += Vector3.right * 2.5f;

            if (Input.GetKeyDown(KeyCode.S) && _checkMoveBack.AbleMove)
                transform.position += Vector3.back * 4;

            if (Input.GetKeyDown(KeyCode.A) && _checkMoveLeft.AbleMove)
                transform.position += Vector3.left * 2.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<WayPoint>(out WayPoint point))
        {
            if (point.TypeGround == TypeGround.Character)
            {
                _isDialog = true;
                print(_isDialog);
            }
            else
                _isDialog = false;
        }
    }


}
