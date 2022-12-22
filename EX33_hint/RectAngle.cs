using System;
using System.Collections.Generic;
using System.Text;

namespace EX33_hint
{
    class RectAngle : ISurface, ICircumference, IBounds
    {
        readonly public float width;
        readonly public float height;
        public RectAngle(float width = 0, float height = 0)
        {
            this.width = width;
            this.height = height;
        }
        public float GetSurface()
        {
            return width * height;
        }
        public float GetCircumference()
        {
            return (width + height) * 2;
        }
        public void GetBounds(out float width, out float height)
        {
            width = this.width;
            height = this.height;
        }
        public static bool operator ==(RectAngle rectAngle1, RectAngle rectAngle2)
        {
            return rectAngle1.width == rectAngle2.width
                && rectAngle1.height == rectAngle2.height
                || rectAngle1.width == rectAngle2.height
                && rectAngle1.height == rectAngle2.width;
        }
        
        public static bool operator !=(RectAngle rectAngle1, RectAngle rectAngle2)
        {
            return !(rectAngle1 == rectAngle2);
        }

        public static RectAngle operator +(RectAngle rectAngle1, RectAngle rectAngle2)
        {
            int min = 0;
            RectAngle[] box = new RectAngle[4];

            //４パターンの横と縦の長さを入れる
            box[0] = new RectAngle(rectAngle1.width + rectAngle2.width, MathF.Max(rectAngle1.height, rectAngle2.height));
            box[1] = new RectAngle(rectAngle1.height + rectAngle2.height, MathF.Max(rectAngle1.width, rectAngle2.width));
            box[2] = new RectAngle(rectAngle1.height + rectAngle1.width, MathF.Max(rectAngle1.width, rectAngle2.height));
            box[3] = new RectAngle(rectAngle1.width + rectAngle2.height, MathF.Max(rectAngle1.height, rectAngle2.width));

            for(int i = 1; i < box.Length; i++)
            {
                if(box[min].width * box[min].height > box[i].width * box[i].height)
                {
                    min = i;
                }
            }
            return box[min];
        }
    }
}
