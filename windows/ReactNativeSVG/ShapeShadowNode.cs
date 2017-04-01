using Facebook.Yoga;
using Newtonsoft.Json.Linq;
using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace ReactNativeSVG
{
    class ShapeShadowNode : LayoutShadowNode
    {

        private double mStrokeOpacity = 1f;
        private double mFillOpacity = 1f;
        private double mOpacity = 1f;
        private uint? mStrokeColor = 0;
        private uint? mFillColor = ColorHelpers.Transparent;
        private double mScale = 1f;
        private double mRotate = 0;
        private Point mOrigin = new Point(0, 0);
        private double mX = 0;
        private double mY = 0;
        private JArray mStrokeDashArray;
        private double mStrokeDashOffset = 0;
        private double mStrokeThickness = 0;

        // strokeLinecap
        private static int CAP_BUTT = 0;
        private static int CAP_ROUND = 1;
        private static int CAP_SQUARE = 2;

        // strokeLinejoin
        private static int JOIN_BEVEL = 2;
        private static int JOIN_MITER = 0;
        private static int JOIN_ROUND = 1;

        // fillRule
        private static int FILL_RULE_EVENODD = 0;
        private static int FILL_RULE_NONZERO = 1;

        public ShapeShadowNode()
        {
            MeasureFunction = MeasureShape;
        }

        private static YogaSize MeasureShape(YogaNode node, float width, YogaMeasureMode widthMode, float height, YogaMeasureMode heightMode)
        {
            var adjustedHeight = YogaConstants.IsUndefined(height) ? 4f : height;
            var adjustedWidth = YogaConstants.IsUndefined(width) ? 4f : width;
            return MeasureOutput.Make(adjustedWidth, adjustedHeight);
        }

        [ReactProp("stroke", CustomType ="Color")]
        public void SetStroke(uint? iColor)
        {
            mStrokeColor = iColor;
            MarkUpdated();
        }

        [ReactProp("strokeWidth", DefaultDouble = 1f)]
        public void SetStrokeWidth(double thickness)
        {
            mStrokeThickness = thickness;
            MarkUpdated();
        }

        [ReactProp("strokeOpacity", DefaultDouble = 1f)]
        public void SetStrokeOpacity(double strokeOpacity)
        {
            mStrokeOpacity = strokeOpacity;
            MarkUpdated();
        }

        [ReactProp("strokeDasharray")]
        public void setStrokeDasharray(JArray strokeDasharray)
        {
            mStrokeDashArray = strokeDasharray;
            MarkUpdated();
        }

        [ReactProp("strokeDashoffset",DefaultDouble = 0f)]
        public void setStrokeDashoffset(double strokeDashOffset)
        {
            mStrokeDashOffset = strokeDashOffset;
            MarkUpdated();
        }

        [ReactProp("fill", CustomType = "Color")]
        public void SetFill(uint? iColor)
        {
            mFillColor = iColor;
            MarkUpdated();
        }

        [ReactProp("fillOpacity", DefaultDouble = 1f)]
        public void SetFillOpacity(double fillOpacity)
        {
            mFillOpacity = fillOpacity;
            MarkUpdated();
        }

        [ReactProp("opacity", DefaultDouble = 1f)]
        public void SetOpacity(double opacity)
        {
            mOpacity = opacity;
            MarkUpdated();
        }

        [ReactProp("scale", DefaultDouble = 1f)]
        public void SetScale(double scale)
        {
            mScale = scale;
            MarkUpdated();
        }

        [ReactProp("rotate", DefaultDouble = 0f)]
        public void SetRotate(double rotate)
        {
            mRotate = rotate;
            MarkUpdated();
        }

        [ReactProp("originX", DefaultDouble = 0f)]
        public void SetOriginX(double originX)
        {
            mOrigin.X = originX;
            MarkUpdated();
        }

        [ReactProp("originY", DefaultDouble = 0f)]
        public void SetOriginY(double originY)
        {
            mOrigin.Y = originY;
            MarkUpdated();
        }

        [ReactProp("origin", CustomType = "Point")]
        public void SetOriginY(Point origin)
        {
            mOrigin = origin;
            MarkUpdated();
        }

        [ReactProp("x", DefaultDouble = 0f)]
        public void SetX(double x)
        {
            
            MarkUpdated();
        }

        [ReactProp("y", DefaultDouble = 0f)]
        public void SetY(double y)
        {
            mY = y;
            MarkUpdated();
        }

        public void UpdateShape(Shape view)
        {
            if (mStrokeColor.HasValue)
            {
                Color color = ColorHelpers.Parse(mStrokeColor.Value);
                color.A = Convert.ToByte(Convert.ToUInt16(color.A) * mStrokeOpacity);
                view.Stroke = new SolidColorBrush(color);
                DoubleCollection dCollection = new DoubleCollection();
                for (int i = 0; i < mStrokeDashArray.Count; ++i)
                {
                    dCollection.Add(Convert.ToDouble(mStrokeDashArray[i].ToString()));
                }
                view.StrokeDashArray = dCollection;
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
            view.Opacity = mOpacity;
        }
    }
}
