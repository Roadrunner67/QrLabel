using QRCoder;

using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public string Url
        {
            get => (string)GetValue(UrlProperty);
            set => SetValue(UrlProperty, value);            
        }

        public static readonly DependencyProperty UrlProperty =
            DependencyProperty.Register(
            "Url", typeof(string),
            typeof(QrControl),
            new FrameworkPropertyMetadata(false,
                FrameworkPropertyMetadataOptions.AffectsRender,
                (o, e) => ((QrControl)o).OnIsUrlChanged()));

        private void OnIsUrlChanged()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(
                Url,
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
