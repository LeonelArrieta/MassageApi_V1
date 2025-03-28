﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassageApi_V1.DTOs
{
    public class ShiftNewDTO
    {
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        public int ContactId { get; set; }
        public int MassageTypeId { get; set; }

    }
}
