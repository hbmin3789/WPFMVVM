using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLib.Enumerables;

namespace UserCRUD.Languages
{
    public class LanguageHelper
    {
        public static List<ELanguages> LanguageList
        {
            get
            {
                var retval = new List<ELanguages>();
                foreach(var i in Enum.GetValues(typeof(ELanguages)))
                {
                    retval.Add((ELanguages)i);
                }

                return retval;
            }
        }
    }
}
