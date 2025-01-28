Shader "Custom/GlowShader"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _GlowColor ("Glow Color", Color) = (1,1,1,1)
        _MinimumGlow ("Minimum Glow Intensity", Range(0,5)) = 0.5
        _MaximumGlow ("Maximum Glow Intensity", Range(0,5)) = 0.5
        _GlowSpeed ("Glow Speed", Range(0, 10)) = 2.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100

        Pass    
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
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
            float4 _GlowColor;
            float _MinimumGlow;
            float _MaximumGlow;
            float _GlowSpeed;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Sample the sprite texture
                fixed4 col = tex2D(_MainTex, i.uv);

                // Calculate animated glow intensity using a sine wave
                float time = _Time.y * _GlowSpeed;
                float glowIntensity = lerp(_MinimumGlow, _MaximumGlow, (sin(time) + 1.0) / 2.0);


                // Add the glow effect
                col.rgb += _GlowColor.rgb * glowIntensity;

                // Return the final color
                return col;
            }
            ENDCG
        }
    }
}
