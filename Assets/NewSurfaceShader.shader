Shader "Custom/NewSurfaceShader" {
	Properties {
		// 定义一个名为color 的颜色属性
		_Color ("Color", Color) = (1,.5,.5,1)
	}
	SubShader {
			// shader实现代码
			Pass{
			 Material{
			       Diffuse [_Color]
		             }
			Lighting On
              }
	}
	FallBack "Diffuse"
}
