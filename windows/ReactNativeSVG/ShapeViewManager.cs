using Newtonsoft.Json.Linq;
using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using System;
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

        private double mStrokeOpacity = 1f;
        private double mFillOpacity = 1f;
        private double mOpacity = 1f;
        private uint? mStrokeColor = 0xff000000;
        private uint? mFillColor = ColorHelpers.Transparent;
        private double mScale = 1f;
        private double mRotate = 0;
        private Point mOrigin = new Point(0, 0);
        private double mX = 0;
        private double mY = 0;
        private JArray mStrokeDashArray;
        private double mStrokeDashOffset = 0;
        private double mStrokeThickness = 1;

        [ReactProp("stroke", CustomType = "Color", DefaultUInt32 = 0xff000000)]
        public void SetStroke(Shape view, uint? iColor)
        {
            mStrokeColor = iColor;
            UpdateShape(view);
        }

        [ReactProp("strokeWidth", DefaultDouble = 1f)]
        public void SetStrokeWidth(Shape view,double thickness)
        {
            mStrokeThickness = thickness;
            UpdateShape(view);
        }

        [ReactProp("strokeOpacity", DefaultDouble = 1f)]
        public void SetStrokeOpacity(Shape view, double strokeOpacity)
        {
            mStrokeOpacity = strokeOpacity;
            UpdateShape(view);
        }

        [ReactProp("strokeDasharray")]
        public void setStrokeDasharray(Shape view, JArray strokeDasharray)
        {
            mStrokeDashArray = strokeDasharray;
            UpdateShape(view);
        }

        [ReactProp("strokeDashoffset", DefaultDouble = 0f)]
        public void setStrokeDashoffset(Shape view, double strokeDashOffset)
        {
            mStrokeDashOffset = strokeDashOffset;
            UpdateShape(view);
        }

        [ReactProp("fill", CustomType = "Color")]
        public void SetFill(Shape view, uint? iColor)
        {
            mFillColor = iColor;
            UpdateShape(view);
        }

        [ReactProp("fillOpacity", DefaultDouble = 1f)]
        public void SetFillOpacity(Shape view, double fillOpacity)
        {
            mFillOpacity = fillOpacity;
            UpdateShape(view);
        }

        [ReactProp("scale", DefaultDouble = 1f)]
        public void SetScale(Shape view, double scale)
        {
            mScale = scale;
            UpdateShape(view);
        }

        [ReactProp("rotate", DefaultDouble = 0f)]
        public void SetRotate(Shape view, double rotate)
        {
            mRotate = rotate;
            UpdateShape(view);
        }

        [ReactProp("originX", DefaultDouble = 0f)]
        public void SetOriginX(Shape view, double originX)
        {
            mOrigin.X = originX;
            UpdateShape(view);
        }

        [ReactProp("originY", DefaultDouble = 0f)]
        public void SetOriginY(Shape view, double originY)
        {
            mOrigin.Y = originY;
            UpdateShape(view);
        }

        [ReactProp("origin", CustomType = "Point")]
        public void SetOriginY(Shape view, Point origin)
        {
            mOrigin = origin;
            UpdateShape(view);
        }

        [ReactProp("x", DefaultDouble = 0f)]
        public void SetX(Shape view, double x)
        {
            mX = x;
            UpdateShape(view);
        }

        [ReactProp("y", DefaultDouble = 0f)]
        public void SetY(Shape view, double y)
        {
            mY = y;
            UpdateShape(view);
        }

        public void UpdateShape(Shape view)
        {
            if (mStrokeColor.HasValue)
            {
                Color color = ColorHelpers.Parse(mStrokeColor.Value);
                color.A = Convert.ToByte(Convert.ToUInt16(color.A) * mStrokeOpacity);
                view.Stroke = new SolidColorBrush(color);
                view.StrokeThickness = mStrokeThickness;
                if (mStrokeDashArray != null)
                {
                    DoubleCollection dCollection = new DoubleCollection();
                    for (int i = 0; i < mStrokeDashArray.Count; ++i)
                    {
                        dCollection.Add(Convert.ToDouble(mStrokeDashArray[i].ToString()));
                    }
                    view.StrokeDashArray = dCollection;
                }
                view.StrokeDashOffset = mStrokeDashOffset;
            }
            if (mFillColor.HasValue)
            {
                Color color = ColorHelpers.Parse(mFillColor.Value);
                color.A = Convert.ToByte(Convert.ToUInt16(color.A) * mFillOpacity);
                view.Fill = new SolidColorBrush(color);
            }
            view.SetValue(Canvas.LeftProperty, mX);
            view.SetValue(Canvas.TopProperty, mY);
            view.RenderTransformOrigin = mOrigin;
            ScaleTransform sctr = new ScaleTransform();
            sctr.ScaleY = mScale;
            sctr.ScaleX = mScale;
            RotateTransform rttr = new RotateTransform();
            rttr.Angle = mRotate;
            TransformGroup trfg = new TransformGroup();
            trfg.Children.Add(sctr);
            trfg.Children.Add(rttr);
            view.RenderTransform = trfg;
        }

    }
}
