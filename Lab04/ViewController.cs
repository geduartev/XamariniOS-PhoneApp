using System;

using UIKit;

namespace Lab04
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var TranslatedNumber = string.Empty;

            TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                var Translator = new PhoneTranslator();
                TranslatedNumber = Translator.ToNumber(PhoneNumberText.Text);

                if (string.IsNullOrWhiteSpace(TranslatedNumber))
                {
                    CallButton.SetTitle("Llamar", UIControlState.Normal);
                    CallButton.Enabled = false;
                }
                else
                {
                    CallButton.SetTitle($"Llamar al {TranslatedNumber}", UIControlState.Normal);
                    CallButton.Enabled = true;
                }
            };

            CallButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                var URL = new Foundation.NSUrl($"tel:{TranslatedNumber}");
                if (!UIApplication.SharedApplication.OpenUrl(URL))
                {
                    var Alert = UIAlertController.Create("No soportado",
                        "El esquema 'tel:' no es soportado en este dispositivo",
                        UIAlertControllerStyle.Alert);
                    Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(Alert, true, null);
                }
            };

            Button0.TouchUpInside += (object sender, EventArgs e) => { ShowDisplay("0"); };
            Button1.TouchUpInside += (object sender, EventArgs e) => { ShowDisplay("1"); };
            Button2.TouchUpInside += (object sender, EventArgs e) => { ShowDisplay("2"); };
            Button3.TouchUpInside += (object sender, EventArgs e) => { ShowDisplay("3"); };
            Button4.TouchUpInside += (object sender, EventArgs e) => { ShowDisplay("4"); };
            Button5.TouchUpInside += (object sender, EventArgs e) => { ShowDisplay("5"); };
            Button6.TouchUpInside += (object sender, EventArgs e) => { ShowDisplay("6"); };
            Button7.TouchUpInside += (object sender, EventArgs e) => { ShowDisplay("7"); };
            Button8.TouchUpInside += (object sender, EventArgs e) => { ShowDisplay("8"); };
            Button9.TouchUpInside += (object sender, EventArgs e) => { ShowDisplay("9"); };
            ButtonAsterisc.TouchUpInside += (object sender, EventArgs e) => { ShowDisplay("*"); };
            ButtonSharp.TouchUpInside += (object sender, EventArgs e) => { ShowDisplay("#"); };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void ShowDisplay(string number)
        {
            Display.Text = $"{Display.Text}{number}";
        }
    }
}