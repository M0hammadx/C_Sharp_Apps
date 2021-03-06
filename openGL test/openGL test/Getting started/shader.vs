#version 330 core
layout (location = 0) in vec3 aPos;
//layout (location = 1) in vec3 aColor;
layout (location = 1) in vec2 aTexCoord;

//out vec3 ourColor;
out vec2 TexCoord;
//out vec4 glPos;

//uniform mat4 transform;
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
//uniform float xOffset;
void main()
{
	gl_Position = projection * view * model * vec4(aPos, 1.0);
   // gl_Position =  transform *vec4(aPos, 1.0);
    //ourColor = aColor;
    TexCoord = vec2(aTexCoord.x, aTexCoord.y);
   // glPos=gl_Position;
// gl_Position = vec4(aPos.x + xOffset, aPos.y, aPos.z, 1.0);
}