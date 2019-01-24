using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.DAL.Repository;
using Tvita.Model;

namespace Tvita.DAL.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Tvita_TestEntities TvitaDbContext { get; }
        IRepository<tbl_Card, int> CardRepository { get; }
        IRepository<tbl_Emoloyee, int> EmployeeRepository { get; }
        IEmployeeRepository IEmployeeRepository { get; }
        IRepository<tbl_Product, int> ProductRepository { get; }
        IProductRepository IProductRepository { get; }
        IRepository<tbl_Branch, int> BranchRepository { get; }
        IBranchRepository IBranchRepository { get; }
        IRepository<tbl_GroupProduct, int> GroupProductRepository { get; }
        IGroupProductRepository IGroupProductRepository { get; }
        IRepository<tbl_Farm, int> FarmRepository { get; }
        IFarmRepository IFarmRepository { get; }
        IRepository<tbl_ProductionUnit, int> ProductionUnitRepository { get; }
        IProductionUnitRepository IProductionUnitRepository { get; }
        IRepository<tbl_ProductHistory, int> ProductHistoryRepository { get; }
        IProductHistoryRepository IProductHistoryRepository { get; }
        IRepository<tbl_ProductsInFarm, int> ProductsInFarmRepository { get; }
        IProductsInFarmRepository IProductsInFarmRepository { get; }
        IRepository<tbl_Picture, int> PictureRepository { get; }
        IPictureRepository IPictureRepository { get; }
        IRepository<tbl_Subject, int> SubjectRepository { get; }
        ISubjectRepository ISubjectRepository { get; }
        IRepository<tbl_SubSubject, int> SubSubjectRepository { get; }
        ISubSubjectRepository ISubSubjectRepository { get; }
        IRepository<tbl_Post, int> PostRepository { get; }
        IPostRepository IPostRepository { get; }
        IRepository<PU, int> PURepository { get; }
        IPURepository IPURepository { get; }
        IRepository<tbl_OrderLandingPage, int> OrderLandingPageRepository { get; }
        IOrderLandingPageRepository IOrderLandingPageRepository { get; }
        void SaveChanges();
    }
}
