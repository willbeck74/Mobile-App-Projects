using System;
using System.Collections.Generic;
using EnhancedRunningApp.Data;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace EnhancedRunningApp.Pages
{
    public class DaySummary : ContentPage
    {
        public ListView lv = new ListView();
        private bool currentOrientation;
        private SKCanvasView barChart;
        private RunningData.DayRunData SourceData;
        private StackLayout layout;

        public DaySummary(RunningData.DayRunData source)
        {
            SourceData = source;
            Title = source.ToString();

            lv.ItemsSource = source;
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
                Color = Color.LightBlue.ToSKColor(),
            };

            var max = SourceData.getMaxDist();
            var min = SourceData.getMinDist();

            foreach (RunningData.WeekRunData data in lv.ItemsSource)
            {
                var left = (float)info.Width * (data.WeekNum - 1) / 13 + 50;
                var top = info.Height * (1 - ((data.Dist - min + 20) / max));
                canvas.DrawRect(left, top, info.Width / 12, info.Height - top, paint);
            }
        }

    }
}
