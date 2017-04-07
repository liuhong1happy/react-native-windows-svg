using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace ReactNativeSVG
{
    class ReactEllipseManager : ShapeViewManager<Ellipse, ShapeShadowNode>
    {
        public override string Name
        {
            get
            {
                return "RCTEllipseView";
            }
        }

        private double mCX = 0;
        private double mCY = 0;
        private double mRX = 0;
        private double mRY = 0;

        public override void UpdateExtraData(Ellipse root, object extraData)
        {

        }

        [ReactProp("cx")]
        public void setWidth(Ellipse view, double cx)
        {
            mCX = cx;
            UpdatePosition(view);
        }


        [ReactProp("cy")]
        public void setHeight(Ellipse view, double cy)
        {
            mCY = cy;
            UpdatePosition(view);
        }

        [ReactProp("rx")]
        public void setRx(Ellipse view, double rx)
        {
            mRX = rx;
            UpdatePosition(view);
        }

        [ReactProp("ry")]
        public void setRy(Ellipse view, double ry)
        {
            mRY = ry;
            UpdatePosition(view);
        }

        private void UpdatePosition(Ellipse view)
        {
            Thickness Margin = new Thickness(mCX - mRX, mCY - mRY, 0, 0);
            view.Margin = Margin;
            view.Width = mRX * 2;
            view.Height = mRY * 2;
        }

        protected override Ellipse CreateViewInstance(ThemedReactContext reactContext)
        {
            return new Ellipse()
            {
                Width = 4f,
                Height = 4f,
                DataContext = new ShapeViewModel()
            };
        }

        public override ShapeShadowNode CreateShadowNodeInstance()
        {
            return new ShapeShadowNode();
        }

        public override void SetDimensions(Ellipse view, Dimensions dimensions)
        {

        }
    }
}
