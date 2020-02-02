Shader "Custom/OtherWaterShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		[NoScaleOffset] _FlowMap("Flowmap", 2D) = "black" {}
		_UJump("U jump", Range(-.25, .25)) = .25
		_VJump("V jump", Range(-.25, .25)) = .25
		_Tiling("Tiling", Float) = 1
		_Speed("Speed", Float) = 1
		_FlowStrength("Strength", Float) = 1
		_FlowOffset("Offset", Float) = 0
		_Amp("Amplitude", Float) = 1
	}
		SubShader
		{
			Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
			LOD 200

			CGPROGRAM
			#pragma surface surf Standard alpha fullforwardshadows
			#pragma target 3.0

			sampler2D _MainTex, _FlowMap;
			float _UJump, _VJump, _Tiling, _Speed, _FlowStrength, _FlowOffset;

			struct Input
			{
				float2 uv_MainTex;
			};

			half _Glossiness;
			half _Metallic;
			fixed4 _Color;
			float _Amp;

			float3 FlowUVW(float2 uv, float2 flowVector, float2 jump, float flowOffset, float tiling, float time, bool flowB)
			{
				float phaseOffset;
				switch (flowB)
				{
				case true:
					phaseOffset = .5f;
					break;
				default:
					phaseOffset = 0;
					break;
				}
				float3 uvw;
				uvw.xy = uv - flowVector * (frac(time + phaseOffset) + flowOffset);
				uvw.xy *= tiling;
				uvw.xy += phaseOffset;
				uvw.xy += (time - frac(time + phaseOffset) * jump);
				uvw.z = 1 - abs(1 - 2 * frac(time + phaseOffset));
				return uvw;
			}

			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				float2 flowVector = (tex2D(_FlowMap, IN.uv_MainTex).rg * 2 - 1) * _FlowStrength;
				float noise = tex2D(_FlowMap, IN.uv_MainTex).a;
				float2 jump = float2(_UJump, _VJump);
				float3 uvwA = FlowUVW(IN.uv_MainTex, flowVector, jump, _FlowOffset, _Tiling, _Time.y * _Speed + noise, false);
				float3 uvwB = FlowUVW(IN.uv_MainTex, flowVector, jump, _FlowOffset, _Tiling, _Time.y * _Speed + noise, true);
				fixed4 texA = tex2D(_MainTex, uvwA.xy) * uvwA.z;
				fixed4 texB = tex2D(_MainTex, uvwB.xy) * uvwB.z;
				fixed4 c = (texA + texB) * _Color;
				o.Albedo = c.rgb;
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c.a;
			}
		ENDCG
		}
			FallBack "Diffuse"
}
