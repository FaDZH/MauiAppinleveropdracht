using SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using TableAttribute = SQLite.TableAttribute;

namespace MauiAppinleveropdracht
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
    }
}
