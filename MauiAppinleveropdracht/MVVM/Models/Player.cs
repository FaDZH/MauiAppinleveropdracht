using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAttribute = SQLite.TableAttribute;


namespace MauiAppinleveropdracht;

[Table("Player")]
public class Player
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }

    [ForeignKey(nameof(User))]
    public int UserID { get; set; }

    [MaxLength(50)]
    public string PlayerName { get; set; }
}
