using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    [Table("users")]
    [PrimaryKey(nameof(Guid))]
    public class User
    {
        
        [Column("guid")]
        public Guid Guid {get;set;}
        [Column("login")]
        public string Login {get;set;} = string.Empty;
        [Column("user_name")]
        public string UserName {get;set;} = string.Empty;
        [Column("email")]
        public string Email {get;set;} = string.Empty;
    }
}