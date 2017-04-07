using Newtonsoft.Json.Linq;
using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI;
#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
#endif

namespace ReactNativeSVG
{
    public abstract class ShapeViewManager<TFrameworkElement, TLayoutShadowNode> : BaseViewManager<TFrameworkElement, TLayoutShadowNode>
        where TFrameworkElement : Shape
        where TLayoutShadowNode : LayoutShadowNode
    {
        [ReactProp("stroke", CustomType = "Color", DefaultUInt32 = 0xff000000)]
        public void SetStroke(Shape view, uint? iColor)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeProperty, iColor);
            UpdateShape(view, viewModel, "stroke");
        }

        [ReactProp("strokeWidth", DefaultDouble = 1f)]
        public void SetStrokeWidth(Shape view,double thickness)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeThicknessProperty, thickness);
            UpdateShape(view, viewModel, "strokeWidth");
        }

        [ReactProp("strokeOpacity", DefaultDouble = 1f)]
        public void SetStrokeOpacity(Shape view, double strokeOpacity)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeOpacityProperty, strokeOpacity);
            UpdateShape(view, viewModel, "strokeOpacity");
        }

        [ReactProp("strokeLinecap")]
        public void SetStrokeLinecap(Shape view, string strokeLinecap)
        {
            List<string> strokeLinecapArray = new List<string>(){ "butt", "square", "round" };
            int iStrokeLinecap = strokeLinecapArray.IndexOf(strokeLinecap);
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeLinecapProperty, iStrokeLinecap);
            UpdateShape(view, viewModel, "strokeLinecap");
        }

        [ReactProp("strokeLinejoin")]
        public void SetStrokeLinejoin(Shape view, string strokeLinejoin)
        {
            List<string> strokeLinejoinArray = new List<string>() { "miter", "bevel", "round" };
            int iStrokeLinejoin = strokeLinejoinArray.IndexOf(strokeLinejoin);
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeLinejoinProperty, iStrokeLinejoin);
            UpdateShape(view, viewModel, "strokeLinejoin");
        }

        [ReactProp("strokeDasharray")]
        public void setStrokeDasharray(Shape view, JArray strokeDasharray)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeDashArrayProperty, strokeDasharray);
            UpdateShape(view, viewModel, "strokeDasharray");
        }

        [ReactProp("strokeDashoffset", DefaultDouble = 0f)]
        public void setStrokeDashoffset(Shape view, double strokeDashOffset)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeDashOffsetProperty, strokeDashOffset);
            UpdateShape(view, viewModel, "strokeDashoffset");
        }


        [ReactProp("strokeMiterlimit", DefaultDouble = 0f)]
        public void setStrokeMiterlimit(Shape view, double strokeMiterlimit)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeMiterlimitProperty, strokeMiterlimit);
            UpdateShape(view, viewModel, "strokeMiterlimit");
        }

        [ReactProp("fill", CustomType = "Color")]
        public void SetFill(Shape view, uint? iColor)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.FillProperty, iColor);
            UpdateShape(view, viewModel, "fill");
        }

        [ReactProp("fillOpacity", DefaultDouble = 1f)]
        public void SetFillOpacity(Shape view, double fillOpacity)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.FillOpacityProperty, fillOpacity);
            UpdateShape(view, viewModel, "fillOpacity");
        }

        [ReactProp("scale", DefaultDouble = 1f)]
        public void SetScale(Shape view, double scale)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.ScaleProperty, scale);
            UpdateShape(view, viewModel, "scale");
        }

        [ReactProp("rotate", DefaultDouble = 0f)]
        public void SetRotate(Shape view, double rotate)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.RotateProperty, rotate);
            UpdateShape(view, viewModel, "rotate");
        }

        [ReactProp("originX", DefaultDouble = 0f)]
        public void SetOriginX(Shape view, double originX)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            Point origin = viewModel.Origin;
            origin.X = originX;
            viewModel.SetValue(ShapeViewModel.OriginProperty, origin);
            UpdateShape(view, viewModel, "originX");
        }

        [ReactProp("originY", DefaultDouble = 0f)]
        public void SetOriginY(Shape view, double originY)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            Point origin = viewModel.Origin;
            origin.Y = originY;
            viewModel.SetValue(ShapeViewModel.OriginProperty, origin);
            UpdateShape(view, viewModel, "originY");
        }

        [ReactProp("origin", CustomType = "Point")]
        public void SetOriginY(Shape view, Point origin)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.OriginProperty, origin);
            UpdateShape(view, viewModel, "origin");
        }

        [ReactProp("x", DefaultDouble = 0f)]
        public void SetX(Shape view, double x)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.XProperty, x);
            UpdateShape(view, viewModel, "x");
        }

        [ReactProp("y", DefaultDouble = 0f)]
        public void SetY(Shape view, double y)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.YProperty, y);
            UpdateShape(view, viewModel,"y");
        }

        private void UpdateShape(Shape view, ShapeViewModel viewModel, string updateKey)
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

        /// <summary>
        /// Sets the dimensions of the view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="dimensions">The output buffer.</param>
        public void SetDimensions(Shape view, Dimensions dimensions)
        {
            // do nothing
        }
    }
}
