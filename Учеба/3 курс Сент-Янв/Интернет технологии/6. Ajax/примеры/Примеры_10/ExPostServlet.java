import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class ExPostServlet extends HttpServlet {
 public void doPost(HttpServletRequest request, HttpServletResponse response)throws ServletException, IOException{
  int a11 = Integer.parseInt(request.getParameter("a11"));
  int a12 = Integer.parseInt(request.getParameter("a12"));
  int a13 = Integer.parseInt(request.getParameter("a13"));
  int a21 = Integer.parseInt(request.getParameter("a21"));
  int a22 = Integer.parseInt(request.getParameter("a22"));
  int a23 = Integer.parseInt(request.getParameter("a23"));
  int a31 = Integer.parseInt(request.getParameter("a31"));
  int a32 = Integer.parseInt(request.getParameter("a32"));
  int a33 = Integer.parseInt(request.getParameter("a33"));  
  response.setContentType("text/html");
  response.setCharacterEncoding("Cp1251"); 
  PrintWriter pw = response.getWriter();
  int opred = a11*a22*a33-a11*a23*a32-a12*a21*a33+a12*a23*a31+a13*a21*a32-a13*a22*a31;
  pw.println("<b>Определитель матрицы: "+opred+"</b>");
  pw.close();
 }
}