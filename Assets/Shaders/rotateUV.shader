﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/rotateUV"
{
	
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Angle("Angle", float) = 0.0
		_Speed("Speed", float) = 0.2
		_Transparency("Transparency", Range(0.0,0.5)) = 0.25
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			float _Angle;
			uniform float _Speed;
		

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				// Pivot
				_Angle = lerp(-0.5, 0.5, _Time.a * _Speed);
				float2 pivot = float2(0.5, 0.5);
				// Rotation Matrix
				float cosAngle = cos(_Angle);
				float sinAngle = sin(_Angle);
				float2x2 rot = float2x2(cosAngle, -sinAngle, sinAngle, cosAngle);
				

				// Rotation consedering pivot
				float2 uv = v.texcoord.xy - pivot;
				o.uv = mul(rot, uv);
				o.uv += pivot;

				return o;
			}

			sampler2D _MainTex;
			float _Transparency;

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				col.a = _Transparency;
				// Texel sampling
				return col;
			}

			ENDCG
		}
	}
}
