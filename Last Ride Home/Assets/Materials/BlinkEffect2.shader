Shader "Unlit/BlinkEffect2"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlackFade ("BlackFade",float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
            float _BlackFade;

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
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                fixed4 black = fixed4(0,0,0,1);
                float origin_blackout = (i.uv.x - 0.5)*(i.uv.x - 0.5) + (i.uv.y - 0.5)*(i.uv.y - 0.5);
                fixed4 result = lerp(black,col,1-origin_blackout-_BlackFade);
                return result;
            }
            ENDCG
        }
    }
}
