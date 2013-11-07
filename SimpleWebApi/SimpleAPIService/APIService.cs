using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAPIService
{
    public class APIService : IAPIService
    {
        public IList<IValue> GetValues()
        {
            throw new NotImplementedException();
        }

        public IList<IValue> GetValues_ByIDs(IList<int> IDs)
        {
            throw new NotImplementedException();
        }

        public void StoreValues(IList<IValue> Values)
        {
            throw new NotImplementedException();
        }

        public void StoreValue(IValue Value)
        {
            throw new NotImplementedException();
        }

        public void StoreValue_ByID(int ID, IValue Value)
        {
            throw new NotImplementedException();
        }

        public IValue GetValue_ByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void DeleteValue(int ID)
        {
            throw new NotImplementedException();
        }
        public void DeleteValues(IList<int> ID)
        {
            throw new NotImplementedException();
        }
    }
}
