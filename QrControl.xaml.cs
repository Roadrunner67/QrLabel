using QRCoder;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace QrLabel
{
    /// <summary>
    /// Interaction logic for QrControl.xaml
    /// </summary>
    public partial class QrControl : UserControl
    {
        public QrControl()
        {
            InitializeComponent();
        }

        public string QrUrl
        {
            get => (string)GetValue(UrlProperty);
            set => SetValue(UrlProperty, value);            
        }

        public static readonly DependencyProperty UrlProperty =
            DependencyProperty.Register(
            "QrUrl", typeof(string),
            typeof(QrControl),
            new FrameworkPropertyMetadata(string.Empty,
                FrameworkPropertyMetadataOptions.AffectsRender,
                (o, e) => ((QrControl)o).OnIsUrlChanged()));

        private void OnIsUrlChanged()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(
                QrUrl,
                QRCodeGenerator.ECCLevel.Q,
                true,
                true,
                QRCodeGenerator.EciMode.Utf8,
                6);
            XamlQRCode qrCode = new XamlQRCode(qrCodeData);
            DrawingImage qrCodeAsXaml = qrCode.GetGraphic(20);
            QrCodeImage.Source = qrCodeAsXaml;
        }
    }
}
