using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TarunMittal.FontSample
{
    class MyTextView : TextView
    {

        private const string Tag = "TextView";

        protected MyTextView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public MyTextView(Context context)
            : this(context, null)
        {
        }

        public MyTextView(Context context, IAttributeSet attrs)
            : this(context, attrs, 0)
        {
        }

        public MyTextView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            var a = context.ObtainStyledAttributes(attrs,
                    Resource.Styleable.CustomFonts);
            var customFont = a.GetString(Resource.Styleable.CustomFonts_customFont);
           // var customFontWeight = a.GetString(Resource.Styleable.CustomFonts_fontWeight);
           // var fontToSet = string.Format("{0}-{1}.OTF", customFont, customFontWeight);
            SetCustomFont(customFont);
            a.Recycle();
        }

        public void SetCustomFont(string asset)
        {
            Typeface tf;
            try
            {
                tf = Typeface.CreateFromAsset(Context.Assets, asset);
            }
            catch (Exception e)
            {
                Log.Error(Tag, string.Format("Could not get Typeface: {0} Error: {1}", asset, e));
                return;
            }

            if (null == tf) return;

            var tfStyle = TypefaceStyle.Normal;
            if (null != Typeface) //Takes care of android:textStyle=""
                tfStyle = Typeface.Style;
            SetTypeface(tf, tfStyle);
        }
    }
}