using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace MM_Localization {

  /// <summary>
  /// Interaction logic for wdwOption.xaml
  /// </summary>
  public partial class wdwOptions : Window {
    private MainWindow.config cfg = null;

    public wdwOptions(ref MainWindow.config cfg) {
      InitializeComponent();
      this.cfg = cfg;
      if (cfg != null) {
        txtOriginalFolder.Text = cfg.originalGameFolder;
        txtLocalizedFolder.Text = cfg.saveLocalizedTo;
      }
    }

    private void btnBrowseOriginal_Click(object sender, RoutedEventArgs e) {
      using (var dialog = new FolderBrowserDialog()) {
        dialog.SelectedPath = string.IsNullOrEmpty(txtOriginalFolder.Text) ?
          AppDomain.CurrentDomain.BaseDirectory : txtOriginalFolder.Text;
        if (System.Windows.Forms.DialogResult.OK == dialog.ShowDialog()) {
          txtOriginalFolder.Text = dialog.SelectedPath;
        }
      }
    }

    private void btnBrowseLocalized_Click(object sender, RoutedEventArgs e) {
      using (var dialog = new FolderBrowserDialog()) {
        dialog.SelectedPath = string.IsNullOrEmpty(txtLocalizedFolder.Text) ?
          AppDomain.CurrentDomain.BaseDirectory : txtLocalizedFolder.Text;
        if (System.Windows.Forms.DialogResult.OK == dialog.ShowDialog()) {
          txtLocalizedFolder.Text = dialog.SelectedPath;
        }
      }
    }

    private void btnOk_Click(object sender, RoutedEventArgs e) {
      if (cfg != null) {
        cfg.originalGameFolder = txtOriginalFolder.Text;
        cfg.saveLocalizedTo = txtLocalizedFolder.Text;
      }

      DialogResult = true;
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e) {
      DialogResult = false;
    }

    private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
      switch (e.Key) {
        case Key.Escape: btnCancel_Click(sender, new RoutedEventArgs()); break;
        default: break;
      }
    }
  }
}