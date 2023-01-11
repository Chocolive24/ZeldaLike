using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private ChestRoom _chestRoom;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void OpenTheChest()
    {
        _chestRoom.Activate();
    }
}
