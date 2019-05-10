using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopApp {
  public partial class FormChoice : Form {
    public FormChoice() {
      InitializeComponent();
    }

    public FormChoice(List<LsProductItem> pis) {
      InitializeComponent();

      foreach( LsProductItem pi in pis ) {
        ListViewItem lvi = listView.Items.Add(pi.Name);

        lvi.SubItems.Add(pi.MacAdr);
        lvi.Tag = pi;
      }
      listView.Columns[0].Width = -1;
      listView.Columns[1].Width = -2;
      listView.Items[0].Selected = true;
    }

    public int SelectedIndex {
      get { return listView.SelectedIndices.Count == 1 ? listView.SelectedIndices[0] : -1; }
    }
  }
}
