using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<Table> tables;
    public List<Client> clients;


    public Table GetFreeTable()
    {
        for (int i = 0; i < tables.Count; i++)
        {
            if (!tables[i].isOccupied)
                return tables[i];
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
            SetTableForClient(clients[0]);
        }
    }
    


}
