using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player; //To be assigned to player
    public float smoothTime = 0.2f; //Camera smoothness
    public Vector3 velocity = Vector3.zero;
    public Vector3 offset; //To keep the camera at a fixed distance
        
    void LateUpdate()
    {   
        //Checking if a player has been assigned or not
        if(player == null) return;

        //Base the target off the player's position + offset 
        Vector3 targetPosition = player.position + offset;
        targetPosition.z = -10; //Keeping z position to -10 to ensure camera aligns properly

        //To smoothly move the camera to the player's position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
