using Newtonsoft.Json.Linq;
using ReactNative.UIManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace ReactNativeSVG
{
    class ShapeViewModel : DependencyObject
    {

        public uint? Stroke
        {
            get { return (uint?)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stroke.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke", typeof(uint?), typeof(ShapeViewModel), new PropertyMetadata(0xff000000));

        public double StrokeOpacity
        {
            get { return (double)GetValue(StrokeOpacityProperty); }
            set { SetValue(StrokeOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeOpacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeOpacityProperty =
            DependencyProperty.Register("StrokeOpacity", typeof(double), typeof(ShapeViewModel), new PropertyMetadata(1.0));




        public double StrokeDashOffset
        {
            get { return (double)GetValue(StrokeDashOffsetProperty); }
            set { SetValue(StrokeDashOffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeDashOffset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeDashOffsetProperty =
            DependencyProperty.Register("StrokeDashOffset", typeof(double), typeof(ShapeViewModel), new PropertyMetadata(0.0));



        public JArray StrokeDashArray
        {
            get { return (JArray)GetValue(StrokeDashArrayProperty); }
            set { SetValue(StrokeDashArrayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeDashArray.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeDashArrayProperty =
            DependencyProperty.Register("StrokeDashArray", typeof(JArray), typeof(ShapeViewModel), new PropertyMetadata(new JArray()));




        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(ShapeViewModel), new PropertyMetadata(1.0));




        public int StrokeLinecap
        {
            get { return (int)GetValue(StrokeLinecapProperty); }
            set { SetValue(StrokeLinecapProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeLinecap.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeLinecapProperty =
            DependencyProperty.Register("StrokeLinecap", typeof(int), typeof(ShapeViewModel), new PropertyMetadata(0));



        public int StrokeLinejoin
        {
            get { return (int)GetValue(StrokeLinejoinProperty); }
            set { SetValue(StrokeLinejoinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeLinejoin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeLinejoinProperty =
            DependencyProperty.Register("StrokeLinejoin", typeof(int), typeof(ShapeViewModel), new PropertyMetadata(0));



        public double StrokeMiterlimit
        {
            get { return (double)GetValue(StrokeMiterlimitProperty); }
            set { SetValue(StrokeMiterlimitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeMiterlimit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeMiterlimitProperty =
            DependencyProperty.Register("StrokeMiterlimit", typeof(double), typeof(ShapeViewModel), new PropertyMetadata(0.0));



        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        // Using a DependencyProperty as the backing store for X.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(ShapeViewModel), new PropertyMetadata(0.0));




        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(ShapeViewModel), new PropertyMetadata(0.0));



        public uint? Fill
        {
            get { return (uint?)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(uint?), typeof(ShapeViewModel), new PropertyMetadata(ColorHelpers.Transparent));



        public double FillOpacity
        {
            get { return (double)GetValue(FillOpacityProperty); }
            set { SetValue(FillOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FillOpacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillOpacityProperty =
            DependencyProperty.Register("FillOpacity", typeof(double), typeof(ShapeViewModel), new PropertyMetadata(1.0));



        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Scale.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleProperty =
            DependencyProperty.Register("Scale", typeof(double), typeof(ShapeViewModel), new PropertyMetadata(1.0));



        public double Rotate
        {
            get { return (double)GetValue(RotateProperty); }
            set { SetValue(RotateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Rotate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RotateProperty =
            DependencyProperty.Register("Rotate", typeof(double), typeof(ShapeViewModel), new PropertyMetadata(0.0));



        public Point Origin
        {
            get { return (Point)GetValue(OriginProperty); }
            set { SetValue(OriginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Origin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OriginProperty =
            DependencyProperty.Register("Origin", typeof(Point), typeof(ShapeViewModel), new PropertyMetadata(new Point(0,0)));




        public int FillRule
        {
            get { return (int)GetValue(FillRuleProperty); }
            set { SetValue(FillRuleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FillRule.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillRuleProperty =
            DependencyProperty.Register("FillRule", typeof(int), typeof(ShapeViewModel), new PropertyMetadata(0));



        public List<String> UpdateKeys
        {
            get { return (List<String>)GetValue(UpdateKeysProperty); }
            set { SetValue(UpdateKeysProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpdateKeys.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdateKeysProperty =
            DependencyProperty.Register("UpdateKeys", typeof(List<String>), typeof(ShapeViewModel), new PropertyMetadata(new List<String>()));

        /// <summary>
        /// 更新Shape组件
        /// </summary>
        /// <param name="view">Shape组件</param>
        /// <param name="viewModel">DataContext上下文数据</param>
        /// <param name="updateKey">更新的key值</param>
        public static void UpdateShape(Shape view, ShapeViewModel viewModel, string updateKey)
        {
            // 更新UpdateKeys
            List<String> UpdateKeys = new List<string>(viewModel.UpdateKeys);
            UpdateKeys.Add(updateKey);
            viewModel.SetValue(ShapeViewModel.UpdateKeysProperty, UpdateKeys);

            if (viewModel.Stroke.HasValue)
            {
                Color color = ColorHelpers.Parse(viewModel.Stroke.Value);
                color.A = Convert.ToByte(Convert.ToUInt16(color.A) * viewModel.StrokeOpacity);
                view.Stroke = new SolidColorBrush(color);
                view.StrokeThickness = viewModel.StrokeThickness;
                if (viewModel.StrokeDashArray != null)
                {
                    DoubleCollection dCollection = new DoubleCollection();
                    for (int i = 0; i < viewModel.StrokeDashArray.Count; ++i)
                    {
                        dCollection.Add(Convert.ToDouble(viewModel.StrokeDashArray[i].ToString()));
                    }
                    view.StrokeDashArray = dCollection;
                }
                view.StrokeDashOffset = viewModel.StrokeDashOffset;
                view.StrokeMiterLimit = viewModel.StrokeMiterlimit;
                view.StrokeLineJoin = (PenLineJoin)viewModel.StrokeLinejoin;
                view.StrokeStartLineCap = (PenLineCap)viewModel.StrokeLinecap;
                view.StrokeDashCap = (PenLineCap)viewModel.StrokeLinecap;
                view.StrokeEndLineCap = (PenLineCap)viewModel.StrokeLinecap;
            }
            if (viewModel.Fill.HasValue)
            {
                Color color = ColorHelpers.Parse(viewModel.Fill.Value);
                color.A = Convert.ToByte(Convert.ToUInt16(color.A) * viewModel.FillOpacity);
                view.Fill = new SolidColorBrush(color);
            }
            view.SetValue(Canvas.LeftProperty, viewModel.X);
            view.SetValue(Canvas.TopProperty, viewModel.Y);
            view.RenderTransformOrigin = viewModel.Origin;
            ScaleTransform sctr = new ScaleTransform();
            sctr.ScaleY = viewModel.Scale;
            sctr.ScaleX = viewModel.Scale;
            RotateTransform rttr = new RotateTransform();
            rttr.Angle = viewModel.Rotate;
            TransformGroup trfg = new TransformGroup();
            trfg.Children.Add(sctr);
            trfg.Children.Add(rttr);
            view.RenderTransform = trfg;
            view.DataContext = viewModel;
        }
    }
}
