using System;
using ReactNative.UIManager;
using Windows.UI.Xaml.Controls;
using ReactNative.UIManager.Annotations;
using Windows.UI.Xaml;

namespace ReactNativeSVG
{
    class ReactSVGManager : ViewParentManager<Canvas, SVGShadowNode>
    {
        public override string Name
        {
            get
            {
                return "RCTSVGView";
            }
        }

        protected override Canvas CreateViewInstance(ThemedReactContext reactContext)
        {
            return new Canvas();
        }

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

        public override SVGShadowNode CreateShadowNodeInstance()
        {
            return new SVGShadowNode();
        }

        public override void UpdateExtraData(Canvas root, object extraData)
        {
            
        }

        public override void AddView(Canvas parent, DependencyObject child, int index)
        {
            parent.Children.Add((UIElement)child);
        }

        public override int GetChildCount(Canvas parent)
        {
            return parent.Children.Count;
        }

        public override DependencyObject GetChildAt(Canvas parent, int index)
        {
            return parent.Children[index];
        }

        public override void RemoveChildAt(Canvas parent, int index)
        {
            parent.Children.RemoveAt(index);
        }

        public override void RemoveAllChildren(Canvas parent)
        {
            parent.Children.Clear();
        }
    }
}
