using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore203.Models;

namespace AspNetCore203.Repository {
    public interface IClientRepository {
        Task<IEnumerable<Client>> ClientsAsync ();
        Task<Client> ClientAsync (Guid clientId);
        Task<Client> InsertClientAsync (Client client);
        Task<bool> UpdateClientAsync (Guid clientId);
        Task<bool> DeleteClientAsync (Guid clientId);
        Task<bool> ClientExistAsync (Guid clientId);
        Task<bool> SaveClientAsync ();
    }
}