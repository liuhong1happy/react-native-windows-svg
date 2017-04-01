import { PropTypes } from 'react';
import { requireNativeComponent, View } from 'react-native';

var svgFace = {
    name: 'SVGView',
    propTypes: {
        width: PropTypes.number,
        height: PropTypes.number,
        ...View.propTypes // include the default view properties
    },
};

var shapeFace = {
    name: 'ShapeView',
    propTypes: {
        stroke: PropTypes.string,
        strokeWidth: PropTypes.number,
        strokeOpacity: PropTypes.number,
        strokeDashArray: PropTypes.array,
        strokeDashOffset: PropTypes.number,
        fill: PropTypes.string,
        fillOpacity: PropTypes.number,
        origin: PropTypes.string,
        originX: PropTypes.number,
        originY: PropTypes.number,
        scale: PropTypes.scale,
        rotate: PropTypes.rotate,
        opacity: PropTypes.opacity,
    },
}

var rectFace = {
    name: 'RectView',
    propTypes: {
        rx: PropTypes.number,
        xy: PropTypes.number,
        width: PropTypes.number,
        height: PropTypes.number,
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    },
}

export const SVG = requireNativeComponent('RCTSVGView', rectFace);
export const Rect = requireNativeComponent('RCTRectView', rectFace);