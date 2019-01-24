using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.BAL.Interface;
using Tvita.DAL.Common;
using Tvita.Model.Table;

namespace Tvita.BAL.Implement
{
    public class OrderLandingPageManager : IOrderLandingPageManager
    {
        public List<OrderLandingPageModel> GetAll()
        {
            List<OrderLandingPageModel> result = new List<OrderLandingPageModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.OrderLandingPageRepository.QueryAll().Select(x => new OrderLandingPageModel
                {
                    Customer_Address = x.Customer_Address,
                    Customer_Name = x.Customer_Name,
                    Customer_Note = x.Customer_Note,
                    Customer_PhoneNum = x.Customer_PhoneNum,
                    Customer_Email = x.Customer_Email,
                    Date_Created = x.Date_Created,
                    Is_Confirmed = x.Is_Confirmed,
                    Order_ID = x.Order_ID,
                    Product1 = x.Product1,
                    Product2 = x.Product2,
                    Product3 = x.Product3,
                    QuantityPro1 = x.QuantityPro1,
                    QuantityPro2 = x.QuantityPro2,
                    QuantityPro3 = x.QuantityPro3,
                    Time_Delivery = x.Time_Delivery,
                    TotalPrice = x.TotalPrice
                }).ToList();
            }
            return result;
        }
        
        public int AddOrderLandingPage(OrderLandingPageModel model)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    //var exist = uOW.OrderLandingPageRepository.GetWhere(x => x.Branch_Code == model.Branch_Code).FirstOrDefault();
                    //if (exist == null)
                    {
                        return uOW.IOrderLandingPageRepository.AddOrderLandingPage(model);
                    }
                    //else
                    //    return false;

                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
