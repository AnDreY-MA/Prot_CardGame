using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool _isDialog;

    private void Update()
    {
        if(_isDialog == false)
            MoveToPlace();
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

    private void MoveToPlace()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider.TryGetComponent<WayPoint>(out WayPoint place))
            {
                transform.position = new Vector3(place.gameObject.transform.position.x, 1.3f, place.gameObject.transform.position.z);
            }
        }
    }

    public bool SetDialogue() => _isDialog = !_isDialog;
}
