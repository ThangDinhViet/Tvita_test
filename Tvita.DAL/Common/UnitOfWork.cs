using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.DAL.Repository;
using Tvita.Model.Table;

namespace Tvita.DAL.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        #region "Private Member(s)"

        private bool _disposed = false;
        private readonly Tvita_TestEntities _context;

        #endregion
        public UnitOfWork()
        {
            _context = new Tvita_TestEntities();
        }

        #region "Public Member(s)"
        private Tvita_TestEntities _tvitaDbContext;
        public Tvita_TestEntities TvitaDbContext
        {
            get
            {
                if (_tvitaDbContext == null)
                    this._tvitaDbContext = _context;
                return _tvitaDbContext;
            }
        }
        private IRepository<tbl_Card, int> _cardRepository;
        public IRepository<tbl_Card, int> CardRepository
        {
            get
            {
                if (this._cardRepository == null)
                    this._cardRepository = new CardRepository(_context);
                return _cardRepository;
            }
        }

        private IRepository<tbl_Emoloyee, int> _employeeRepository;
        public IRepository<tbl_Emoloyee, int> EmployeeRepository
        {
            get
            {
                if (this._employeeRepository == null)
                    this._employeeRepository = new EmployeeRepository(_context);
                return _employeeRepository;
            }
        }

        private IEmployeeRepository _iemployeeRepository;
        public IEmployeeRepository IEmployeeRepository
        {
            get
            {
                if (this._iemployeeRepository == null)
                    this._iemployeeRepository = new EmployeeRepository(_context);
                return _iemployeeRepository;
            }
        }

        private IRepository<tbl_Product, int> _productRepository;
        public IRepository<tbl_Product, int> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                    this._productRepository = new ProductRepository(_context);
                return _productRepository;
            }
        }
        private IProductRepository _iproductRepository;
        public IProductRepository IProductRepository
        {
            get
            {
                if (this._iproductRepository == null)
                    this._iproductRepository = new ProductRepository(_context);
                return _iproductRepository;
            }
        }

        private IRepository<tbl_Branch, int> _branchRepository;
        public IRepository<tbl_Branch, int> BranchRepository
        {
            get
            {
                if (this._branchRepository == null)
                    this._branchRepository = new BranchRepository(_context);
                return _branchRepository;
            }
        }

        private IBranchRepository _ibranchRepository;
        public IBranchRepository IBranchRepository
        {
            get
            {
                if (this._ibranchRepository == null)
                    this._ibranchRepository = new BranchRepository(_context);
                return _ibranchRepository;
            }
        }

        private IRepository<tbl_GroupProduct, int> _groupProductRepository;
        public IRepository<tbl_GroupProduct, int> GroupProductRepository
        {
            get
            {
                if (this._groupProductRepository == null)
                    this._groupProductRepository = new GroupProductRepository(_context);
                return _groupProductRepository;
            }
        }

        private IGroupProductRepository _igroupProductRepository;
        public IGroupProductRepository IGroupProductRepository
        {
            get
            {
                if (this._igroupProductRepository == null)
                    this._igroupProductRepository = new GroupProductRepository(_context);
                return _igroupProductRepository;
            }
        }

        private IRepository<tbl_Farm, int> _farmRepository;
        public IRepository<tbl_Farm, int> FarmRepository
        {
            get
            {
                if (this._farmRepository == null)
                    this._farmRepository = new FarmRepository(_context);
                return _farmRepository;
            }
        }

        private IFarmRepository _ifarmRepository;
        public IFarmRepository IFarmRepository
        {
            get
            {
                if (this._ifarmRepository == null)
                    this._ifarmRepository = new FarmRepository(_context);
                return _ifarmRepository;
            }
        }

        private IProductionUnitRepository _iproductionUnitRepository;
        public IProductionUnitRepository IProductionUnitRepository
        {
            get
            {
                if (this._iproductionUnitRepository == null)
                    this._iproductionUnitRepository = new ProductionUnitRepository(_context);
                return _iproductionUnitRepository;
            }
        }

        private IRepository<tbl_ProductionUnit, int> _productionUnitRepository;
        public IRepository<tbl_ProductionUnit, int> ProductionUnitRepository
        {
            get
            {
                if (this._productionUnitRepository == null)
                    this._productionUnitRepository = new ProductionUnitRepository(_context);
                return _productionUnitRepository;
            }
        }

        private IProductHistoryRepository _iproductHistoryRepository;
        public IProductHistoryRepository IProductHistoryRepository
        {
            get
            {
                if (this._iproductHistoryRepository == null)
                    this._iproductHistoryRepository = new ProductHistoryRepository(_context);
                return _iproductHistoryRepository;
            }
        }

        private IRepository<tbl_ProductHistory, int> _productHistoryRepository;
        public IRepository<tbl_ProductHistory, int> ProductHistoryRepository
        {
            get
            {
                if (this._productHistoryRepository == null)
                    this._productHistoryRepository = new ProductHistoryRepository(_context);
                return _productHistoryRepository;
            }
        }

        private IProductsInFarmRepository _iproductsInFarmRepository;
        public IProductsInFarmRepository IProductsInFarmRepository
        {
            get
            {
                if (this._iproductsInFarmRepository == null)
                    this._iproductsInFarmRepository = new ProductsInFarmRepository(_context);
                return _iproductsInFarmRepository;
            }
        }

        private IRepository<tbl_ProductsInFarm, int> _productsInFarmRepository;
        public IRepository<tbl_ProductsInFarm, int> ProductsInFarmRepository
        {
            get
            {
                if (this._productsInFarmRepository == null)
                    this._productsInFarmRepository = new ProductsInFarmRepository(_context);
                return _productsInFarmRepository;
            }
        }

        private IPictureRepository _iPictureRepository;
        public IPictureRepository IPictureRepository
        {
            get
            {
                if (this._iPictureRepository == null)
                    this._iPictureRepository = new PictureRepository(_context);
                return _iPictureRepository;
            }
        }

        private IRepository<tbl_Picture, int> _PictureRepository;
        public IRepository<tbl_Picture, int> PictureRepository
        {
            get
            {
                if (this._PictureRepository == null)
                    this._PictureRepository = new PictureRepository(_context);
                return _PictureRepository;
            }
        }

        private ISubjectRepository _iSubjectRepository;
        public ISubjectRepository ISubjectRepository
        {
            get
            {
                if (this._iSubjectRepository == null)
                    this._iSubjectRepository = new SubjectRepository(_context);
                return _iSubjectRepository;
            }
        }

        private IRepository<tbl_Subject, int> _SubjectRepository;
        public IRepository<tbl_Subject, int> SubjectRepository
        {
            get
            {
                if (this._SubjectRepository == null)
                    this._SubjectRepository = new SubjectRepository(_context);
                return _SubjectRepository;
            }
        }

        private ISubSubjectRepository _iSubSubjectRepository;
        public ISubSubjectRepository ISubSubjectRepository
        {
            get
            {
                if (this._iSubSubjectRepository == null)
                    this._iSubSubjectRepository = new SubSubjectRepository(_context);
                return _iSubSubjectRepository;
            }
        }

        private IRepository<tbl_SubSubject, int> _SubSubjectRepository;
        public IRepository<tbl_SubSubject, int> SubSubjectRepository
        {
            get
            {
                if (this._SubSubjectRepository == null)
                    this._SubSubjectRepository = new SubSubjectRepository(_context);
                return _SubSubjectRepository;
            }
        }

        private IPostRepository _iPostRepository;
        public IPostRepository IPostRepository
        {
            get
            {
                if (this._iPostRepository == null)
                    this._iPostRepository = new PostRepository(_context);
                return _iPostRepository;
            }
        }

        private IRepository<tbl_Post, int> _PostRepository;
        public IRepository<tbl_Post, int> PostRepository
        {
            get
            {
                if (this._PostRepository == null)
                    this._PostRepository = new PostRepository(_context);
                return _PostRepository;
            }
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    var rs = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    rs = rs + eve.ValidationErrors.Aggregate(rs, (current, ve) => current + ("<br />" + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage)));
                    //rs.LogMessage(this);
                }
                //e.LogError(this);
                throw e;
            }
            catch (DbUpdateException ex)
            {
                //ex.LogError(this);
                throw ex;
            }
            catch (Exception ex)
            {
                //ex.LogError(this);
                throw ex;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
