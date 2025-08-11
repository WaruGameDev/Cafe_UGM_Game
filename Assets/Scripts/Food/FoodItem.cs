using UnityEngine;
using UnityEngine.UI;

public class FoodItem : MonoBehaviour
{
    public FoodSO foodSO;
    public Image icon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(foodSO.model, transform.position, Quaternion.identity);
        icon.sprite = foodSO.icon;
    }

    
}
