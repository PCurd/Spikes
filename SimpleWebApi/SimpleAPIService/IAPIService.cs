using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleAPIService
{
    public interface IAPIService
    {
        IList<IValue> GetValues();
        IList<IValue> GetValues_ByIDs(IList<int> IDs);
        void StoreValues(IList<IValue> Values);
        void StoreValue(IValue Value);
        void StoreValue_ByID(int ID, IValue Value);
        IValue GetValue_ByID(int ID);
        void DeleteValues(IList<int> IDs);
        void DeleteValue(int ID);

    }
}
