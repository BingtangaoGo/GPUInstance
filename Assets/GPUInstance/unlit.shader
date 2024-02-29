Shader "test/Ulit"
{
    Properties
    {
          [MainTexture] _BaseMap("Texture", 2D) = "white" {}
          _ExampleName ("Float display name", Float) = 1
    }
    SubShader
    {
        Tags { "RenderPipeline" = "UniversalPipeline" "ShaderModel"="4.5"}
       
        pass{
            
             HLSLPROGRAM
          
              #pragma target 4.5
              #pragma vertex vert
              #pragma fragment frag

                  #pragma multi_compile_instancing
      #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/core.hlsl"

            CBUFFER_START(UnityPerMaterial)
        TEXTURE2D(_BaseMap);     
                SAMPLER(sampler_BaseMap);    
            
            CBUFFER_END
                float _ExampleName;
            float4 _color[3];
      //   int   unity_InstanceID;
              struct Attributes{
                    float4 positionOS : POSITION;
                    float2 uv:TEXCOORD0;
                     UNITY_VERTEX_INPUT_INSTANCE_ID
              };
              struct Varyings{
                 float4 positionCS : SV_POSITION;
                   float2 uv:TEXCOORD0;
                     UNITY_VERTEX_INPUT_INSTANCE_ID
              };

              Varyings vert(Attributes input){
                  Varyings output=(Varyings)0;
                  
    UNITY_SETUP_INSTANCE_ID(input);
    UNITY_TRANSFER_INSTANCE_ID(input, output);
                    float3 positionWS = TransformObjectToWorld(input.positionOS.xyz);
                    float4 positionCS = TransformWorldToHClip(positionWS);
                
                      output.positionCS=positionCS;
                    output.uv=input.uv;
                    return output;
              }

              half4 frag(Varyings input):SV_TARGET{
                     UNITY_SETUP_INSTANCE_ID(input);
                  half4 color=SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap,input.uv);
                  return color*_ExampleName;
                   // return _Color1;
              }
              ENDHLSL
        }
 
    }
}
