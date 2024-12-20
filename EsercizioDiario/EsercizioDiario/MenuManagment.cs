using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace EsercizioDiario
{
    internal class MenuManagment
    {
        private static DAOPagina daoPagina = DAOPagina.GetInstance();
        private static void GetAllPages()
        {
            var entities = daoPagina.GetRecords();
            PrintList(entities);
        }
        private static void DeletePage()
        {
            Console.Write("Inserisci l'ID del Prodotto da eliminare: ");
            int id = int.Parse(Console.ReadLine());

            if (daoPagina.DeleteRecord(id))
            {
                Console.WriteLine("Prodotto eliminato con successo.");
            }
            else
            {
                Console.WriteLine("Errore nell'eliminazione del prodotto.");
            }
        }

        private static void PrintList(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                Console.WriteLine(entity);
            }
        }
    }
}
