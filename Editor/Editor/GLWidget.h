#pragma once

#include <QWidget>

//#include <glad/glad.h>
//#include <GLFW/glfw3.h>
//
//#include <glm/glm.hpp>
//#include <glm/gtc/matrix_transform.hpp>
//#include <glm/gtc/type_ptr.hpp>
//
//#include <learnopenglQT/shader.h>
//#include <learnopenglQT/camera.h>
//#include <learnopenglQT/model.h>

class GLWidget : public QWidget
{
	Q_OBJECT

public:
	GLWidget(QWidget *parent = nullptr);
	~GLWidget();

	//virtual void initializeGL();
	//virtual void paintGL();
	//virtual void resizeGL(int w, int h);
};
