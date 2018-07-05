using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Codes
{
    public class CustomHorizontalScrollLayout : AbstractCustomScrollLayout
    {
        public CustomHorizontalScrollLayout()
        {
            IsVertical = false;
        }

        protected override void DecreaseVector(ref Vector2 v, float val)
        {
            v.x -= val;
        }

        protected override float GetRectSize(Rect rect)
        {
            return rect.width;
        }

        protected override float GetValue(Vector2 v)
        {
            return v.x;
        }

        protected override void IncreaseVector(ref Vector2 v, float val)
        {
            v.x += val;
        }

        protected override Vector2 ModifyVector(Vector2 source, float value)
        {
            return new Vector2(value, source.y);
        }

        protected override void ResetPivotAndPosition()
        {
            contentViewRect.pivot = Vector2.zero;
            contentViewRect.position = Vector2.zero;
        }
    }
}
