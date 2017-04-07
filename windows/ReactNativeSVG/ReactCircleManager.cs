using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace ReactNativeSVG
{
    class ReactCircleManager : ShapeViewManager<Ellipse, ShapeShadowNode>
    {
        public override string Name
        {
            get
            {
                return "RCTCircleView";
            }
        }

        public override void UpdateExtraData(Ellipse root, object extraData)
        {

        }

        private double mCX = 0;
        private double mCY = 0;
        private double mR = 0;

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


        [ReactProp("r")]
        public void setRx(Ellipse view, double r)
        {
            mR = r;
            UpdatePosition(view);
        }


        private void UpdatePosition(Ellipse view)
        {
            Thickness Margin = new Thickness(mCX - mR ,mCY - mR,0,0);
            view.Margin = Margin;
            view.Width = mR*2;
            view.Height = mR*2;
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
