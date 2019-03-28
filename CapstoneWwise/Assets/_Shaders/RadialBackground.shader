Shader "Unlit/RadialBackground"
{
    Properties
    {
        _GradientTex ("Gradient Texture", 2D) = "white" {}
        _CenterX ("Center X", Float) = 0.5
        _CenterY ("Center Y", Float) = 0.5
        _Transparency ("Transparency", Float) = 0.5

    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}

        Zwrite Off
        Blend SrcAlpha OneMinusSrcAlpha

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


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            sampler2D _GradientTex;
            
            float _CenterX;
            float _CenterY;
            float _Transparency;

            fixed4 frag (v2f i) : SV_Target
            {
                
                float xDist = i.uv.x - _CenterX;
                float yDist = i.uv.y - _CenterY;
                float trueDist = sqrt(pow(xDist, 2) + pow(yDist, 2))/2;
                float relativeDist = saturate(trueDist);
                
                //float transparentVal = saturate(i.vertex.y);
                //transparentVal = _Transparency + 1 - (transparentVal / (1 / _Transparency));
                
                float4 col = float4(tex2D(_GradientTex, float2(relativeDist, 0.5)).rgb, _Transparency);
                
                
                return col;
            }
            ENDCG
        }
    }
}
