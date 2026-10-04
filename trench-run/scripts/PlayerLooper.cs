using UnityEngine;

public class PlayerLooper : MonoBehaviour
{
    public float resetZ = 100f;
    public float teleportBackZ = 0f;
    public float obstacleShiftZ = 100f;
    void Update()
    {
        if (transform.position.z >= resetZ)
        {
            float shiftAmount = resetZ - teleportBackZ;

            //resets pos
            Vector3 newPos = transform.position;
            newPos.z = teleportBackZ;
            transform.position = newPos;

            //moves obstacles withs player
            Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
            foreach (var obstacle in obstacles)
            {
                obstacle.transform.position -= Vector3.forward * shiftAmount;
            }
        }
    }
}