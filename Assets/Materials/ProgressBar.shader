// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/ProgressBar"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Fillpercentage("Fill percentage", Range(0 , 1)) = 0.25

    }
    SubShader
    {
        Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
        LOD 100

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			uniform float _Fillpercentage;
			float2 Mask;
			float pct;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				float2 st = i.uv;
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
				float Fillpercentage140 = _Fillpercentage;
				float MainbarFillPercentage = floor(Fillpercentage140 * 10) / 10;
				float pct = step(((0.092 - 0.072)*ceil(MainbarFillPercentage))*st.y + 0.072*ceil(MainbarFillPercentage) +  0.104*(clamp(0, 10, (MainbarFillPercentage*10-1))), st.x);
				//switch (MainbarFillPercentage)
				//{
				//	if (MainbarFillPercentage == 1)
				//		pct = smoothstep(27/371,34/371,i.uv.x);
				//}
				col.a = col.a * (1.0-pct);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
