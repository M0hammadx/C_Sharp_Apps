#version 330 core
out vec4 FragColor;

in vec3 ourColor;
in vec2 TexCoord;
in vec4 glPos;

// texture samplers
uniform sampler2D texture1;
uniform sampler2D texture2;

uniform float ratio;

void main()
{
	FragColor = mix(texture(texture1, TexCoord), texture(texture2, vec2(1.0 - TexCoord.x, TexCoord.y)), ratio);
	 //FragColor = mix(texture(texture1, TexCoord), texture(texture2, TexCoord), 0.2);
	//FragColor = texture(ourTexture, TexCoord) * vec4(ourColor, 1.0);  
    //FragColor = glPos;
    //FragColor = vec4(ourColor, 1.0f);
}

