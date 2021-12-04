Shader "Billy/HigthLight"
{
    Properties
    {
        _HLCol ("HigthLightCol",COLOR) = (1.0,1.0,1.0,1.0)
        _MainTex ("Texture", 2D) = "white" {}
        _Speed ("Speed",Float) = 1
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
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _HLCol;
            float _Speed;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            //映射函数Remap
            half Remap(half x, half t1, half t2, half s1, half s2)
            {
                return (x - t1) / (t2 - t1) * (s2 - s1) + s1;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float t = _Time.x;
                float sint = Remap(sin(t*_Speed),-1,1,0,1);
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb = lerp(col.rgb,_HLCol.rgb,sint);
                return col;
            }
            ENDCG
        }
    }
}
