Shader "INEDI/SkyBoxCubemapShader"
{
	Properties{
		 _Tint("Tint Color", Color) = (.5, .5, .5, .5)
		 [Gamma] _Exposure("Exposure", Range(0, 8)) = 1.0
		 _Tex("Cubemap (HDR)", Cube) = "grey" {}
		 _RotationX("RotationX", Range(0, 360)) = 0
		 _RotationY("RotationY", Range(0, 360)) = 0
		 _RotationZ("RotationZ", Range(0, 360)) = 0
	}

	SubShader{
			Tags { "Queue" = "Background" "RenderType" = "Background" "PreviewType" = "Skybox" }
			Cull Off ZWrite Off

		Pass {
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				//#pragma target 4.0 //delete for old shader systems

				#include "UnityCG.cginc"

			samplerCUBE _Tex;
			half4 _Tex_HDR;
			half4 _Tint;
			half _Exposure;
			float _RotationX;
			float _RotationY;
			float _RotationZ;

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
				float3 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				float3 texcoord : TEXCOORD0;
			};

			v2f vert(appdata_t v)
			{
				v2f o;
				float3 r = RotateAroundXInDegrees(v.vertex, _RotationX);
				r = RotateAroundXInDegrees(r, _RotationY);
				r = RotateAroundXInDegrees(r, _RotationZ);
				o.vertex = UnityObjectToClipPos(r);
				o.texcoord = v.texcoord;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				half4 tex = texCUBE(_Tex, i.texcoord);

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
