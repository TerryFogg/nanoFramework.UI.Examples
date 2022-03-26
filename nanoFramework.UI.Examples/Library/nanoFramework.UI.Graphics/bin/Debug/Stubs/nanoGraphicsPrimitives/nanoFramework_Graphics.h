//-----------------------------------------------------------------------------
//
//                   ** WARNING! ** 
//    This file was generated automatically by a tool.
//    Re-running the tool will overwrite this file.
//    You should copy this file to a custom location
//    before adding any customization in the copy to
//    prevent loss of your changes when the tool is
//    re-run.
//
//-----------------------------------------------------------------------------

#ifndef NANOFRAMEWORK_GRAPHICS_H
#define NANOFRAMEWORK_GRAPHICS_H

#include <nanoCLR_Interop.h>
#include <nanoCLR_Runtime.h>
#include <nanoPackStruct.h>
#include <corlib_native.h>

typedef enum __nfpack Color
{
    Color_AliceBlue = 16775408,
    Color_AntiqueWhite = 14150650,
    Color_Aqua = 16776960,
    Color_Aquamarine = 13959039,
    Color_Azure = 16777200,
    Color_Beige = 14480885,
    Color_Bisque = 12903679,
    Color_Black = 0,
    Color_BlanchedAlmond = 13495295,
    Color_Blue = 16711680,
    Color_BlueViolet = 14822282,
    Color_Brown = 2763429,
    Color_BurlyWood = 8894686,
    Color_CadetBlue = 10526303,
    Color_Chartreuse = 65407,
    Color_Chocolate = 1993170,
    Color_Coral = 5275647,
    Color_CornflowerBlue = 15570276,
    Color_Cornsilk = 14481663,
    Color_Crimson = 3937500,
    Color_Cyan = 16776960,
    Color_DarkBlue = 9109504,
    Color_DarkCyan = 9145088,
    Color_DarkGoldenrod = 755384,
    Color_DarkGray = 11119017,
    Color_DarkGreen = 25600,
    Color_DarkKhaki = 7059389,
    Color_DarkMagenta = 9109643,
    Color_DarkOliveGreen = 3107669,
    Color_DarkOrange = 36095,
    Color_DarkOrchid = 13382297,
    Color_DarkRed = 139,
    Color_DarkSalmon = 8034025,
    Color_DarkSeaGreen = 9419919,
    Color_DarkSlateBlue = 9125192,
    Color_DarkSlateGray = 5197615,
    Color_DarkTurquoise = 13749760,
    Color_DarkViolet = 13828244,
    Color_DeepPink = 9639167,
    Color_DeepSkyBlue = 16760576,
    Color_DimGray = 6908265,
    Color_DodgerBlue = 16748574,
    Color_Firebrick = 2237106,
    Color_FloralWhite = 15792895,
    Color_ForestGreen = 2263842,
    Color_Gainsboro = 14474460,
    Color_GhostWhite = 16775416,
    Color_Gold = 55295,
    Color_Goldenrod = 2139610,
    Color_Gray = 8421504,
    Color_Green = 32768,
    Color_GreenYellow = 3145645,
    Color_Honeydew = 15794160,
    Color_HotPink = 11823615,
    Color_IndianRed = 6053069,
    Color_Indigo = 8519755,
    Color_Ivory = 15794175,
    Color_Khaki = 9234160,
    Color_Lavender = 16443110,
    Color_LavenderBlush = 16118015,
    Color_LawnGreen = 64636,
    Color_LemonChiffon = 13499135,
    Color_LightBlue = 15128749,
    Color_LightCoral = 8421616,
    Color_LightCyan = 16777184,
    Color_LightGoldenrodYellow = 13826810,
    Color_LightGray = 13882323,
    Color_LightGreen = 9498256,
    Color_LightPink = 12695295,
    Color_LightSalmon = 8036607,
    Color_LightSeaGreen = 11186720,
    Color_LightSkyBlue = 16436871,
    Color_LightSlateGray = 10061943,
    Color_LightSteelBlue = 14599344,
    Color_LightYellow = 14745599,
    Color_Lime = 65280,
    Color_LimeGreen = 3329330,
    Color_Linen = 15134970,
    Color_Magenta = 16711935,
    Color_Maroon = 128,
    Color_MediumAquamarine = 11193702,
    Color_MediumBlue = 13434880,
    Color_MediumOrchid = 13850042,
    Color_MediumPurple = 14381203,
    Color_MediumSeaGreen = 7451452,
    Color_MediumSlateBlue = 15624315,
    Color_MediumSpringGreen = 10156544,
    Color_MediumTurquoise = 13422920,
    Color_MediumVioletRed = 8721863,
    Color_MidnightBlue = 7346457,
    Color_MintCream = 16449525,
    Color_MistyRose = 14804223,
    Color_Moccasin = 11920639,
    Color_NavajoWhite = 11394815,
    Color_Navy = 8388608,
    Color_OldLace = 15136253,
    Color_Olive = 32896,
    Color_OliveDrab = 2330219,
    Color_Orange = 42495,
    Color_OrangeRed = 17919,
    Color_Orchid = 14053594,
    Color_PaleGoldenrod = 11200750,
    Color_PaleGreen = 10025880,
    Color_PaleTurquoise = 15658671,
    Color_PaleVioletRed = 9662683,
    Color_PapayaWhip = 14020607,
    Color_PeachPuff = 12180223,
    Color_Peru = 4163021,
    Color_Pink = 13353215,
    Color_Plum = 14524637,
    Color_PowderBlue = 15130800,
    Color_Purple = 8388736,
    Color_Red = 255,
    Color_RosyBrown = 9408444,
    Color_RoyalBlue = 14772545,
    Color_SaddleBrown = 1262987,
    Color_Salmon = 7504122,
    Color_SandyBrown = 6333684,
    Color_SeaGreen = 5737262,
    Color_SeaShell = 15660543,
    Color_Sienna = 2970272,
    Color_Silver = 12632256,
    Color_SkyBlue = 15453831,
    Color_SlateBlue = 13458026,
    Color_SlateGray = 9470064,
    Color_Snow = 16448255,
    Color_SpringGreen = 8388352,
    Color_SteelBlue = 11829830,
    Color_Tan = 9221330,
    Color_Teal = 8421376,
    Color_Thistle = 14204888,
    Color_Tomato = 4678655,
    Color_Turquoise = 13688896,
    Color_Violet = 15631086,
    Color_Wheat = 11788021,
    Color_White = 16777215,
    Color_WhiteSmoke = 16119285,
    Color_Yellow = 65535,
    Color_YellowGreen = 3329434,
} Color;

