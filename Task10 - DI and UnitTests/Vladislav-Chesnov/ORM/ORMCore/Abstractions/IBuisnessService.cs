﻿using System.Collections.Generic;
using System.Linq;
using ORMCore.Repositories;
using ORMCore.Model;

namespace ORMCore
{
    public interface IBuisnessService
    {
        void AddNewClient(string name, string surname, string phoneNumber, decimal balance);
        void AddNewStockType(string newTypeName, decimal price);
        void AddStockToClient(string stockType, Client client);
        IQueryable<Client> GetAllClients();
        IQueryable<Client> GetClientsInBlackZone();
        IQueryable<Client> GetClientsInOrangeZone();
        IQueryable<Deal> GetDeals();
        ICollection<Stock> GetClientStocksById(int id);
        IQueryable<StockType> GetStockTypes();
        void NewDeal(Deal deal);
    }
}