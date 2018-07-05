using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Codes
{
    public class CustomVerticalScrollLayout : AbstractCustomScrollLayout
    {
        public CustomVerticalScrollLayout()
        {
            IsVertical = true;
        }

        protected override void DecreaseVector(ref Vector2 v, float val)
        {
            v.y -= val;
        }

        protected override float GetRectSize(Rect rect)
        {
            return rect.height;
        }

        protected override float GetValue(Vector2 v)
        {
            return v.y;
        }

        protected override void IncreaseVector(ref Vector2 v, float val)
        {
            v.y += val;
        }

        protected override Vector2 ModifyVector(Vector2 source, float value)
        {
            return new Vector2(source.x, value);
        }

        protected override void ResetPivotAndPosition()
        {
            contentViewRect.pivot = new Vector2(0f, 1f);
            contentViewRect.position = Vector2.zero;
        }
    }
}
