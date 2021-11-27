import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class ExGetServlet extends HttpServlet {
 public void doGet(HttpServletRequest request, HttpServletResponse response)throws ServletException, IOException{
  String requestEnc = request.getCharacterEncoding();
  if(requestEnc==null) requestEnc="ISO-8859-1";
  String name = new String(request.getParameter("name").getBytes(requestEnc),"Cp1251");
  String surname = new String(request.getParameter("surname").getBytes(requestEnc),"Cp1251");
  response.setContentType("text/html");
  response.setCharacterEncoding("Cp1251"); 
  PrintWriter pw = response.getWriter();
  pw.println("<b>Здравствуйте, "+name+" "+surname+"! Очень рады Вас видеть.</b>");
  pw.close();
 }
}