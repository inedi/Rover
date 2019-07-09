/* Base Shader code from free package:
 https://assetstore.unity.com/packages/vfx/shaders/free-earth-planet-the-best-planet-shader-in-the-asset-store-56841?aid=1011lGnL&utm_source=aff
 The MIT License(MIT)
 Copyright(c) 2016 Digital Ruby, LLC*/

//This Shader code from INEDI apps
Shader "INEDI/PlanetShader"
{
	Properties
	{
		[NoScaleOffset] _MainTex("Planet Texture", 2D) = "white" {}
		[NoScaleOffset] _NightTex("Night Texture", 2D) = "black" {}
		_DayTintColor("Day Tint Color", Color) = (1,1,1,1)
		_Smoothness("Smoothness Light", Range(0,1)) = 0.5
		_NightIntensity("Night Detail Intensity", Range(0, 1)) = 0.0
		_NightTransitionVariable("Night Transition Variable", Range(1, 64)) = 4
		_RimColor("Rim Color", Color) = (0.26,0.19,0.16,1.0)
		_RimPower("Rim Power", Range(0.5, 64.0)) = 3.0
		_RimIntensity("Rim Intensity", Range(0.0, 100.0)) = 2.0
			//Used for preview window
		_SunDir("Sun Dir", Vector) = (0.2, 0.3, 0.4, 0.0)
	}
	SubShader
	{
		Tags { "Queue"="Geometry" }

		Pass
		{
			CGPROGRAM
		  //#pragma target 3.5
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
				float3 rayDir : TEXCOORD1;
			};

			uniform sampler2D _MainTex;
			uniform sampler2D _NightTex;

			uniform fixed4 _DayTintColor;
			uniform fixed _Smoothness;
			uniform fixed _NightIntensity;
			uniform fixed _NightTransitionVariable;
			
			uniform fixed4 _RimColor;
			uniform fixed _RimPower;
			uniform fixed _RimIntensity;

			uniform fixed3 _SunDir;

			static const float3 forwardVector = mul((float3x3)unity_CameraToWorld, float3(0, 0, 1));
			static const float3 sunDir = normalize(_SunDir);

			inline float3 WorldSpaceVertexPos(float4 vertex)
			{
				return mul(unity_ObjectToWorld, vertex).xyz;
			}

			inline float3 WorldSpaceNormal(float3 normal)
			{
				return mul((float3x3)unity_ObjectToWorld, normal);
			}

			v2f vert (appdata v)
			{
				v2f output;
				output.pos = UnityObjectToClipPos(v.vertex);
				output.uv = v.uv;
				output.normal = WorldSpaceNormal(v.normal);
				output.rayDir = _WorldSpaceCameraPos - WorldSpaceVertexPos(v.vertex);
				return output;
			}
			
			fixed4 frag (v2f input) : SV_Target
			{
				float3 rayDir = normalize(input.rayDir);
				fixed4 dayColor = tex2D(_MainTex, input.uv) *_DayTintColor;
				
				fixed3 nightColor = tex2D(_NightTex, input.uv).rgb;
				fixed maxNight = min(1, nightColor.g + _NightIntensity);
				nightColor *= pow(maxNight, 10.0);
				float3 worldNormal = input.normal;
				float3 worldNormalMapped = normalize(worldNormal);

				fixed rim = 1.0 - saturate(dot(normalize(rayDir), worldNormal));
				fixed3 emission = (_RimColor.rgb * pow(rim, _RimPower));

				fixed3 h = normalize(_SunDir + rayDir);
				fixed d = max(0.0, dot(worldNormal, _SunDir));
				fixed e = max(0.0, dot(worldNormalMapped, _SunDir));
				fixed nh = max(0.0, dot(worldNormalMapped, h));
				fixed specTerm = pow(nh, 1) * _Smoothness;

				fixed4 result;
				fixed3 sunIntensity = 1 * d;
				fixed3 dayColorSpec = (dayColor * sunIntensity * e) + (specTerm * dayColor);

				result.a = 1.0;
				result.rgb = lerp(nightColor, dayColorSpec, saturate(_NightTransitionVariable * d));
				result.rgb += (emission.rgb * _RimIntensity * nh);
				return result;
			}
			ENDCG
		}
	}
	Fallback Off
}
