using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class EFLecturer
    {
        public int PracticeId { get; set; }

        public virtual EFPractice Practice { get; set; }
        public virtual ICollection<EFModule> Modules { get; set; }

    }
}