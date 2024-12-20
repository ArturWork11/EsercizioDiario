using System;

namespace EsercizioDiario
{
    internal class MenuManagement
    {
        private DAOPagina daoPagina;

        public MenuManagement()
        {
            daoPagina = DAOPagina.GetInstance();
        }

        public void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Scegli un'opzione:");
                Console.WriteLine("1. Crea una nuova pagina");
                Console.WriteLine("2. Elimina una pagina");
                Console.WriteLine("3. Aggiorna una pagina");
                Console.WriteLine("4. Leggi tutte le pagine");
                Console.WriteLine("5. Trova una pagina per ID");
                Console.WriteLine("6. Trova una pagina per data");
                Console.WriteLine("7. Trova una pagina per luogo");
                Console.WriteLine("8. Trova una pagina per descrizione");
                Console.WriteLine("9. Esci");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreatePage();
                        break;
                    case "2":
                        DeletePage();
                        break;
                    case "3":
                        UpdatePage();
                        break;
                    case "4":
                        ReadAllPages();
                        break;
                    case "5":
                        FindPageById();
                        break;
                    case "6":
                        FindPageByDate();
                        break;
                    case "7":
                        FindPageByLocation();
                        break;
                    case "8":
                        FindPageByDescription();
                        break;
                    case "9":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida, riprova.");
                        break;
                }
            }
        }

        private void CreatePage()
        {
            try
            {
                Pagina pagina = new Pagina();
                Console.WriteLine("Inserisci la data (yyyy-MM-dd):");
                pagina.DataGiorno = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci la coordinata X:");
                pagina.CoordinataX = double.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci la coordinata Y:");
                pagina.CoordinataY = double.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci il luogo:");
                pagina.Luogo = Console.ReadLine();
                Console.WriteLine("Inserisci la descrizione:");
                pagina.Descrizione = Console.ReadLine();

                bool success = daoPagina.CreateRecord(pagina);
                Console.WriteLine(success ? "Pagina creata con successo!" : "Errore nella creazione della pagina.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Errore nel formato dei dati inseriti: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Si è verificato un errore: " + ex.Message);
            }
        }

        private void DeletePage()
        {
            try
            {
                Console.WriteLine("Inserisci l'ID della pagina da eliminare:");
                int id = int.Parse(Console.ReadLine());

                bool success = daoPagina.DeleteRecord(id);
                Console.WriteLine(success ? "Pagina eliminata con successo!" : "Errore nell'eliminazione della pagina.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Errore nel formato dell'ID inserito: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Si è verificato un errore: " + ex.Message);
            }
        }

        private void UpdatePage()
        {
            Console.WriteLine("Inserisci l'ID della pagina da aggiornare:");
            int id = int.Parse(Console.ReadLine());

            Pagina pagina = (Pagina)daoPagina.FindRecord(id);
            if (pagina == null)
            {
                Console.WriteLine("Pagina non trovata.");
                return;
            }

            Console.WriteLine("Inserisci la nuova data (yyyy-MM-dd) (lascia vuoto per mantenere l'attuale):");
            string newData = Console.ReadLine();
            if (!string.IsNullOrEmpty(newData))
                pagina.DataGiorno = DateTime.Parse(newData);

            Console.WriteLine("Inserisci la nuova coordinata X (lascia vuoto per mantenere l'attuale):");
            string newX = Console.ReadLine();
            if (!string.IsNullOrEmpty(newX))
                pagina.CoordinataX = double.Parse(newX);

            Console.WriteLine("Inserisci la nuova coordinata Y (lascia vuoto per mantenere l'attuale):");
            string newY = Console.ReadLine();
            if (!string.IsNullOrEmpty(newY))
                pagina.CoordinataY = double.Parse(newY);

            Console.WriteLine("Inserisci il nuovo luogo (lascia vuoto per mantenere l'attuale):");
            string newLuogo = Console.ReadLine();
            if (!string.IsNullOrEmpty(newLuogo))
                pagina.Luogo = newLuogo;

            Console.WriteLine("Inserisci la nuova descrizione (lascia vuoto per mantenere l'attuale):");
            string newDescrizione = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDescrizione))
                pagina.Descrizione = newDescrizione;

            bool success = daoPagina.UpdateRecord(pagina);
            Console.WriteLine(success ? "Pagina aggiornata con successo!" : "Errore nell'aggiornamento della pagina.");
        }

        private void ReadAllPages()
        {
            var pages = daoPagina.GetRecords();
            foreach (Pagina pagina in pages)
            {
                Console.WriteLine(pagina);
            }
        }

        private void FindPageById()
        {
            Console.WriteLine("Inserisci l'ID della pagina da trovare:");
            int id = int.Parse(Console.ReadLine());

            Pagina pagina = (Pagina)daoPagina.FindRecord(id);
            if (pagina == null)
                Console.WriteLine("Pagina non trovata.");
            else
                Console.WriteLine(pagina);
        }

        private void FindPageByDate()
        {
            Console.WriteLine("Inserisci la data di inizio (yyyy-MM-dd):");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la data di fine (yyyy-MM-dd):");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            var pages = daoPagina.RicercaPerTempo(startDate, endDate);
            foreach (Pagina pagina in pages)
            {
                Console.WriteLine(pagina);
            }
        }

        private void FindPageByLocation()
        {
            Console.WriteLine("Inserisci il luogo da cercare:");
            string luogo = Console.ReadLine();

            var pages = daoPagina.RicercaPerLuogo(luogo);
            foreach (Pagina pagina in pages)
            {
                Console.WriteLine(pagina);
            }
        }

        private void FindPageByDescription()
        {
            Console.WriteLine("Inserisci la descrizione da cercare:");
            string description = Console.ReadLine();

            var pages = daoPagina.SearchByDescription(description);
            foreach (Pagina pagina in pages)
            {
                Console.WriteLine(pagina);
            }
        }
    }
}
