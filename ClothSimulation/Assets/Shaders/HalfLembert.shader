Shader "Billy/HalfLembertion"
{
    Properties
    {
        _MainCol ("MainCol",COLOR) = (1.0,1.0,1.0,1.0)
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Cull off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                half3 normal :NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                half3 worldNormal :TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _MainCol;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);
                fixed NdotL =max(dot(i.worldNormal,worldLightDir),0.001);
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb = GammaToLinearSpace(col.rgb);
                col.rgb*=NdotL*0.5+0.5;
                col *=_MainCol;
                col.rgb = LinearToGammaSpace(col.rgb);
                return col;
            }
            ENDCG
        }
    }
}
