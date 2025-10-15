using UnityEngine;

public class FootstepSwapper : MonoBehaviour
{
    private TerrainChecker checker;
    public GameObject player;
    public Terrain t;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checker = FindFirstObjectByType<TerrainChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(checker.GetLayerName(player.transform.position, t));
        FirstPersonMovement movement = player.GetComponent<FirstPersonMovement>();
        if (movement != null)
        {
            movement.currentTexture = checker.GetLayerName(player.transform.position, t);
        }

    }
}
