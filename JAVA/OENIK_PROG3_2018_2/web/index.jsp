<%-- 
    Document   : Generator
    Created on : Nov 23, 2018, 12:49:14 PM
    Author     : DreTaX
--%>

<%@page import="me.dretax.GeneratorBackend"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>DreTaX nagyon menő JSP oLdAlA</title>
        <body>
        <%
            if (request.getParameter("releasedate") == null
                || request.getParameter("enginevolume") == null
                || request.getParameter("horsepower") == null
                || request.getParameter("baseprice") == null) {
                    out.println("Hibás paraméterek!");
            } else {
                ServletContext context = getServletContext();
                RequestDispatcher rd = context.getRequestDispatcher("/InputHandler");
                rd.forward(request, response);
            }
            %>
        </body>
    </head>
</html>
