using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace EsercizioDiario
{
    internal class DAOPagina : IDAO
    {
        private IDatabase db;

        private DAOPagina()
        {
            db = new Database("Generation");
        }

        private static DAOPagina instance = null;
        public static DAOPagina GetInstance()
        {
            if (instance == null)
                instance = new DAOPagina();
            return instance;
        }
        public bool CreateRecord(Entity entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRecord(int recordId)
        {
            throw new NotImplementedException();
            // return db.UpdateDb($"DELETE FROM PaginaDiario WHERE id = {recordId};");
        }

        public Entity? FindRecord(int recordId)
        {
            throw new NotImplementedException();

            //var row = db.ReadOneDb($"SELECT * FROM PaginaDiario WHERE id = {recordId};");
            //if (row == null)
            //{
            //    Entity? e = new Pagina();
            //    e.FromDictionary(row);

            //    return e;
            //}
            //else
            //    return null;
        }

        public List<Entity> GetRecords()
        {
            throw new NotImplementedException();
        }

        public bool UpdateRecord(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
