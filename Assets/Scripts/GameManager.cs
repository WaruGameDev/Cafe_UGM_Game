using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<Table> tables;
    public List<Client> clients;

    public List<FoodSO> menu;
    public GameObject clientObject;
    public Transform spawnPoint;



    public Client CreateClient()
    {
        Client clt = Instantiate(clientObject, spawnPoint.position, Quaternion.identity).GetComponent<Client>();
        clients.Add(clt);
        clt.pedido = RandomChooseFoodFromMenu();
        return clt;
    }
    public Table GetFreeTable()
    {
        for (int i = 0; i < tables.Count; i++)
        {
            if (!tables[i].isOccupied)
            {
                tables[i].isOccupied = true;
                return tables[i];
            }

        }
        Debug.Log("No hay mesas disponibles");
        return null;
    }

    public void SetTableForClient(Client client)
    {
        client.ChooseTable(GetFreeTable().chair);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetTableForClient(CreateClient());
        }
    }

    public FoodSO RandomChooseFoodFromMenu()
    {
        return menu[Random.Range(0, menu.Count)];
    }
    


}
