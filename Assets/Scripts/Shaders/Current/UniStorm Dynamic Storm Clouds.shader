Shader "UniStorm/Dynamic Storm Clouds" {

Properties {  
	_Color ("Cloud Color", Color) = (0.5,0.5,0.5,0.5)
	
    _MainTex1 ("Cloud Mask", 2D) = "white" {}
    _MainTex2 ("Noise", 2D) = "white" {}
    _MainTex3 ("Cloud Texture", 2D) = "white" {}
}
 
SubShader {
    Tags {"Queue"="Transparent-100" "IgnoreProjector"="True" "RenderType"="Transparent"}
    LOD 200
    //Tags { "LightMode" = "Always" }
    
    Blend SrcAlpha OneMinusSrcAlpha
	AlphaTest Greater 0.01
	
	Fog  { Density .0001 } 
	Fog  { Range 0 , 8000 }
	
    Cull Front 
    Lighting Off 
    ZWrite Off
    
    
    

 
CGPROGRAM
#pragma surface surf Lambert alpha

 
sampler2D _MainTex1;
sampler2D _MainTex2;
sampler2D _MainTex3;
fixed4 _Color;
 
struct Input {
    float2 uv_MainTex1;
    float2 uv_MainTex2;
    float2 uv_MainTex3;
};
 
void surf (Input IN, inout SurfaceOutput o) {
    fixed4 c1 = tex2D(_MainTex1, IN.uv_MainTex1) * _Color;
    fixed4 c2 = tex2D(_MainTex2, IN.uv_MainTex2);
    fixed4 c3 = tex2D(_MainTex3, IN.uv_MainTex3);
    o.Albedo = c1.rgb;
    o.Alpha = c1.a*c2.a*c3.a;
}
ENDCG
}
}
