﻿namespace TP9
{
    public interface IObservable
    {
        // Attach an observer to the subject.
        void Attach(IObserver observer);

        // Detach an observer from the subject.
        void Detach(IObserver observer);

        // Notify all observers about an event.
        void Notify(Produit produit, int quantite);
    }
}
