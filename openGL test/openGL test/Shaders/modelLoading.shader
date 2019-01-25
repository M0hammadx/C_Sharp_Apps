

#version 330 core
layout(location = 0) in vec3 aPos;
layout(location = 1) in vec3 aNormal;
layout(location = 2) in vec2 aTexCoords;

out vec2 TexCoords;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
	TexCoords = aTexCoords;
	gl_Position = projection * view * model * vec4(aPos, 1.0);
}



#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D texture_diffuse1;
uniform sampler2D texture_specular1;
uniform sampler2D texture_normal1;
//uniform sampler2D texture_height1;


float near = 0.1;
float far = 100.0;

float LinearizeDepth(float depth)
{
	float z = depth * 2.0 - 1.0; // back to NDC 
	return (2.0 * near * far) / (far + near - z * (far - near));
}


void main()
{
	FragColor = texture(texture_diffuse1, TexCoords);// *0.7 + texture(texture_specular1, TexCoords)*0.5 /*+texture(texture_normal1, TexCoords)*/;
//	FragColor = vec4(vec3(gl_FragCoord.z), 1.0);
	//float depth = LinearizeDepth(gl_FragCoord.z) / far; // divide by far for demonstration
	//FragColor = vec4(vec3(depth), 1.0);

}

