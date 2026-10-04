using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public int lane;
    public float speed = 10f;

    private Transform player;
    private float triggerDistance = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // objects move towards playing instead of player moving forward, makes it look infinite
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // hit check, dont need collisions stuff
        if (Mathf.Abs(transform.position.z - player.position.z) < triggerDistance)
        {
            PlayerController pc = player.GetComponent<PlayerController>();
            if (pc != null && lane == pcLane(pc))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        // removc
        if (transform.position.z < player.position.z - 10f)
        {
            Destroy(gameObject);
        }
    }

    int pcLane(PlayerController pc)
    {
        return Mathf.RoundToInt(pc.transform.position.x / 4f); // laneWidth = 4
    }
}