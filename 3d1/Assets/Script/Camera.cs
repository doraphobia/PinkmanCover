using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;        // Selected player
    public Vector3 offset;          
    public float followSpeed = 5f;  

    public float moveSpeed = 10f;   

    public float heightOffset = 2.0f; 

    void Update()
    {
        // Manual camera movement 
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(h, 0, v);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);


    }

    void LateUpdate()
    {
        // follow the player 
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(
                target.position.x + offset.x,
                target.position.y + heightOffset + offset.y,  // Adjust height 
                target.position.z + offset.z
            );

            //  move the camera to 
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
