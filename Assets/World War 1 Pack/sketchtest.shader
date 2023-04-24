Shader "Wanzi/msc/sketch shader"
{
 Properties{
  _Color("Main Color",COLOR) = (1,1,1,1)
  _TileFactor("TileFactor",Float) = 8

  _OutlineWidth ("Outline width", Range(0.01, 4)) = 0.01
  _OutlineColor ("Outline Color", color) = (1.0, 1.0, 1.0, 1.0)

  _Hatch0("Hatch0",2D) = "white" {}
  _Hatch1("Hatch1",2D) = "white" {}
  _Hatch2("Hatch2",2D) = "white" {}
  _Hatch3("Hatch3",2D) = "white" {}
  _Hatch4("Hatch4",2D) = "white" {}
  _Hatch5("Hatch5",2D) = "white" {}
 }

 SubShader{
  
  Tags { "RenderType" = "Opaque" "Queue" = "Geometry"}




  Pass{
   Tags { "LightMode" = "ForwardBase" }
   CGPROGRAM

   #pragma fragment  frag
   #pragma vertex vert

   #include "UnityCG.cginc"
   #include "Lighting.cginc"
   #include "AutoLight.cginc"
   #include "UnityShaderVariables.cginc"


   fixed4 _Color;
   float _TileFactor;
   sampler2D _Hatch0;
   sampler2D _Hatch1;
   sampler2D _Hatch2;
   sampler2D _Hatch3;
   sampler2D _Hatch4;
   sampler2D _Hatch5;

   struct a2v {
    float4 vertex : POSITION;
    float4 normal : NORMAL;
    float2 texcoord : TEXCOORD0;
   };

   struct v2f {
    float4 pos : SV_POSITION;
    float2 uv :TEXCOORD0;
    float3 hatchWeight0:TEXCOORD1;
    float3 hatchWeight1:TEXCOORD2;
    float3 worldPos:TEXCOORD3;
   };

   v2f vert(a2v i) {
    v2f o;
    o.pos = UnityObjectToClipPos(i.vertex);
    o.uv = i.texcoord.xy * _TileFactor;
    fixed3 worldLightDir = normalize(WorldSpaceLightDir(i.vertex));
    fixed3 worldNormal = UnityObjectToWorldNormal(i.normal);
    float diff = max(0, dot(worldLightDir , worldNormal));
    float hatchFactor = diff * 7.0;
    o.hatchWeight0 = fixed3(0, 0, 0);
    o.hatchWeight1 = fixed3(0, 0, 0);
    if (hatchFactor > 6.0) {
     //到达这个区间内的颜色为纯白

    }
    else if (hatchFactor > 5.0) {
     //最浅的那张颜色
     o.hatchWeight0.x = hatchFactor - 5.0;
    }
    else if (hatchFactor > 4.0) {
     o.hatchWeight0.x = hatchFactor - 4.0;
     o.hatchWeight0.y = 1 - o.hatchWeight0.x;
    }
    else if (hatchFactor > 3.0) {
     o.hatchWeight0.y = hatchFactor - 3.0;
     o.hatchWeight0.z = 1 - o.hatchWeight0.y;
    }
    else if (hatchFactor > 2.0) {
     o.hatchWeight0.z = hatchFactor - 2.0;
     o.hatchWeight1.x = 1 - o.hatchWeight0.z;
    }
    else if (hatchFactor > 1.0) {
     o.hatchWeight1.x = hatchFactor - 1.0;
     o.hatchWeight1.y = 1 - o.hatchWeight1.x;
    }
    else {
     o.hatchWeight1.y = hatchFactor;
     o.hatchWeight1.z = 1 - o.hatchWeight1.y;
    }

    return o;
   }

   fixed4 frag(v2f o) : SV_Target{
    fixed4 HatchTex0 = tex2D(_Hatch0, o.uv) * o.hatchWeight0.x;
    fixed4 HatchTex1 = tex2D(_Hatch1, o.uv) * o.hatchWeight0.y;
    fixed4 HatchTex2 = tex2D(_Hatch2, o.uv) * o.hatchWeight0.z;
    fixed4 HatchTex3 = tex2D(_Hatch3, o.uv) * o.hatchWeight1.x;
    fixed4 HatchTex4 = tex2D(_Hatch4, o.uv) * o.hatchWeight1.y;
    fixed4 HatchTex5 = tex2D(_Hatch5, o.uv) * o.hatchWeight1.z;
    fixed4 whiteColor = fixed4(1, 1, 1, 1) * (1 - o.hatchWeight0.x - o.hatchWeight0.y - 
     o.hatchWeight0.z - o.hatchWeight1.x - o.hatchWeight1.y - o.hatchWeight1.z);
    fixed4 hatchColor = HatchTex0 + HatchTex1 + HatchTex2 + HatchTex3 + HatchTex4 + HatchTex5 + whiteColor;

    return fixed4(hatchColor.rgb * _Color.rgb , 1.0);
   }
   ENDCG
  }
 }
 Fallback off
}


