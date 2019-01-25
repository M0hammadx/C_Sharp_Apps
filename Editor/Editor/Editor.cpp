#include "Editor.h"
#include <qmessagebox.h>
Editor::Editor(QWidget *parent)
	: QMainWindow(parent)
{
	ui.setupUi(this);
	gl = new GLWidgetgl(this);
	//ui.openGLWidget->setParent(gl);
	
	//QWidget  b = (ui.openGLWidget->parentWidget);
	//connect(ui.horizontalSlider, SIGNAL(valueChanged(int)), (ui.openGLWidget->parentWidget), SLOT(colorUSetX(int)));

//connect(ui.horizontalSlider, static_cast<void (QSlider::*)(bool)>(&QSlider::valueChanged), this, &Editor::valueChanged);
}

void Editor::on_horizontalSlider_valueChanged(int value)
{
	//QMessageBox::information(this, "wt", "m");
	ui.openGLWidget->colorUSetZ(value / 255.0);
}
void Editor::on_horizontalSlider_2_valueChanged(int value)
{
	ui.openGLWidget->colorUSetY(value / 255.0);
}
void Editor::on_horizontalSlider_3_valueChanged(int value)
{
	ui.openGLWidget->colorUSetX(value / 255.0);
}