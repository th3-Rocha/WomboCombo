Shader "Custom/ToonShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _Outline ("Outline width", Range (.002, 0.03)) = .005
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass {
            Name "OUTLINE"
            Tags { "LightMode" = "Always" }
            
            Cull Front
            ZWrite On
            ZTest LEqual
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float4 color : COLOR;
            };

            uniform float _Outline;
            uniform float4 _OutlineColor;

            v2f vert(appdata_t v)
            {
                // just make a copy of incoming vertex data but scaled according to normal direction
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                float3 norm = mul((float3x3)unity_WorldToObject, v.normal);
                o.pos.xy += norm.xy * o.pos.z * _Outline;
                o.color = _OutlineColor;
                return o;
            }

            half4 frag(v2f i) : COLOR
            {
                return i.color;
            }
            ENDCG
        }

        Pass
        {
            Tags { "LightMode"="ForwardBase" }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : TEXCOORD1;
                float3 lightDir : TEXCOORD2;
            };

            uniform float4 _Color;
            uniform sampler2D _MainTex;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.lightDir = normalize(_WorldSpaceLightPos0.xyz);
                return o;
            }

            half4 frag (v2f i) : COLOR
            {
                float3 normal = normalize(i.normal);
                float3 lightDir = normalize(i.lightDir);
                float ndotl = max(dot(normal, lightDir), 0);
                float4 c = tex2D(_MainTex, i.uv) * _Color;

                // Toon shading
                if (ndotl > 0.5)
                    ndotl = 1.0;
                else
                    ndotl = 0.5;

                c.rgb *= ndotl;
                return c;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}
