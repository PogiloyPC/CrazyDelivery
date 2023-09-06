using PlayerInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OrderInterface
{
    public interface IOrder
    {
        public void SetParent(ITakeOrder obj);

        public void SetPosition(ITakeOrder obj);
    }
}
