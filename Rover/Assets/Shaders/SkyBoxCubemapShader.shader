// INEDI apps (c)
// 
// Rotation stars (0,0,0) - Polar star orientation (earth nord)
// Rotation stars (0, 23.26 ,0) - Dragon orientation (moon nord) 23.26 the angle between the earth's equator and the ecliptic
// RotationX stars - use for 0h longitude set (нулевой отметкой является место на небе, где Солнце пересекает небесный экватор в весеннее равноденствие)
// _RotationX - use in unity for simulate rotate planet
// _RotationZ - angle for place (46 - for N 44  10' 54.55''  W 31  25' 42.86'') (90-44 = 46)
// use Exposure = 0 for off overlay textures

Shader "INEDI/SkyBoxCubemapShader"
{
	Properties{
		[Gamma] _Exposure("Exposure StarMap", Range(0, 8)) = 1.0
		_Tint("Tint StarMap", Color) = (.5, .5, .5, .5)
		[NoScaleOffset] _Tex("Cubemap (HDR) StarMap", Cube) = "grey" {}

		[Gamma] _Exposure2("Exposure Figures", Range(0, 8)) = 1.0
		_Tint2("Tint Figures", Color) = (.5, .5, .5, 1)
		[NoScaleOffset] _Tex2("Cubemap (HDR) Figures", Cube) = "grey" {}

		[Gamma] _Exposure3("Exposure Grid", Range(0, 8)) = 1.0
		_Tint3("Tint Grid", Color) = (.5, .5, .5, 1)
		[NoScaleOffset] _Tex3("Cubemap (HDR) Grid", Cube) = "grey" {}

		// Rotation Grid 
		_RotationX("RotationX", Range(-360, 360)) = 0
		_RotationY("RotationY", Range(-360, 360)) = 0
		_RotationZ("RotationZ", Range(-360, 360)) = 0
		// Rotation stars 
		_RotationX2("RotationX stars", Range(-360, 360)) = 0
		_RotationY2("RotationY stars", Range(-360, 360)) = 0
		_RotationZ2("RotationZ stars", Range(-360, 360)) = 0
	}

	SubShader{
			Tags { "Queue" = "Background" "RenderType" = "Background" "PreviewType" = "Skybox" }
			Cull Off ZWrite Off

		Pass {
				CGPROGRAM
				#pragma vertex vert 
				#pragma fragment frag

				#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
			};

			struct v2f {
				float4 pos : SV_POSITION;
				float3 uvstars : TEXCOORD0;
				float3 uvgrid : TEXCOORD1;
			};

			samplerCUBE _Tex;
			samplerCUBE _Tex2;
			samplerCUBE _Tex3;
			half4 _Tex_HDR;
			half _Exposure;
			half _Exposure2;
			half _Exposure3;
			half4 _Tint;
			half4 _Tint2;
			half4 _Tint3;
			float _RotationX;
			float _RotationY;
			float _RotationZ;
			float _RotationX2;
			float _RotationY2;
			float _RotationZ2;

			float3 RotateAroundXInDegrees(float3 vertex, float degrees)
			{
				float alpha = degrees * UNITY_PI / 180.0;
				float sina, cosa;
				sincos(alpha, sina, cosa);
				float2x2 m = float2x2(cosa, -sina, sina, cosa);
				return float3(mul(m, vertex.xz), vertex.y).zyx;
			}

			v2f vert(appdata v)
			{
				v2f output;

				// stars and figures positions
				float3 r = RotateAroundXInDegrees(v.vertex, _RotationX2);
				r = RotateAroundXInDegrees(r, _RotationY2);
				r = RotateAroundXInDegrees(r, _RotationZ2);
				output.uvstars = r;

				//sky rotation
				r = RotateAroundXInDegrees(v.vertex, _RotationX);
				r = RotateAroundXInDegrees(r, _RotationY);
				r = RotateAroundXInDegrees(r, _RotationZ);
				output.pos = UnityObjectToClipPos(r);

				//grid position
				output.uvgrid = v.vertex.xyz;

				return output;
			}

			fixed4 frag(v2f input) : SV_Target
			{
				float4 tex1 = texCUBE(_Tex, input.uvstars) * _Tint  * _Exposure;
				float4 tex = tex1;

				if (_Exposure2 != 0) //figures draw
				{
					tex1 = texCUBE(_Tex2, input.uvstars)* _Tint2 * _Exposure2;
					tex += tex1;
				}
				
				if (_Exposure3 != 0) // grid draw
				{
					tex1 = texCUBE(_Tex3, input.uvgrid) * _Tint3 * _Exposure3;
					tex += tex1;
				}

				half3 c = DecodeHDR(tex, _Tex_HDR);

				return half4(c, 1);
			}
			ENDCG
		}
	}
	Fallback Off
}
