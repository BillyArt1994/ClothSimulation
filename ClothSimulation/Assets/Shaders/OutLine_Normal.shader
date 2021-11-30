Shader "Billy/OutLine_normal"
{
    Properties
    {
        _OutLineColor("OutLineColor",COLOR) = (1.0,1.0,1.0,1.0)
        _MainCol ("MainCol",COLOR) = (1.0,1.0,1.0,1.0)
        _MainTex ("Texture", 2D) = "white" {}
        _Speed("Speed",FLoat) = 1
        _Offset("Offset",Float) = 1
    }
        SubShader
        {
            Pass
        {
            Tags { "RenderType" = "Opaque" }
           
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
                float3 worldNormal :NORMAL;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _MainCol;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldNormal = UnityObjectToWorldNormal( v.normal);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv)*_MainCol;
                half NdotL = dot(i.worldNormal, _WorldSpaceLightPos0.rgb)*0.5+0.5;
                return col*NdotL;
            }
            ENDCG
        }

            Pass{
                Tags {  "RenderType" = "Opaque"}
                //     ZWrite Off
                Cull front
                // Offset 0,100
                //blend SrcAlpha OneMinusSrcAlpha

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"
                float _Offset;
                fixed4 _OutLineColor;
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
                    v.vertex.xyz += v.normal* Remap(sin(t * _Speed),0,1, _Offset, _Offset + 0.001);
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.color = _OutLineColor;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target{
                    return i.color;
                }

                ENDCG
            }

        }
}
