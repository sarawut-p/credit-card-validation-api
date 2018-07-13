using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardValidationAPI.DAL.Repositories
{
    public class CredicardRepository : ICreditCardRepository
    {
        public virtual bool IsExist(string credit)
        {
            return true;
        }
    }
}
