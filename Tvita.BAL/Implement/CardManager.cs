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
    public class CardManager : ICardManager
    {
        public List<CardModel> GetAllCard()
        {
            List<CardModel> result = new List<CardModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.CardRepository.QueryAll().Select(x => new CardModel{
                    Card_TotalPrice = x.Card_TotalPrice,
                    Card_TotalPriceSelloff = x.Card_TotalPriceSelloff
                }).ToList();
            }
            return result;
        }
        public CardModel GetFirstCard()
        {
            CardModel result = new CardModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                var test = uOW.CardRepository.FirstOrDefault();
                result.Card_TotalPriceSelloff = test.Card_TotalPriceSelloff;
            }
            return result;
        }
    }
}
