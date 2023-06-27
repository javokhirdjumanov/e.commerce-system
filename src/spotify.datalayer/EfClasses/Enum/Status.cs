﻿using spotify.datalayer.pgsql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spotify.datalayer.EfClasses
{
    [Table("enum_status")]
    public class Status
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("status_name")]
        [StringLength(50)]
        public string StatusName { get; set; } = null!;

        [InverseProperty("Status")]
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
