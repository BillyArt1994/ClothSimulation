Shader "Billy/Load Bar"
{
    Properties
    {
        _Col ("Col",COLOR) = (1.0,0.0,0.0,1.0)
        _MainTex ("Texture", 2D) = "white" {}
        _Slide ("Slide",Range(0,1)) =1.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparten" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZTest off
        ZWrite off
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
            fixed4 _Col;
            half _Slide;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);             
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _Col* step(1,(i.uv.x+_Slide));
                
                return  col;
            }
            ENDCG
        }
    }
}