typedef enum __nfpack Bitmap_BitmapImageType
{
    Bitmap_BitmapImageType_NanoCLRBitmap = 0,
    Bitmap_BitmapImageType_Gif = 1,
    Bitmap_BitmapImageType_Jpeg = 2,
    Bitmap_BitmapImageType_Bmp = 3,
} Bitmap_BitmapImageType;

typedef enum __nfpack DisplayOrientation
{
    DisplayOrientation_PORTRAIT = 0,
    DisplayOrientation_PORTRAIT180 = 1,
    DisplayOrientation_LANDSCAPE = 2,
    DisplayOrientation_LANDSCAPE180 = 3,
} DisplayOrientation;

struct Library_nanoFramework_Graphics_nanoFramework_UI_Font
{
    static const int FIELD__m_font = 1;

    NANOCLR_NATIVE_DECLARE(CharWidth___I4__CHAR);
    NANOCLR_NATIVE_DECLARE(get_Height___I4);
    NANOCLR_NATIVE_DECLARE(get_AverageWidth___I4);
    NANOCLR_NATIVE_DECLARE(get_MaxWidth___I4);
    NANOCLR_NATIVE_DECLARE(get_Ascent___I4);
    NANOCLR_NATIVE_DECLARE(get_Descent___I4);
    NANOCLR_NATIVE_DECLARE(get_InternalLeading___I4);
    NANOCLR_NATIVE_DECLARE(get_ExternalLeading___I4);
    NANOCLR_NATIVE_DECLARE(ComputeExtent___VOID__STRING__BYREF_I4__BYREF_I4__I4);
    NANOCLR_NATIVE_DECLARE(ComputeTextInRect___VOID__STRING__BYREF_I4__BYREF_I4__I4__I4__I4__I4__U4);

    //--//
};

struct Library_nanoFramework_Graphics_nanoFramework_UI_Bitmap
{
    static const int FIELD_STATIC__MaxWidth = 0;
    static const int FIELD_STATIC__MaxHeight = 1;
    static const int FIELD_STATIC__CenterX = 2;
    static const int FIELD_STATIC__CenterY = 3;

    static const int FIELD__m_bitmap = 1;

