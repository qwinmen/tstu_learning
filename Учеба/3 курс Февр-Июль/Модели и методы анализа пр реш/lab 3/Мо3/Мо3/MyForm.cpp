#include "MyForm.h"
#include "MyForm.h" //the header name for your form   
using namespace Мо3; //name of your project  
[STAThreadAttribute] int main(array<System::String ^> ^args) {   
	Application::EnableVisualStyles();   
	Application::SetCompatibleTextRenderingDefault(false);       
	Application::Run(gcnew MyForm());     return 0; }
