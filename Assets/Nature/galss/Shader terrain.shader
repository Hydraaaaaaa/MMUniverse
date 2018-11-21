// Upgrade NOTE: replaced 'V2F_POS_FOG' with 'float4 pos : SV_POSITION'

Shader "Terrain/Four Layer VertexLit 2Pass" {

Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Color 1 (RGB)", 2D) = "white" {}
    _MainTex2 ("Color 2 (RGB)", 2D) = "white" {}
    _MainTex3 ("Color 3 (RGB)", 2D) = "white" {}
    _MainTex4 ("Color 4 (RGB)", 2D) = "white" {}
    _Mask ("Mixing Mask (RGBA)", 2D) = "gray" {}
    _Base ("Base Color (RGB)", 2D) = "white" {}
}
Category {
    Lighting On
    Cull Back
    Fog { Color [_AddFog] }
    Subshader {
        Material {
            Diffuse [_Color]
            Ambient [_Color]
        }
       
        Pass {
CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
#pragma fragment frag
#pragma fragmentoption ARB_fog_exp2
#include "UnityCG.cginc"
 
sampler2D _MainTex;
sampler2D _MainTex2;
sampler2D _MainTex3;
sampler2D _Mask;
 
struct v2f {
    float4 pos : SV_POSITION;
    float4 uv[4] : TEXCOORD0;
    float4 diffuse : COLOR;
};
 
half4 frag( v2f i ) : COLOR
{
    // get the first three layer colors
    half4 color1 = tex2D( _MainTex, i.uv[0].xy );
    half4 color2 = tex2D( _MainTex2, i.uv[1].xy );
    half4 color3 = tex2D( _MainTex3, i.uv[2].xy );
    // get the mixing mask texture
    half4 mask = tex2D( _Mask, i.uv[3].xy );
    // mix the three layers
    half4 color = color1 * mask.r + color2 * mask.g + color3 * mask.b;
    // multiply and double by the lighting
    return color * i.diffuse * 2.0;
}
ENDCG
        }
       
        Pass {
            Blend One One
CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
#pragma fragment frag
#pragma fragmentoption ARB_fog_exp2
#include "UnityCG.cginc"
 
sampler2D _MainTex4;
sampler2D _Mask;
 
struct v2f {
    float4 pos : SV_POSITION;
    float4 uv[2] : TEXCOORD0;
    float4 diffuse : COLOR;
};
 
half4 frag( v2f i ) : COLOR
{
    // Finish the last texture mix in the second pass...some cards don't have enough registers to do it in one pass
    half4 color1 = tex2D( _MainTex4, i.uv[0].xy );
    half4 mask = tex2D( _Mask, i.uv[1].xy );
    half4 color = color1 * mask.a;
    return color * i.diffuse * 2.0;
}
ENDCG       
        }
    }
}
    // ------------------------------------------------------------------
    // Radeon 7000 / 9000
   
    SubShader {
        Pass {
            Material {
                Diffuse [_Color]
                Ambient [_Color]
            }
            Lighting On
            SetTexture [_Base] {
                Combine texture * primary DOUBLE, texture * primary
            }
        }
    }
}