using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class BdeMomentoClients
    {
        Dictionary<Client, decimal> _clients;
        DateTime _date;

        public BdeMomentoClients(Dictionary<Client, decimal> clients)
        {
            _clients = new Dictionary<Client, decimal>(clients);
            _date = DateTime.Now;
        }

        public Dictionary<Client, decimal> Clients { get => _clients; }

        public string Nom()
        {
            return "";
        }
    }
}
