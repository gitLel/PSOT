using UnityEngine;
using Zenject;

public class GuestSpawner
{
    [Inject]
    private RandomNameGenerator nameGenerator;
    public GameObject SpawnGuest(Guest guest, Transform spot)
    {
        var guestPrefab = Object.Instantiate(guest.gameObject, spot);
        guestPrefab.transform.position = spot.position;
        guestPrefab.GetComponent<Guest>().Name = SetNameForGuest();
        guestPrefab.GetComponent<Guest>().ID = SetIDForGuest();
        guestPrefab.name = guestPrefab.GetComponent<Guest>().Name + " (Guest)";

        return guestPrefab;
    }
    private string SetNameForGuest()
    {
        var name = nameGenerator.GetName(true);
        return name;
    }
    private string SetIDForGuest()
    {
        var id = StorageConfig.GetID().ToString();
        return id;
    }
}
