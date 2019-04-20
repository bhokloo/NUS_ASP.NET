using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class EFModule
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EFLecturer> Lecturers { get; set; }
    }
}