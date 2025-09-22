using UnityEngine;

public class FoodGameObject : MonoBehaviour
{
    public FoodSO foodSO;

    public Transform spawnPoint;

    public void Start()
    {
        foreach (Transform child in spawnPoint)
        {
            Destroy(child.gameObject);
        }
        Instantiate(foodSO.model, spawnPoint);
    }
    private void OnMouseDown()
    {
        Inventory.Instance.AddObject(foodSO.foodName,1);
        Destroy(this.gameObject);
    }

}
