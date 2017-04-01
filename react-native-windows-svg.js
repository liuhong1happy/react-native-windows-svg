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
        strokeDasharray: PropTypes.array,
        strokeDashoffset: PropTypes.number,
        fill: PropTypes.string,
        fillOpacity: PropTypes.number,
        origin: PropTypes.string,
        originX: PropTypes.number,
        originY: PropTypes.number,
        scale: PropTypes.number,
        rotate: PropTypes.number,
        opacity: PropTypes.number,
        x: PropTypes.number,
        y: PropTypes.number,
    },
}

var rectFace = {
    name: 'RectView',
    propTypes: {
        rx: PropTypes.number,
        ry: PropTypes.number,
        width: PropTypes.number,
        height: PropTypes.number,
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    },
}


var lineFace = {
    name: 'LineView',
    propTypes: {
        x1: PropTypes.number,
        y1: PropTypes.number,
        x2: PropTypes.number,
        y2: PropTypes.number,
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    },
}

var circleFace = {
    name: 'CircleView',
    propTypes: {
        cx: PropTypes.number,
        cy: PropTypes.number,
        r: PropTypes.number,
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    },
}

var ellipseFace = {
    name: 'EllipseView',
    propTypes: {
        cx: PropTypes.number,
        cy: PropTypes.number,
        rx: PropTypes.number,
        ry: PropTypes.number,
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    },
}

var pathFace = {
    name: 'PathView',
    propTypes: {
        d: PropTypes.string,
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    },
}

export const SVG = requireNativeComponent('RCTSVGView', rectFace);
export const Rect = requireNativeComponent('RCTRectView', rectFace);
export const Line = requireNativeComponent('RCTLineView', lineFace);
export const Circle = requireNativeComponent('RCTCircleView', circleFace);
export const Ellipse = requireNativeComponent('RCTEllipseView', ellipseFace);
export const Path = requireNativeComponent('RCTPathView', pathFace);