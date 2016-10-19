using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pastebook
{
    public class RegistrationViewModel
    {
        public UserModel User { get; set; }
        public IEnumerable<CountryModel> CountryList { get; set; }
    }
}