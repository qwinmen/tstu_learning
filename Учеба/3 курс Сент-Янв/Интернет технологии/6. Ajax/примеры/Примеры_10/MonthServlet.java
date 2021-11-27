import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class MonthServlet extends HttpServlet {
 public void doGet(HttpServletRequest request, HttpServletResponse response)throws ServletException, IOException{
  String name;
  int i, days;
  String mnames_in[] = {"Январь","Февраль","Март","Апрель","Май","Июнь","Июль","Август","Сентябрь","Октябрь","Ноябрь","Декабрь"};
  int mdays_in[] = {31,28,31,30,31,30,31,31,30,31,30,31};
  OutputStreamWriter fw = new OutputStreamWriter(new FileOutputStream("month.txt"),"Cp1251");
  PrintWriter out = new PrintWriter(fw);
  for (i=0;i<12;i++) out.println(mnames_in[i]);
  for (i=0;i<12;i++) out.println(mdays_in[i]);
  out.close();

  String mnames_out[] = new String[12];
  int mdays_out[] = new int[12];
  InputStreamReader fr = new InputStreamReader(new FileInputStream("month.txt"),"Cp1251");
  BufferedReader in = new BufferedReader(fr);
  String s;
  for (i=0;i<12;i++) {s=in.readLine();mnames_out[i]=s;}
  for (i=0;i<12;i++) {s=in.readLine();mdays_out[i]=Integer.parseInt(s);}
  in.close();

  int month = Integer.parseInt(request.getParameter("month"))-1;
  name = mnames_out[month];
  days = mdays_out[month];  
  response.setContentType("text/html");
  response.setCharacterEncoding("Cp1251"); 
  PrintWriter pw = response.getWriter();
  pw.println("<h2>Месяц - "+name+". Количество дней - "+days+".</h2>");
  pw.close();
 }
}