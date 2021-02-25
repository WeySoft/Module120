using System;
using System.Diagnostics;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // ToDo
            Data.ToDo klasseA1 = new Data.ToDo();
            klasseA1.Titel = "ToDo 2";
            klasseA1.MachenBis = DateTime.Today;
            klasseA1.Abgeschlossen = false;
            klasseA1.Beschreibung = "Blabla bla";
            klasseA1.Widerholungen = 2;
            klasseA1.Teamfarbe = "Rot";
            Data.ToDo klasseA2 = new Data.ToDo();
            klasseA2.Titel = "ToDo 3";
            klasseA2.MachenBis = DateTime.Today;
            klasseA2.Abgeschlossen = false;
            klasseA2.Beschreibung = "Blabla bla";
            klasseA2.Widerholungen = 2;
            klasseA2.Teamfarbe = "Rot";
            Int64 klasseA1Id = klasseA1.Erstellen();
            Int64 klasseA2Id = klasseA2.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA1Id);
        }
        public static void DemoACreateKurz()
        {
            Data.ToDo klasseA2 = new Data.ToDo { Titel = "Artikel 2", Abgeschlossen = true, MachenBis = DateTime.Today, Teamfarbe = "Rot", Widerholungen=3, Beschreibung="blablabla", };
            Int64 klasseA2Id = klasseA2.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA2Id);
        }

        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.ToDo klasseA in Data.ToDo.LesenAlle())
            {
                Debug.Print("Artikel Id:" + klasseA.ToDoId + " Name:" + klasseA.Titel);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // ToDo ändert Attribute
            Data.ToDo klasseA1 = Data.ToDo.LesenID(1);
            klasseA1.Titel = "Artikel 1 nach Update";
            klasseA1.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            Data.ToDo.LesenID(5).Loeschen();
            Debug.Print("Artikel mit Id 2 gelöscht");
        }
        #endregion
    }
}
