using UnityEngine;
//Contributor grid code week2assignment
public class GridGenerator : MonoBehaviour
{
    [Header("Grid Settings")]
    public GameObject Sphere;
    public int width = 3;
    public int height = 5;
    public float spacing = 1.5f;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 position = new Vector3(x * spacing, 0, y * spacing);
                Instantiate(Sphere, position, Quaternion.identity, transform);
            }
        }
    }
}
