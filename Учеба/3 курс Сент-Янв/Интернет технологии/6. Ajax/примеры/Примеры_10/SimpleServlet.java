import java.io.*;
import javax.servlet.*;

public class SimpleServlet extends GenericServlet {
 public void service(ServletRequest request, ServletResponse response)throws ServletException, IOException{
  response.setContentType("text/html");
  response.setCharacterEncoding("Cp1251"); 
  PrintWriter pw = response.getWriter();
  pw.println("<h2>Привет!</h2>");
  pw.close();
 }
}