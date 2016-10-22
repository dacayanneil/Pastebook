using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PastebookEFModel;
using PastebookDataAccessLayer;
using PastebookBusinessLogicLayer;

namespace PastebookUILayer
{
    public class UserRegistrationModel
    {
        public PB_USER User { get; set; }
        public List<PB_REF_COUNTRY> CountryList {get; set;}
    }
}