using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    interface Observable
    {
        public void Subscribe(Observer o);
        public void Unsubscribe(Observer o);
        public void Notify(int payload);
    }
}
