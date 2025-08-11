using UnityEngine;
[CreateAssetMenu(fileName = "food", menuName = "Cafe/Food")]
public class FoodSO : ScriptableObject
{
    public string foodName;
    public int cost;
    public int sell;

    public GameObject model;
    public Sprite icon;
}
