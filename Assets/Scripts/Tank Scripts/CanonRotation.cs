using UnityEngine;

public class CanonRotation : MonoBehaviour
{
    private void Update()
    {
        faceMouse();
    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 mouseDirection = new Vector3(mousePosition.x - transform.position.x ,0f,  mousePosition.z - transform.position.z);

        transform.forward = mouseDirection;
        

    }

}