    NANOCLR_NATIVE_DECLARE(_ctor___VOID__I4__I4);
    NANOCLR_NATIVE_DECLARE(_ctor___VOID__SZARRAY_U1__nanoFrameworkUIBitmapBitmapImageType);
    NANOCLR_NATIVE_DECLARE(Flush___VOID);
    NANOCLR_NATIVE_DECLARE(Flush___VOID__I4__I4__I4__I4);
    NANOCLR_NATIVE_DECLARE(Flush___VOID__I4__I4__I4__I4__I4__I4);
    NANOCLR_NATIVE_DECLARE(Clear___VOID);
    NANOCLR_NATIVE_DECLARE(DrawTextInRect___BOOLEAN__BYREF_STRING__BYREF_I4__BYREF_I4__I4__I4__I4__I4__U4__nanoFrameworkPresentationMediaColor__nanoFrameworkUIFont);
    NANOCLR_NATIVE_DECLARE(DrawChar___VOID__U2__I4__I4__nanoFrameworkPresentationMediaColor__nanoFrameworkUIFont);
    NANOCLR_NATIVE_DECLARE(SetClippingRectangle___VOID__I4__I4__I4__I4);
    NANOCLR_NATIVE_DECLARE(get_Width___I4);
    NANOCLR_NATIVE_DECLARE(get_Height___I4);
    NANOCLR_NATIVE_DECLARE(DrawEllipse___VOID__nanoFrameworkPresentationMediaColor__I4__I4__I4__I4__I4__nanoFrameworkPresentationMediaColor__I4__I4__nanoFrameworkPresentationMediaColor__I4__I4__U2);
    NANOCLR_NATIVE_DECLARE(DrawImage___VOID__I4__I4__nanoFrameworkUIBitmap__I4__I4__I4__I4__U2);
    NANOCLR_NATIVE_DECLARE(RotateImage___VOID__I4__I4__I4__nanoFrameworkUIBitmap__I4__I4__I4__I4__U2);
    NANOCLR_NATIVE_DECLARE(MakeTransparent___VOID__nanoFrameworkPresentationMediaColor);
    NANOCLR_NATIVE_DECLARE(StretchImage___VOID__I4__I4__nanoFrameworkUIBitmap__I4__I4__U2);
    NANOCLR_NATIVE_DECLARE(DrawLine___VOID__nanoFrameworkPresentationMediaColor__I4__I4__I4__I4__I4);
    NANOCLR_NATIVE_DECLARE(DrawRectangle___VOID__I4__I4__I4__I4__I4__nanoFrameworkPresentationMediaColor);
    NANOCLR_NATIVE_DECLARE(DrawRectangle___VOID__nanoFrameworkPresentationMediaColor__I4__I4__I4__I4__I4__I4__I4__nanoFrameworkPresentationMediaColor__I4__I4__nanoFrameworkPresentationMediaColor__I4__I4__U2);
    NANOCLR_NATIVE_DECLARE(DrawRoundRectangle___VOID__I4__I4__I4__I4__I4__I4__I4__nanoFrameworkPresentationMediaColor);
    NANOCLR_NATIVE_DECLARE(FillRectangle___VOID__I4__I4__I4__I4__nanoFrameworkPresentationMediaColor__U2);
    NANOCLR_NATIVE_DECLARE(FillRoundRectangle___VOID__I4__I4__I4__I4__I4__I4__nanoFrameworkPresentationMediaColor__U2);
    NANOCLR_NATIVE_DECLARE(FillGradientRectangle___VOID__I4__I4__I4__I4__nanoFrameworkPresentationMediaColor__I4__I4__nanoFrameworkPresentationMediaColor__I4__I4__U2);
    NANOCLR_NATIVE_DECLARE(DrawText___VOID__STRING__nanoFrameworkUIFont__nanoFrameworkPresentationMediaColor__I4__I4);
    NANOCLR_NATIVE_DECLARE(SetPixel___VOID__I4__I4__nanoFrameworkPresentationMediaColor);
    NANOCLR_NATIVE_DECLARE(GetPixel___nanoFrameworkPresentationMediaColor__I4__I4);
    NANOCLR_NATIVE_DECLARE(GetBitmap___SZARRAY_U1);
    NANOCLR_NATIVE_DECLARE(StretchImage___VOID__I4__I4__I4__I4__nanoFrameworkUIBitmap__I4__I4__I4__I4__U2);
    NANOCLR_NATIVE_DECLARE(TileImage___VOID__I4__I4__nanoFrameworkUIBitmap__I4__I4__U2);
    NANOCLR_NATIVE_DECLARE(Scale9Image___VOID__I4__I4__I4__I4__nanoFrameworkUIBitmap__I4__I4__I4__I4__U2);
    NANOCLR_NATIVE_DECLARE(Dispose___VOID__BOOLEAN);

    //--//
};

struct Library_nanoFramework_Graphics_nanoFramework_UI_DisplayControl
{
    static const int FIELD_STATIC___fullScreen = 4;
    static const int FIELD_STATIC___point = 5;
    static const int FIELD_STATIC__<MaximumBufferSize>k__BackingField = 6;

    NANOCLR_NATIVE_DECLARE(get_LongerSide___STATIC__I4);
    NANOCLR_NATIVE_DECLARE(get_ShorterSide___STATIC__I4);
    NANOCLR_NATIVE_DECLARE(get_ScreenWidth___STATIC__I4);
    NANOCLR_NATIVE_DECLARE(get_ScreenHeight___STATIC__I4);
    NANOCLR_NATIVE_DECLARE(get_BitsPerPixel___STATIC__I4);
    NANOCLR_NATIVE_DECLARE(get_Orientation___STATIC__nanoFrameworkUIDisplayOrientation);
    NANOCLR_NATIVE_DECLARE(Clear___STATIC__VOID);
    NANOCLR_NATIVE_DECLARE(Write___STATIC__VOID__U2__U2__U2__U2__SZARRAY_U2);
    NANOCLR_NATIVE_DECLARE(Write___STATIC__VOID__STRING__U2__U2__U2__U2__nanoFrameworkUIFont__nanoFrameworkPresentationMediaColor__nanoFrameworkPresentationMediaColor);
    NANOCLR_NATIVE_DECLARE(NativeChangeOrientation___STATIC__BOOLEAN__nanoFrameworkUIDisplayOrientation);

    //--//
};

extern const CLR_RT_NativeAssemblyData g_CLR_AssemblyNative_nanoGraphicsPrimitives;

#endif // NANOFRAMEWORK_GRAPHICS_H
