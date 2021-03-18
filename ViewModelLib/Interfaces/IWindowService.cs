using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLib.Enumerables;

namespace ViewModelLib.Interfaces
{
    public interface IWindowService
    {
        void ShowMessage(string msg);
        void SetLanguage(ELanguages lang);
    }
}
