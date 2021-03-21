using System;
using System.Collections.Generic;
using System.Text;


public interface ISubject
{
    void Attach(IObserver observer);
    void Notify();
}

