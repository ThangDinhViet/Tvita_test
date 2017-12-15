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
    public class CardRepository : Repository<tbl_Card, int>, ICardRepository
    {
        private Repository<tbl_Card, int> _cardRepository;
        private DbSet<tbl_Card> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public CardRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _cardRepository = new Repository<tbl_Card, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_Card>();
        }
        public List<CardModel> GetAllCard()
        {
            List<CardModel> result = new List<CardModel>();
            result = (from c in _dbContext.tbl_Card
                     select new CardModel
                     {
                         ID_Order = c.ID_Order,
                         Card_TotalPrice = c.Card_TotalPrice,
                         Card_TotalPriceSelloff = c.Card_TotalPriceSelloff,
                         Card_TraveliingFee = c.Card_TraveliingFee,
                         ID_Payments = c.ID_Payments,
                         IsConfirmSucess = c.IsConfirmSucess,
                         IsDelete = c.IsDelete,
                         Card_ID = c.Card_ID
                     }).ToList();
            return result;
        }
    }
}
