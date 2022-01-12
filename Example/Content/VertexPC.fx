#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

matrix WorldViewProjection;
bool EnableTexture = false;

bool FlipX = false;
bool FlipY = false;

Texture2D Texture : register(t0);

sampler TextureSampler : register(s0)
{
	Texture = (Texture);
	MinFilter = Point; // Minification Filter
	MagFilter = Point; // Magnification Filter
	MipFilter = Point; // Mip-mapping
	AddressU = Wrap; // Address Mode for U Coordinates
	AddressV = Wrap; // Address Mode for V Coordinates
};

struct VertexShaderInput
{
	float4 Position : POSITION0;
	float2 TextureUVs : TEXCOORD0;
	float4 Color : COLOR0;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float2 TextureUVs : TEXCOORD0;
	float4 Color : COLOR0;
};

VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output = (VertexShaderOutput)0;

	output.Position = mul(input.Position, WorldViewProjection);
	output.TextureUVs = input.TextureUVs;
	output.Color = input.Color;

	return output;
}

float4 MainPS(VertexShaderOutput input) : COLOR
{

    float4 color = input.Color;

    if (EnableTexture == true) 
    {
        return tex2D(TextureSampler, input.TextureUVs) * color;
    }
    
	return color;
}

technique BasicColorDrawing
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL MainVS();
		PixelShader = compile PS_SHADERMODEL MainPS();
		CullMode = NONE;
	}
};