using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserCRUD.Controls
{
    /// <summary>
    /// CRUDUserControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CRUDUserControl : UserControl
    {
        public CRUDUserControl()
        {
            InitializeComponent();
        }

        //언어 변경 시 리스트뷰 내부에 바인딩 되어있는 값은 변하지 않으므로 컨버터를 한번 더 거치게 만듬
        private void cbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvUsers.Items.Refresh();
        }
    }
}
