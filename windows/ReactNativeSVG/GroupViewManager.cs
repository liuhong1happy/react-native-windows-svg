using Newtonsoft.Json.Linq;
using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ReactNativeSVG
{
    abstract class GroupViewManager<TFrameworkElement, TLayoutShadowNode> : ViewParentManager<TFrameworkElement, TLayoutShadowNode>
        where TFrameworkElement : Canvas
        where TLayoutShadowNode : SVGShadowNode
    {
        [ReactProp("width")]
        public void SetWidth(Canvas view, double width)
        {
            view.Width = width;
        }

        [ReactProp("height")]
        public void SetHeight(Canvas view, double height)
        {
            view.Height = height;
        }

        [ReactProp("stroke", CustomType = "Color", DefaultUInt32 = 0xff000000)]
        public void SetStroke(Canvas view, uint? iColor)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeProperty, iColor);
            UpdateGroup(view, viewModel, "stroke");
        }

        [ReactProp("strokeWidth", DefaultDouble = 1f)]
        public void SetStrokeWidth(Canvas view, double thickness)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeThicknessProperty, thickness);
            UpdateGroup(view, viewModel, "strokeWidth");
        }

        [ReactProp("strokeOpacity", DefaultDouble = 1f)]
        public void SetStrokeOpacity(Canvas view, double strokeOpacity)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeOpacityProperty, strokeOpacity);
            UpdateGroup(view, viewModel, "strokeOpacity");
        }

        [ReactProp("strokeLinecap")]
        public void SetStrokeLinecap(Canvas view, string strokeLinecap)
        {
            List<string> strokeLinecapArray = new List<string>() { "butt", "square", "round" };
            int iStrokeLinecap = strokeLinecapArray.IndexOf(strokeLinecap);
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeLinecapProperty, iStrokeLinecap);
            UpdateGroup(view, viewModel, "strokeLinecap");
        }

        [ReactProp("strokeLinejoin")]
        public void SetStrokeLinejoin(Canvas view, string strokeLinejoin)
        {
            List<string> strokeLinejoinArray = new List<string>() { "miter", "bevel", "round" };
            int iStrokeLinejoin = strokeLinejoinArray.IndexOf(strokeLinejoin);
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeLinejoinProperty, iStrokeLinejoin);
            UpdateGroup(view, viewModel, "strokeLinejoin");
        }

        [ReactProp("strokeDasharray")]
        public void setStrokeDasharray(Canvas view, JArray strokeDasharray)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeDashArrayProperty, strokeDasharray);
            UpdateGroup(view, viewModel, "strokeDasharray");
        }

        [ReactProp("strokeDashoffset", DefaultDouble = 0f)]
        public void setStrokeDashoffset(Canvas view, double strokeDashOffset)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeDashOffsetProperty, strokeDashOffset);
            UpdateGroup(view, viewModel, "strokeDashoffset");
        }


        [ReactProp("strokeMiterlimit", DefaultDouble = 0f)]
        public void setStrokeMiterlimit(Canvas view, double strokeMiterlimit)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.StrokeMiterlimitProperty, strokeMiterlimit);
            UpdateGroup(view, viewModel, "strokeMiterlimit");
        }

        [ReactProp("fill", CustomType = "Color")]
        public void SetFill(Canvas view, uint? iColor)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.FillProperty, iColor);
            UpdateGroup(view, viewModel, "fill");
        }

        [ReactProp("fillOpacity", DefaultDouble = 1f)]
        public void SetFillOpacity(Canvas view, double fillOpacity)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.FillOpacityProperty, fillOpacity);
            UpdateGroup(view, viewModel, "fillOpacity");
        }

        [ReactProp("scale", DefaultDouble = 1f)]
        public void SetScale(Canvas view, double scale)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.ScaleProperty, scale);
            UpdateGroup(view, viewModel, "scale");
        }

        [ReactProp("rotate", DefaultDouble = 0f)]
        public void SetRotate(Canvas view, double rotate)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.RotateProperty, rotate);
            UpdateGroup(view, viewModel, "rotate");
        }

        [ReactProp("originX", DefaultDouble = 0f)]
        public void SetOriginX(Canvas view, double originX)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            Point origin = viewModel.Origin;
            origin.X = originX;
            viewModel.SetValue(ShapeViewModel.OriginProperty, origin);
            UpdateGroup(view, viewModel, "originX");
        }

        [ReactProp("originY", DefaultDouble = 0f)]
        public void SetOriginY(Canvas view, double originY)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            Point origin = viewModel.Origin;
            origin.Y = originY;
            viewModel.SetValue(ShapeViewModel.OriginProperty, origin);
            UpdateGroup(view, viewModel, "originY");
        }

        [ReactProp("origin", CustomType = "Point")]
        public void SetOriginY(Canvas view, Point origin)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.OriginProperty, origin);
            UpdateGroup(view, viewModel, "origin");
        }

        [ReactProp("x", DefaultDouble = 0f)]
        public void SetX(Canvas view, double x)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.XProperty, x);
            UpdateGroup(view, viewModel, "x");
        }

        [ReactProp("y", DefaultDouble = 0f)]
        public void SetY(Canvas view, double y)
        {
            ShapeViewModel viewModel = (ShapeViewModel)view.DataContext;
            viewModel.SetValue(ShapeViewModel.YProperty, y);
            UpdateGroup(view, viewModel, "y");
        }

        private void UpdateGroup(Canvas view, ShapeViewModel viewModel, string updateKey)
        {
            // 更新UpdateKeys
            List<String> UpdateKeys = new List<string>(viewModel.UpdateKeys);
            UpdateKeys.Add(updateKey);
            viewModel.SetValue(ShapeViewModel.UpdateKeysProperty, UpdateKeys);

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
