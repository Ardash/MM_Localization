using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace MM_Localization {

  /// <summary>
  /// Interaction logic for wdwOption.xaml
  /// </summary>
  public partial class wdwOptions : Window {
    public string originalFolderPath = "";
    public string localizedFolderPath = "";

    public wdwOptions() {
      InitializeComponent();
    }

    private void btnBrowseOriginal_Click(object sender, RoutedEventArgs e) {
      using (var dialog = new FolderBrowserDialog()) {
        if (System.Windows.Forms.DialogResult.OK == dialog.ShowDialog()) {
          txtOriginalFolder.Text = dialog.SelectedPath;
        }
      }
    }

    private void btnBrowseLocalized_Click(object sender, RoutedEventArgs e) {
      using (var dialog = new FolderBrowserDialog()) {
        if (System.Windows.Forms.DialogResult.OK == dialog.ShowDialog()) {
          txtLocalizedFolder.Text = dialog.SelectedPath;
        }
      }
    }

    private void btnOk_Click(object sender, RoutedEventArgs e) {
      originalFolderPath = txtOriginalFolder.Text;
      localizedFolderPath = txtLocalizedFolder.Text;

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