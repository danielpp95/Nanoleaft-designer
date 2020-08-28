Shader "Danielpp95/outline"
{
    Properties
    {
        _Color("Main Color", Color) = (0.5, 0.5, 0.5, 1)
        _MainTex("Texture", 2D) = "white" {}
        _OutlineColor("Outline color", Color) = (0, 0, 0, 1)
        _OutlineWidth("OutlineWidth", Range(1.0, 1.5)) = 1.01
    }

    CGINCLUDE
    #include "UnityCG.cginc"
        
        struct appdata {
            float4 vertex: POSITION;
            float4 normal: NORMAL;
        };

        struct v2f {
            float4 pos: Position;
            float4 normal: NORMAL;
        };

        float _OutlineWidth;
        float _OutlineColor;

        v2f vert(appdata v) {
            v.vertex.xyz *= _OutlineWidth;

            v2f o;
            o.pos = UnityObjectToClipPos(v.vertex);

            return o;
        }

        ENDCG

        SubShader
        {
            // Render the outline
            Pass
            {
                ZWrite Off

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                half4 frag(v2f i) : COLOR
                {
                    return _OutlineColor;
                }

                ENDCG
            }

            // Normal render
            Pass
            {
                ZWrite  On

                Material
                {
                    Diffuse[_Color]
                    Ambient[_Color]
                }

                Lighting On

                SetTexture[_MainText]
                {
                    ConstantColor[_Color]
                }

                SetTexture[_MainText]
                {
                    Combine previous * primary DOUBLE
                }
            }
    }
}
