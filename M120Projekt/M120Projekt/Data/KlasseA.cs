using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.Data
{
    public class KlasseA
    {
        #region Datenbankschicht
        [Key]
        public Int64 KlasseAId { get; set; }
        [Required]
        public String TextAttribut { get; set; }
        [Required]
        public DateTime DatumAttribut { get; set; }
        [Required]
        public Boolean BooleanAttribut { get; set; }
        #endregion
        #region Applikationsschicht
        public KlasseA() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static List<KlasseA> LesenAlle()
        {
            using (var db = new Context())
            {
                return (from record in db.KlasseA select record).ToList();
            }
        }
        public static KlasseA LesenID(Int64 klasseAId)
        {
            using (var db = new Context())
            {
                return (from record in db.KlasseA where record.KlasseAId == klasseAId select record).FirstOrDefault();
            }
        }
        public static List<KlasseA> LesenAttributGleich(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.KlasseA where record.TextAttribut == suchbegriff select record).ToList();
            }
        }
        public static List<KlasseA> LesenAttributWie(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.KlasseA where record.TextAttribut.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.TextAttribut == null || this.TextAttribut == "") this.TextAttribut = "leer";
            if (this.DatumAttribut == null) this.DatumAttribut = DateTime.MinValue;
            using (var db = new Context())
            {
                db.KlasseA.Add(this);
                db.SaveChanges();
                return this.KlasseAId;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return this.KlasseAId;
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
            return KlasseAId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
