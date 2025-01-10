using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAttribute = SQLite.TableAttribute;


namespace MauiAppinleveropdracht
{
    [Table("Game")]
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerID { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }
    }
}
