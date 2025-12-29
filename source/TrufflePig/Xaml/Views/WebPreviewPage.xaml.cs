using Microsoft.UI.Xaml.Controls;
using TrufflePig.ViewModels;

namespace TrufflePig.Xaml.Views;

public sealed partial class WebPreviewPage : Page
{
    public WebPreviewPage()
    {
        InitializeComponent();
        ViewModel = App.GetService<WebPreviewViewModel>();
        ViewModel.SetWebViewAsync(WebView);
    }

    public WebPreviewViewModel ViewModel
    {
        get;
    }

    private void PopupDimensionsReference_SizeChanged(object sender, Microsoft.UI.Xaml.SizeChangedEventArgs e)
    {
        PopupDimensionsReferenceSizeChanged();
    }

    private void PopupDimensionsReferenceSizeChanged()
    {
        var containerWidth = PopupDimensionsReference.ActualWidth;
        var containerHeight = PopupDimensionsReference.ActualHeight;

        VisualizerPopupContent.Width = containerWidth;
        VisualizerPopupContent.Height = containerHeight;

        VisualizerPopup.HorizontalOffset = (WebView.ActualWidth - containerWidth) / 2;
        VisualizerPopup.VerticalOffset = (WebView.ActualHeight - containerHeight) / 2;
    }

    private void VisualizerPopup_Opened(object sender, object e) => PopupDimensionsReferenceSizeChanged();
}