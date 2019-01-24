using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.DAL.Common;
using Tvita.Model.Table;

namespace Tvita.DAL.Repository
{
    public class OrderLandingPageRepository : Repository<tbl_OrderLandingPage, int>, IOrderLandingPageRepository
    {
        private Repository<tbl_OrderLandingPage, int> _orderLandingPageRepository;
        private DbSet<tbl_OrderLandingPage> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public OrderLandingPageRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _orderLandingPageRepository = new Repository<tbl_OrderLandingPage, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_OrderLandingPage>();
        }
        public int AddOrderLandingPage(OrderLandingPageModel model)
        {
            tbl_OrderLandingPage order = new tbl_OrderLandingPage();
            try
            {
                order.Customer_Address = model.Customer_Address;
                order.Customer_Name = model.Customer_Name;
                order.Customer_Note = model.Customer_Note;
                order.Customer_PhoneNum = model.Customer_PhoneNum;
                order.Customer_Email = model.Customer_Email;
                order.Date_Created = model.Date_Created;
                order.Is_Confirmed = model.Is_Confirmed;
                order.Product1 = model.Product1;
                order.Product2 = model.Product2;
                order.Product3 = model.Product3;
                order.QuantityPro1 = model.QuantityPro1;
                order.QuantityPro2 = model.QuantityPro2;
                order.QuantityPro3 = model.QuantityPro3;
                order.Time_Delivery = model.Time_Delivery;
                order.TotalPrice = model.TotalPrice;
                order.Date_Created = DateTime.Now;

                _dbContext.tbl_OrderLandingPage.Add(order);
                Save();
                return order.Order_ID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
