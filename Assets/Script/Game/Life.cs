using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TinyFactory.Game.GamePlay
{
    public interface ILife
    {
        void Move();
        void Death();
    }

    public interface IStealer
    {
        void Steal();
    }

    public class Life : MonoBehaviour
    {
        private int lifeID;

    }
}




