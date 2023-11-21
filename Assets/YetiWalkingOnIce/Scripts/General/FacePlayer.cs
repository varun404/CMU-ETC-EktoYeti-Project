using UnityEngine;

public class FacePlayer : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        FaceTowardsPlayer();
    }

    Vector3 directionToPlayer;
    void FaceTowardsPlayer()
    {
        directionToPlayer = Camera.main.transform.position - transform.position;
        directionToPlayer = Vector3.ProjectOnPlane(directionToPlayer, Vector3.up);
        transform.rotation = Quaternion.LookRotation(directionToPlayer);
    }
}
