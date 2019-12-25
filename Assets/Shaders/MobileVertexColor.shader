Shader "Alpha/VertexLit Colored" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,1)
    }

    SubShader {
        CGPROGRAM
        #pragma surface surf Lambert alpha
        struct Input {
            float4 color : COLOR;
        };
        fixed4 _Color;

        void surf(Input IN, inout SurfaceOutput o) {
            o.Albedo = IN.color.rgb ;
        }
        ENDCG
    }
}