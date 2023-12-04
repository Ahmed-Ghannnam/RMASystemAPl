using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RMASystem.DAL
{
    public class CustomerPointsReadSPDto
    {
        [Column(TypeName = "decimal(18,3)")]
        public decimal PointsBalance { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal PointsAmount { get; set; }

    }
}
