using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Models.ViewModels
{
    public class StudentRegistrationViewModel
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public String FirstName{ get; set; }
        public String LastName { get; set; }

    }
}
