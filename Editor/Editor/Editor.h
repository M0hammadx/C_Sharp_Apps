#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_Editor.h"

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

class Editor : public QMainWindow
{
	Q_OBJECT

public:
	Editor(QWidget *parent = Q_NULLPTR);
private slots:
	void on_horizontalSlider_valueChanged(int value);
	void on_horizontalSlider_2_valueChanged(int value);
	void on_horizontalSlider_3_valueChanged(int value);

private:
	Ui::EditorClass ui;
	GLWidgetgl *gl;
};
