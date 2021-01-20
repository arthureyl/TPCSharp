using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class BdeMomentoStock
    {
        Stock _stock;
        DateTime _date;

        public BdeMomentoStock(Stock stock)
        {
                _stock = new Stock(stock.StockProduit);
                _date = DateTime.Now;
        }

        public Stock GetStock { get => _stock; }

        public string Nom()
        {
            return "";
        }
    }
}
