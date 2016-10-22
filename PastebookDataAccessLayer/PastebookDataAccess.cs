using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastebookEFModel;

namespace PastebookDataAccessLayer
{
    public class PastebookDataAccess
    {
        public List<PB_POST> RetrievePost()
        {
            var postList = new List<PB_POST>();
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    postList = context.PB_POST
                                .Include("PB_USER")
                                .Include("PB_LIKE")
                                .Include("PB_COMMENT")
                                .Include("PB_NOTIFICATION")
                                .ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return postList;
        }

    }
}
