using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace ReactNativeSVG
{
    class PointsParser
    {
        private PointCollection mPoints;
        private Regex DECIMAL_REG_EXP = new Regex(@"\d+(?:\.\d+)?");
        private Match mMatcher;
        private Boolean mValid;
        private String mString;

        private double getNextDecimal()
        {
            mMatcher = mMatcher.NextMatch();
            if (mMatcher.Success)
            {
                return Convert.ToDouble(mMatcher.Value);
            }
            else
            {
                mValid = false;
                mPoints = new PointCollection();
                return 0;
            }
        }

        public PointsParser(string points)
        {
            mString = points;
        }

        public PointCollection getPoints()
        {
            mPoints = new PointCollection();
            
            mValid = true;

            mMatcher = DECIMAL_REG_EXP.Match(mString);
            while (mMatcher.Success && mValid)
            {
                ExecuteCommand(Convert.ToDouble(mMatcher.Value), getNextDecimal());
                mMatcher = mMatcher.NextMatch();
            }
            return mPoints;
        }

        private void ExecuteCommand(double x, double y)
        {
            mPoints.Add(new Windows.Foundation.Point()
            {
                X = x,
                Y = y
            });
        }
    }
}
