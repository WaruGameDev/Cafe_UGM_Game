using UnityEngine;
using UnityEngine.Events;

public class MinionManager : MonoBehaviour
{
    public static MinionManager Instance;
    public Transform spawnPoint;
    public GameObject minionPrefab;
    public UnityEvent onMinionSpawned;

    public System.Action<float, int, float> onMinionClicked;

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
        onMinionSpawned?.Invoke();

    }
    public void ChangeScene(string newScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(newScene);
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Debug.Log($"Hit {hitInfo.collider.name}");
                if (hitInfo.collider.CompareTag("Minion"))
                {
                    onMinionClicked?.Invoke(2.5f, 1, 0.5f);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Debug.Log($"Hit {hitInfo.collider.name}");
                if (hitInfo.collider.CompareTag("Minion"))
                {
                    onMinionClicked -= hitInfo.collider.GetComponent<Minion>().Jump;
                }
            }
        }
    }
}
