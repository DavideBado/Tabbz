Shader "Custom/Outline"
{
    Properties //Variables
    {
        _Color ("Color", Color) = (1,1,1,1) //Allows for a color property
        _MainTex ("Main Texture (RGB)", 2D) = "white" {} //Allows for a texture property
	
		_OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineTex ("Outline Texture (RGB)", 2D) = "white" {}
		_OutlineWidth("Outline Width", Range(1.0, 10.0)) = 1.1
    }
    SubShader
    {
		Tags
		{
			"Queque" = "Transparent"
			//"RenderedByReplacementCamera" = "True"
		}
		Pass
		{
			Name "OUTLINE"

			ZWrite Off

			CGPROGRAM//Allows talk between two languages: shader lab and nvidia C for graphics

			///===================================================================================
			/// Function Defines - defines the name for the vertex and fragment functions
			///====================================================================================

			#pragma vertex vert//Define for the building function.

			#pragma fragment frag//Define for the coloring function.

			///====================================================================================
			/// Includes
			///====================================================================================

			#include "UnityCG.cginc"//Built in shader functions.

			///=====================================================================================
			/// Structures - Can get data like - vertices's, normal, color, uv.
			///=====================================================================================

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			///=====================================================================================
			/// Imports - Re-import property from shader lab to nvidia cg
			///=====================================================================================

			float _OutlineWidth;
			float4 _OutlineColor;
			sampler2D _OutlineTex;

			///=====================================================================================
			/// Vertex Function - Builds the object
			///=====================================================================================

			v2f vert(appdata IN)
			{
				IN.vertex.xyz *= _OutlineWidth;
				v2f OUT;

				OUT.pos = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			///=====================================================================================
			/// Fragment Function - Color it in
			///=====================================================================================

			fixed4 frag(v2f IN) : SV_Target
			{
				float4 texColor = tex2D(_OutlineTex, IN.uv);
				return texColor * _OutlineColor;
			}

			ENDCG
		}

		Pass
		{
			Name "OBJECT"

			CGPROGRAM//Allows talk between two languages: shader lab and nvidia C for graphics

			///===================================================================================
			/// Function Defines - defines the name for the vertex and fragment functions
			///====================================================================================
			
			#pragma vertex vert//Define for the building function.

			#pragma fragment frag//Define for the coloring function.

			///====================================================================================
			/// Includes
			///====================================================================================
			
			#include "UnityCG.cginc"//Built in shader functions.

			///=====================================================================================
			/// Structures - Can get data like - vertices's, normal, color, uv.
			///=====================================================================================

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};
		
			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			///=====================================================================================
			/// Imports - Re-import property from shader lab to nvidia cg
			///=====================================================================================
		
			float4 _Color;
			sampler2D _MainTex;

			///=====================================================================================
			/// Vertex Function - Builds the object
			///=====================================================================================

			v2f vert(appdata IN)
			{
				v2f OUT;

				OUT.pos = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			///=====================================================================================
			/// Fragment Function - Color it in
			///=====================================================================================

			fixed4 frag(v2f IN) : SV_Target
			{
				float4 texColor = tex2D(_MainTex, IN.uv);
				return texColor * _Color;
			}

			ENDCG
		}
    }
}
