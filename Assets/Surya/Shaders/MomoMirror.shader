Shader "Custom/MomoMirror" {
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader 
	{
		Pass
		{
			ZTest Always
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma target 3.0
			#include "UnityCG.cginc"
			
			
			uniform sampler2D _MainTex;
			
		       struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };
 
            struct v2f
            {
                  half2 texcoord  : TEXCOORD0;
                  float4 vertex   : SV_POSITION;
                  fixed4 color    : COLOR;
           };   
             
  			v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color;
                
                return OUT;
            }


			float4 frag (v2f i) : COLOR
			{
			 	float2 q 		= i.texcoord.xy;

				bool mirrorHorizontal 	= true;
				bool mirrorVertical 	= false;

				if(mirrorHorizontal && q.x > 0.5) q = float2(1.0-q.x, q.y); 
				if(mirrorVertical && q.y > 0.5)	  q = float2(q.x, 1.0-q.y);
				
				float2 q2 = float2(1.0-q.x, q.y);
				float4 a = tex2D(_MainTex, q);
				float4 b = tex2D(_MainTex, q2);
				float4 screen = a + (1 - a) * b;
				float4 average = (a + b) / 2;
				float4 colorMax = max(a,b);
				float4 colorMin = min(a,b);
				float4 difference = a - b;
				float luminance = (a.r + a.g + a.b) / 3;
				float4 inverted = 1 - a;
				float4 colorFocus = luminance <= 0.5 ? a : float4(luminance, luminance, luminance, 1);
				return screen;
			}
			
			ENDCG
		}
		
	}
}