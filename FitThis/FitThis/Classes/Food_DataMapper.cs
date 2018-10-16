using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace FitThis.Classes
{
    public class Food_DataMapper: IDataMapper<Food>
    {
        public override List<Food> Select(out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Create(Food instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Food Read(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Food Read(Food instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Food instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Food instance, out Exception exError)
        {
            throw new NotImplementedException();
        }
    }
}