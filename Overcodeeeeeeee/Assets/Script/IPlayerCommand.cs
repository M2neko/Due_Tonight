using UnityEngine;

namespace Player.Command
{
    public interface IPlayerCommand
    {
        void Execute(GameObject gameObject, GameObject Item);
    }

}