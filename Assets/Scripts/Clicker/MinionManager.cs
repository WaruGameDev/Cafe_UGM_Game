
using UnityEngine;

public class MinionManager : MonoBehaviour
{
    public static MinionManager Instance;
    public Transform spawnPoint;
    public GameObject minionPrefab;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < ClickerDataManager.minions; i++)
        {
            SpawnMinion();
        }
    }

    private void SpawnMinion()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-10f, 10f),
            0,
            Random.Range(-10f, 10f)
        );
        Instantiate(minionPrefab, spawnPoint.position + randomOffset, Quaternion.identity);
    }
    public void ChangeScene(string newScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(newScene);
    }
}
