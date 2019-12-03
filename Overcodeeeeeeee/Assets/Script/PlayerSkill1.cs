using System;
using Player.Command;
using UnityEngine;

namespace Player.Command
{
    public class PlayerSkill1 : MonoBehaviour, IPlayerCommand
    {
        public void Execute(GameObject gameObject, GameObject Item)
        {
            // Create Canvas
            Destroy(Instantiate(Item, gameObject.transform.position, Quaternion.identity), 10f);
            Item.SetActive(true);

            // TODO: Throw
            
            Debug.Log("11");
        }
    }
}