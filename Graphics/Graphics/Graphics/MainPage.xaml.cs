using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Diagnostics;

namespace Graphics {
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage {
		Stopwatch stopwatch = new Stopwatch();
		bool pageIsActive;
		Color color = Color.Red;
		float height1;
		float height2;
		float sum;


		public MainPage() {
			InitializeComponent();
		}
		//protected async override void OnAppearing() {
		//	base.OnAppearing();
		//	pageIsActive = true;
		//	await AnimationLoop();
		//}
		protected override void OnDisappearing() {
			base.OnDisappearing();
			pageIsActive = false;
		}
		private static float PointsPerInch = Device.RuntimePlatform == "UWP" ? 96 : 160;
		private static float PPI = (float)DeviceDisplay.MainDisplayInfo.Density * PointsPerInch;
		private float PixelsToInches(float pixs) {
			return pixs / PPI;
		}
		private float InchesToPixels(float inches) {
			return inches * PPI;
		}

        void entryOne_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
			if (entryOne.Text == "")
			{
				height1 = 0;
			}
			else { height1 = Int32.Parse(entryOne.Text); }

			sum = height1 + height2;
			barChart.InvalidateSurface();
        }

        void entryTwo_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
			if (entryTwo.Text == "")
			{
				height2 = 0;
			}
			else { height2 = Int32.Parse(entryTwo.Text); }

			sum = height2 + height1;
			barChart.InvalidateSurface();
		}

		void barChart_PaintSurface(System.Object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
		{
			SKImageInfo info = e.Info;
			SKSurface surface = e.Surface;
			SKCanvas canvas = surface.Canvas;
			canvas.Clear();

			SKPaint recOnePaint = new SKPaint
			{
				Color = Color.Blue.ToSKColor(),
			};
			SKPaint recTwoPaint = new SKPaint
			{
				Color = Color.Red.ToSKColor(),
			};

			var redRec = info.Height * (height1 / sum);
			var blueRec = info.Height * (height2 / sum);

			canvas.DrawRect(0, blueRec, info.Width / 3, info.Height, recTwoPaint);
			canvas.DrawRect(info.Width * 2/3, redRec, info.Width/3, info.Height, recOnePaint);
		}
    }
}
