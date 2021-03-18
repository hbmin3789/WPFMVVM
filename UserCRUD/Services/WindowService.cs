using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using ViewModelLib.Enumerables;
using ViewModelLib.Interfaces;

namespace UserCRUD.Services
{
    public class WindowService : IWindowService
    {
        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }
        
        public void SetLanguage(ELanguages lang)
        {
            string uri = "";
            switch (lang)
            {
                case ELanguages.Korean:
                    uri = "ko-KR";
                    break;
                case ELanguages.English:
                    uri = "en-US";
                    break;
            }

            foreach(var resource in App.Current.Resources.MergedDictionaries)
            {
                if (resource.Source.OriginalString.Contains("Languages"))
                {
                    App.Current.Resources.Remove(resource);
                    break;
                }
            }

            uri = "Languages/" + uri + ".xaml";

            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(uri,UriKind.Relative) });
        }
    }
}
