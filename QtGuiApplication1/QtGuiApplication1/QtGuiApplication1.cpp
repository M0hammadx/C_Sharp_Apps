#include "QtGuiApplication1.h"

QtGuiApplication1::QtGuiApplication1(QWidget *parent)
	: QMainWindow(parent)
{
	ui.setupUi(this);
	//ui.progressBar

	connect(ui.horizontalSlider, SIGNAL(valueChanged(int)), ui.progressBar, SLOT(setValue(int)));
	connect(ui.progressBar, SIGNAL(valueChanged(int)), ui.progressBar_2, SLOT(setValue(int)));

}
