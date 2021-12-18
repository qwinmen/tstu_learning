#include "MyForm.h"
using namespace bz3; //name of your project  
[STAThreadAttribute] 
int main(array<System::String ^> ^args) {
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	Application::Run(gcnew MyForm());
	return 0;
}