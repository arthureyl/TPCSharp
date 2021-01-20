using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class BdeMomentoTransactions
    {
        List<Transaction> _transactions;
        DateTime _date;

        public BdeMomentoTransactions(List<Transaction> transactions)
        {
            _transactions = new List<Transaction>(transactions);
            _date = DateTime.Now;
        }

        public List<Transaction> Transactions { get => _transactions; }

        public string Nom() {
            return "";
        }

        
    }
}
