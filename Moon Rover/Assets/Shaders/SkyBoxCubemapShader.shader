// Rotation stars (0,0,0) - Polar star orientation (earth nord)
// Rotation stars (0,0,0) - Polar star orientation (moon nord)
// RotationX stars - use for 0h longitude set
// _RotationX - use in unity for simulate rotate planet

Shader "INEDI/SkyBoxCubemapShader"
{
	Properties{
		 _Tint("Tint Color", Color) = (.5, .5, .5, .5)
		 [Gamma] _Exposure("Exposure", Range(0, 8)) = 1.0
		 [NoScaleOffset] _Tex("Cubemap (HDR) StarMap", Cube) = "grey" {}
		 [NoScaleOffset] _Tex2("Cubemap (HDR) Figures", Cube) = "grey" {}
		 [NoScaleOffset] _Tex3("Cubemap (HDR) Grid", Cube) = "grey" {}
		 _RotationX("RotationX", Range(0, 360)) = 0
		 _RotationY("RotationY", Range(0, 360)) = 0
		 _RotationZ("RotationZ", Range(0, 360)) = 0
		 _RotationX2("RotationX stars", Range(0, 360)) = 0
		 _RotationY2("RotationY stars", Range(0, 360)) = 0
		 _RotationZ2("RotationZ stars", Range(0, 360)) = 0
	}

	SubShader{
			Tags { "Queue" = "Background" "RenderType" = "Background" "PreviewType" = "Skybox" }
			Cull Off ZWrite Off

		Pass {
				CGPROGRAM
				#pragma vertex vert 
				#pragma fragment frag

				#include "UnityCG.cginc"

			samplerCUBE _Tex;
			samplerCUBE _Tex2;
			samplerCUBE _Tex3;
			half4 _Tex_HDR;
			half4 _Tint;
			half _Exposure;
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

			struct appdata_t {
				float4 vertex : POSITION;
			};

			struct v2f {
				float4 pos : SV_POSITION;
				float3 uvstars : TEXCOORD0;
				float3 uvgrid : TEXCOORD1;
			};

			v2f vert(appdata_t v)
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
				float4 tex1 = texCUBE(_Tex, input.uvstars);
				float4 tex2 = texCUBE(_Tex2, input.uvstars);
				float4 tex3 = texCUBE(_Tex3, input.uvgrid);
				float4 tex = tex1 + tex3 + tex2;

				half3 c = DecodeHDR(tex, _Tex_HDR);
				c = c * _Tint.rgb * unity_ColorSpaceDouble.rgb;
				c *= _Exposure;

				return half4(c, 1);
			}
			ENDCG
		}
		
	}
		Fallback Off
}
