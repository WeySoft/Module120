using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace M120Projekt.Data
{
    public class ToDo
    {
        #region Datenbankschicht
        [Key]
        public Int64 ToDoId { get; set; }
        [Required]
        public String Titel { get; set; }
        [Required]
        public DateTime MachenBis { get; set; }
        [Required]
        public Boolean Abgeschlossen { get; set; }
        [Required]
        public Int64 Widerholungen { get; set; }
        [Required]
        public String Beschreibung { get; set; }
        [Required]
        public String Teamfarbe { get; set; }

        #endregion
        #region Applikationsschicht
        public ToDo() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static List<ToDo> LesenAlle()
        {
            using (var db = new Context())
            {
                return (from record in db.ToDo select record).ToList();
            }
        }
        public static ToDo LesenID(Int64 klasseAId)
        {
            using (var db = new Context())
            {
                return (from record in db.ToDo where record.ToDoId == klasseAId select record).FirstOrDefault();
            }
        }
        public static List<ToDo> LesenAttributGleich(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.ToDo where record.Titel == suchbegriff select record).ToList();
            }
        }
        public static List<ToDo> LesenAttributWie(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.ToDo where record.Titel.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.Titel == null || this.Titel == "") this.Titel = "leer";
            if (this.MachenBis == null) this.MachenBis = DateTime.MinValue;
            using (var db = new Context())
            {
                db.ToDo.Add(this);
                db.SaveChanges();
                return this.ToDoId;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return this.ToDoId;
            }
        }
        public void Loeschen()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public override string ToString()
        {
            return ToDoId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
