Shader "Unlit/Texture Tint" {

Properties {
	_Color ("Tint Color", Color) = (1,1,1)
	_MainTex ("Texture  (A = Tint Mask)", 2D) = ""
}

SubShader {Pass {	// iPhone 3GS and later
	GLSLPROGRAM
	varying mediump vec2 uv;
	
	#ifdef VERTEX
	void main() {
		gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
		uv = gl_MultiTexCoord0.xy;
	}
	#endif
	
	#ifdef FRAGMENT
	uniform lowp sampler2D _MainTex;
	uniform lowp vec3 _Color;
	void main() {
		vec4 texture = texture2D(_MainTex, uv);
		gl_FragColor = vec4(texture.rgb * (_Color * texture.a + (1. - texture.a)), 1);
	}
	#endif		
	ENDGLSL
}}

SubShader {Pass {	// pre-3GS devices, including the September 2009 8GB iPod touch
	SetTexture[_MainTex] {Combine texture alpha * one - constant ConstantColor[_Color]}				
	SetTexture[_MainTex] {Combine texture * one - previous}
}}

}