using System;
using System.Collections.Generic;
using EnhancedRunningApp.Data;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace EnhancedRunningApp.Pages
{
    public class WeekSummary : ContentPage
    {
        public ListView lv = new ListView();
        private bool currentOrientation;
        private SKCanvasView barChart;
        private RunningData.WeekRunData SourceData;
        private StackLayout layout;

        public WeekSummary(RunningData.WeekRunData source)
        {
            SourceData = source;
            Title = source.ToString();

            lv.ItemsSource = source;
            lv.ItemTapped += ListViewItemTapped;
            lv.SelectionMode = 0;
           
            barChart = new SKCanvasView
            {
                HeightRequest = 300,
                WidthRequest = 500,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            barChart.PaintSurface += pageView_PaintSurface;

            layout = new StackLayout { Children = { lv, barChart } };
            Content = layout;
        }

        public async void ListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var day = e.Item as RunningData.DayRunData;
                await Navigation.PushAsync(new DaySummary(day));
            }

        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            bool isLandscape = width > height;
            if (isLandscape != currentOrientation)
            {
                layout.Orientation = isLandscape ? StackOrientation.Horizontal : StackOrientation.Vertical;
                currentOrientation = isLandscape;
            }
        }

        private void pageView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            SKPaint paint = new SKPaint
            {
                Color = Color.Red.ToSKColor(),
            };

            var max = SourceData.getMaxDist();
            var min = SourceData.getMinDist();

            foreach (RunningData.MonthRunData data in lv.ItemsSource)
            {
                var left = (float)info.Width * (data.MonthNum - 1) / 13 + 50;
                var top = info.Height * (1 - ((data.Dist - min + 20) / max));
                canvas.DrawRect(left, top, info.Width / 12, info.Height - top, paint);
            }
        }

    }
}
