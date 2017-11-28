using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore203.Models;

namespace AspNetCore203.Repository {
    public interface ICampRepository {
        Task<IEnumerable<Camp>> CampsAsync ();
        Task<Camp> CampAsync (Guid campId);
        Task<Camp> InsertCampAsync (Camp camp);
        Task<bool> UpdateCampAsync (Guid campId);
        Task<bool> DeleteCampAsync (Guid campId);
        Task<bool> CampExistAsync (Guid campId);
        Task<bool> SaveCampAsync ();
    }
}