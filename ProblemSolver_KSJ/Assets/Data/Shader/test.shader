Shader"Custom/CartoonShader"
{
    Properties
    {
        _DiffuseColor("Diffuse Color", Color) = (1, 1, 0, 1)
        _LightDirection("Light Direction", Vector) = (1, 1, 1, 0)

    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
            };

            uniform float4 _DiffuseColor;
            uniform float4 _LightDirection;


            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 normal = normalize(i.normal);
                float3 lightDir = normalize(_LightDirection.xyz);
                float diff = max(dot(normal, lightDir), 0.0);

                // 기본 색상 계산
                float3 color;
                if (diff > 0.7) { //0.8
                    color = _DiffuseColor.rgb; // 노란색
                }
                else if (diff > 0.2) {
                    color = _DiffuseColor.rgb * 0.8; // 연한 노란색
                }
                else {
                    color = float3(0.0, 0.0, 0.0); // 검은색
                }


                return fixed4(color, 1.0);
            }
            ENDCG
        }
    }
}