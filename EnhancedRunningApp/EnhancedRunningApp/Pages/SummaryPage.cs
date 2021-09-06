using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EnhancedRunningApp.Data;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace EnhancedRunningApp.Pages
{
    public class SummaryPage : ContentPage
    {
        public ListView lv = new ListView();
        private SKCanvasView barChart;
        private bool currentOrientationLandscape;
        private StackLayout layout;
        public SummaryPage()
        {
            GetSource();
            lv.SelectionMode = 0;
            lv.ItemTapped += LvItemTapped;

            barChart = new SKCanvasView
            {
                WidthRequest = 500,
                HeightRequest = 250,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            barChart.PaintSurface += pageView_PaintSurface;

            layout = new StackLayout
            {
                Children = { lv, barChart } };
            Content = layout;

        }

        private void pageView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            SKPaint paint = new SKPaint
            {
                Color = Color.LightBlue.ToSKColor(),
            };

            var max = getMaxDist(Database.yearDataList);

            foreach (RunningData.YearRunData temp in Database.yearDataList)
            {

                var left = (float)info.Width * (temp.Year - Database.yearDataList.First().Year) / Database.yearDataList.Count;
                var top = info.Height * (1 - ((temp.Dist - max[1] + 100) * 6 / max[0]));

                canvas.DrawRect(left, top, info.Width / 7, info.Height - top, paint);
            }
        }

        private float[] getMaxDist(Collection<RunningData.YearRunData> data)
        {
            var temp = new float[] { 0, float.MaxValue };

            foreach (RunningData.YearRunData year in data)
            {
                if (year.Dist >= temp[0]) { temp[0] = year.Dist; }
                if (year.Dist <= temp[1]) { temp[1] = year.Dist; }
            }
            return temp;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            bool isNowLandscape = width > height;
            if (isNowLandscape != currentOrientationLandscape)
            {
                layout.Orientation = isNowLandscape ? StackOrientation.Horizontal : StackOrientation.Vertical;
                currentOrientationLandscape = isNowLandscape;
            }
        }

        public virtual void GetSource()
        {
            lv.ItemsSource = Database.yearDataList;
        }

        async void LvItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var thisyear = e.Item as RunningData.YearRunData;
                await Navigation.PushAsync(new YearSummary(thisyear));
            }
        }

    }
}
