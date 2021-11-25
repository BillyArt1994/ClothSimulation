Shader "Billy/OutLine"
{
    Properties
    {
        _Color("Color",COLOR) = (1.0,1.0,1.0,1.0)
        _MainTex ("Texture", 2D) = "white" {}
        _Speed("Speed",FLoat) = 1
        _Offset("Offset",Float) = 1
    }
        SubShader
        {
           

            Pass{
                Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
                ZWrite Off
          //      offset 20 20
            blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            float _Offset;
            fixed4 _Color;
            half _Speed;

        struct appdata
        {
            float4 vertex : POSITION;
            float3 normal :NORMAL;
        };

             struct v2f {
            float4 pos: SV_POSITION;
            fixed4 color : COLOR;
        };
             //映射函数Remap
             inline half Remap(half x, half t1, half t2, half s1, half s2)
             {
                 return (x - t1) / (t2 - t1) * (s2 - s1) + s1;
             }

             inline half2 Remap(half2 coordinate, half t1, half t2, half s1, half s2)
             {
                 coordinate -= t1;
                 coordinate *= (1 / (t2 - t1) * (s2 - s1));
                 coordinate += s1;
                 return coordinate;
             }

            v2f vert(appdata v) {
                v2f o;
                float t = _Time.x;
                v.vertex.xyz *=(_Offset* Remap(sin(t*_Speed), -1, 1, _Offset, _Offset+0.1));
                o.pos = UnityObjectToClipPos(v.vertex);
                o.color = _Color;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target{
                return i.color;
            }

            ENDCG
        }

        Pass
        {
            Tags { "RenderType" = "Opaque" }
            Cull off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal :NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal :NORMAL;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.normal = v.normal;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                half NdotL = dot(i.normal, _WorldSpaceLightPos0);
                return col;
            }
            ENDCG
        }
    }
}
