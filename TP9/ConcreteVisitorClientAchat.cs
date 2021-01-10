using System;
using System.Collections.Generic;
using System.Linq;

namespace TP9
{
    public class ConcreteVisitorClientAchat : IVisitor
    {
        private Dictionary<Client, decimal> _clientsAchat;

        public ConcreteVisitorClientAchat()
        {
            _clientsAchat = new Dictionary<Client, decimal>();
        }

        public Dictionary<Client, decimal> ClientsAchat { get => _clientsAchat; set => _clientsAchat = value; }
        public string VisitTransaction(Transaction transaction)
        {
            if (ClientsAchat.ContainsKey(transaction.ClientTransaction)){
                ClientsAchat[transaction.ClientTransaction] += transaction.PrixTransaction;
            }
            else
            {
                ClientsAchat.Add(transaction.ClientTransaction, transaction.PrixTransaction);
            }
            string bestClients = "";

            foreach (KeyValuePair<Client, decimal> client in ClientsAchat.OrderByDescending(key => key.Value))
            {
                bestClients += "Client: "+ client.Key.GetName() + ", Value: "+ client.Value.ToString()+  Environment.NewLine;
            }
            return bestClients;
        }
    }
}
