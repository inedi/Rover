﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "Custom/testShader"
{

	Properties{
	   _Tint("Tint Color", Color) = (.5, .5, .5, 1)
	   _Tint2("Tint Color 2", Color) = (.5, .5, .5, 1)
	   [Gamma] _Exposure("Exposure", Range(0, 8)) = 1.0
	   _Rotation("Rotation", Range(0, 360)) = 0
	   _BlendCubemaps("Blend Cubemaps", Range(0, 1)) = 0.5
	   [NoScaleOffset] _Tex("Cubemap (HDR) StarMap", Cube) = "grey" {}
	   [NoScaleOffset] _Tex2("Cubemap (HDR) Grid", Cube) = "grey" {}
	   [NoScaleOffset] _Tex3("Cubemap (HDR) Figures", Cube) = "grey" {}
	}
		SubShader{
			Tags { "Queue" = "Background" "RenderType" = "Background" "PreviewType" = "Skybox" }
			Cull Off ZWrite Off

		Blend One OneMinusSrcColor
			Pass {

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				samplerCUBE _Tex;
				samplerCUBE _Tex2;
				samplerCUBE _Tex3;
				float _BlendCubemaps;
				half4 _Tex_HDR;
				half4 _Tint;
				half4 _Tint2;
				half _Exposure;
				float _Rotation;


				float4 RotateAroundYInDegrees(float4 vertex, float degrees)
				{
					float alpha = degrees * UNITY_PI / 180.0;
					float sina, cosa;
					sincos(alpha, sina, cosa);
					float2x2 m = float2x2(cosa, -sina, sina, cosa);
					return float4(mul(m, vertex.xz), vertex.yw).xzyw;
				}

				struct appdata_t {
					float4 vertex : POSITION;
					float3 normal : NORMAL;
				};

				struct v2f {
					float4 vertex : SV_POSITION;
					float3 texcoord : TEXCOORD0;
				};

				v2f vert(appdata_t v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(RotateAroundYInDegrees(v.vertex, _Rotation));
					o.texcoord = v.vertex;
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					float4 env1 = texCUBE(_Tex, i.texcoord);
					float4 env2 = texCUBE(_Tex2, i.texcoord);
					float4 env3 = texCUBE(_Tex3, i.texcoord);
					float4 env = env1;// +env2 + env3;
					//half3 c = DecodeHDR(env, _Tex_HDR);
				
					float4 tint = lerp(_Tint, _Tint2, _BlendCubemaps);
					half3 c = DecodeHDR(env, _Tex_HDR);
					c = c * tint.rgb * unity_ColorSpaceDouble;
					c *= _Exposure;

					return half4(c, 1);
				}
				ENDCG
			}
	}
		Fallback Off
}