using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class ClickerManager : MonoBehaviour
{
    public static ClickerManager Instance;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI minionsText;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        RefreshIU();
    }

    public void AddPoint(int pointsToAdd)
    {
        ClickerDataManager.points += pointsToAdd;
        RefreshIU();
    }
    public void AddMinions(int minionsToAdd)
    {
        ClickerDataManager.minions += minionsToAdd;
        RefreshIU();
    }

    public void BuyMinion(int cost)
    {
        if (ClickerDataManager.points >= cost)
        {
            AddPoint(-cost);
            AddMinions(1);
        }
    }
    public void RefreshIU()
    {
        pointsText.text = "x" + ClickerDataManager.points;
        minionsText.text = "x" + ClickerDataManager.minions;
    }
    public void GoToMiniGame(string miniGameSceneName)
    {
        SceneManager.LoadScene(miniGameSceneName);

    }


}
