using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Microsoft.Data.SqlClient;

namespace EsercizioDiario
{
    internal class DAOPagina : IDAO
    {
        #region Singleton
        private Database db;

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
        #endregion

        public bool CreateRecord(Entity entity)
        {
            Pagina pagina = (Pagina)entity;
            string query = "INSERT INTO PaginaDiario (dataGiorno,coordinataX," +
                            "coordinataY,luogo,descrizione) " +
                            "VALUES " +
                            $"('{((Pagina)entity).DataGiorno.ToString("yyyy-MM-dd")}', " +
                            $"  {((Pagina)entity).CoordinataX}, " +
                            $"  {((Pagina)entity).CoordinataY}, " +
                            $" '{((Pagina)entity).Luogo.Replace("'", "''")}', " +
                            $" '{((Pagina)entity).Descrizione.Replace("'", "''")}')";

            var command = new SqlCommand(query);
            return db.UpdateDb(command);
        }

        public bool DeleteRecord(int recordId)
        {
            string query = $"SELECT * FROM Prodotti WHERE id = {recordId};";
            return db.UpdateDb(query);
            // return db.UpdateDb($"DELETE FROM PaginaDiario WHERE id = {recordId};");
        }

        public Entity? FindRecord(int recordId)
        {
            string query = $"SELECT * FROM Prodotti WHERE id = {recordId};";
            var ris = db.ReadOneDb(query);

            if (ris != null)
            {
                Pagina e = new Pagina();
                e.FromDictionary(ris);
                return e;
            }
            else
                return null;

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
            List<Entity> ris = new();
            string query = "SELECT * FROM Prodotti;";
            var command = new SqlCommand(query);

            var righe = db.ReadDb(command);

            foreach (var r in righe)
            {
                Entity e = new Pagina();
                e.FromDictionary(r);
                ris.Add(e);
            }
            return ris; ;
        }

        public bool UpdateRecord(Entity entity)
        {
            string query = "UPDATE Prodotti SET " +
                           $"(dataGiorno = '{((Pagina)entity).DataGiorno.ToString("yyyy-MM-dd")}', " +
                           $" coordinataX = {((Pagina)entity).CoordinataX}, " +
                           $" coordinataY = {((Pagina)entity).CoordinataY}, " +
                           $" luogo = '{((Pagina)entity).Luogo.Replace("'", "''")}', " +
                           $" descrizione = '{((Pagina)entity).Descrizione.Replace("'", "''")}') "; 
            
            var command = new SqlCommand(query);
            return db.UpdateDb(command);
        }
    }
}
