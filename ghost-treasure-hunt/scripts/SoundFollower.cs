using UnityEngine;

public class FollowPlayer : MonoBehaviour //had issues with audio, quick fix is this code
{
    public Transform player;

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position;
        }
    }
}