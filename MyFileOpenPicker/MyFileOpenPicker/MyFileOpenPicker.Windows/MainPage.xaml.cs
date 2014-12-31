using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyFileOpenPicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Open_Click(object sender, RoutedEventArgs e)
        {
            // Create File Open Picker
            FileOpenPicker picker = new FileOpenPicker();

            // Set SuggestedStartLocation    
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;

            // Set Thumbnail Preview
            picker.ViewMode = PickerViewMode.Thumbnail;

            // Filter for file types.
            picker.FileTypeFilter.Clear();
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".bmp");

            // Call Multiple Files Pick
            var selectedFiles = await picker.PickMultipleFilesAsync();

            // Loop over selected list and display names
            foreach (StorageFile file in selectedFiles)
            {
                filesListView.Items.Add(file.DisplayName);
            }
        }
    }
}
