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
