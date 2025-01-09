using SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using TableAttribute = SQLite.TableAttribute;

namespace MauiAppinleveropdracht
{
    [Table("Gebruiker")]
    public class Gebruiker
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Wachtwoord { get; set; }
    }
}
