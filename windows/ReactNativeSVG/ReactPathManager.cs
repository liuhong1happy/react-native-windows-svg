using ReactNative.UIManager.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using ReactNative.UIManager;
using Windows.UI.Xaml.Media;

namespace ReactNativeSVG
{
    class ReactPathManager : ShapeViewManager<Path, ShapeShadowNode>
    {
        public override string Name
        {
            get
            {
                return "RCTPathView";
            }
        }

        public override void UpdateExtraData(Path root, object extraData)
        {

        }

        [ReactProp("d")]
        public void setWidth(Path view, string d)
        {
            PathParser pp = new PathParser(d);
            view.Data = pp.getPath();
        }


        public override ShapeShadowNode CreateShadowNodeInstance()
        {
            return new ShapeShadowNode();
        }

        public override void SetDimensions(Path view, Dimensions dimensions)
        {

        }

        protected override Path CreateViewInstance(ThemedReactContext reactContext)
        {
            return new Path()
            {
                DataContext = new ShapeViewModel()
            };
        }
    }
}
