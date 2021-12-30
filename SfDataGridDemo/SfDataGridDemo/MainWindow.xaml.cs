using Microsoft.UI.Xaml;
using Syncfusion.UI.Xaml.DataGrid.Serialization;
using System.IO;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SfDataGridDemo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();            
        }       

        private void OnSerializeClicked(object sender, RoutedEventArgs e)
        {
            if (dataGrid == null) return;
            var serializationOptions = new SerializationOptions()
            {
                SerializeFiltering = true,
            };
            using (var file = File.Create("DataGrid.xml"))
            {
                dataGrid.Serialize(file, serializationOptions);
            }            
        }

        private void OnDeserializeClicked(object sender, RoutedEventArgs e)
        {
            if (dataGrid == null) return;
            var deserializationOptions = new DeserializationOptions()
            {
                DeserializeFiltering = true,
            };
            using (var file = File.Open("DataGrid.xml", FileMode.Open))
            {
                if (deserializationOptions.DeserializeFiltering == true)
                {
                    dataGrid.Deserialize(file, deserializationOptions);
                }
            }
        }
    }
}
