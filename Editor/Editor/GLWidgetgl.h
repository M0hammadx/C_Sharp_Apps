#pragma once

#include <QGLWidget>
#include <qtimer.h>
#include <qdebug.h>
#include <QOpenGLWidget>
//#include <qopenglfunctions_3_3_core.h>
#include <GLFW/glfw3.h>
//#include <glad/glad.h>

#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>

#include "Shader.hpp"
#include <camera.h>
//#include <learnopenglQT/model.h>


class GLWidgetgl : public QOpenGLWidget, protected QOpenGLFunctions_3_3_Core
{
	Q_OBJECT
		//private slots:
		//	void WriteText(const QString text);
public slots:
	void timerSlot();
public:
	GLWidgetgl(QWidget *parent);
	~GLWidgetgl();
	void suicide(std::string shaderPath);
	void use();
	unsigned int ID;
	glm::vec3 colorU;
	void colorUSetX(float _x) {
		colorU.x = _x;
	}
	void colorUSetY(float _x) {
		colorU.y = _x;
	}
	void colorUSetZ(float _x) {
		colorU.z = _x;
	}
	void setMat4(const std::string &name, const glm::mat4 &mat) {
		glUniformMatrix4fv(glGetUniformLocation(ID, name.c_str()), 1, GL_FALSE,
			&mat[0][0]);
	}
	void setVec3(const std::string &name, const glm::vec3 &value) {
		glUniform3fv(glGetUniformLocation(ID, name.c_str()), 1, &value[0]);
	}

	unsigned int VBO, VAO;
	// settings
	const unsigned int SCR_WIDTH = 800;
	const unsigned int SCR_HEIGHT = 600;

	// camera
	Camera camera = Camera(glm::vec3(0.0f, 0.0f, 3.0f));
	float lastX = SCR_WIDTH / 2.0f;
	float lastY = SCR_HEIGHT / 2.0f;
	bool firstMouse = true;

	// timing
	float deltaTime = 0.0f;	// time between current frame and last frame
	float lastFrame = 0.0f;


	virtual void initializeGL();
	virtual void paintGL();
	void timerEvent(QTimerEvent *e) override;
	QTimer *timer;
};
