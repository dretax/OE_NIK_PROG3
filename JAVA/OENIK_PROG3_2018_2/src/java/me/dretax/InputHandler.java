/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package me.dretax;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author DreTaX
 */
@WebServlet(name = "InputHandler", urlPatterns = {"/InputHandler"})

public class InputHandler extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
    }

    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
        PrintWriter out = response.getWriter();
        try {
            String releasedate = request.getParameter("releasedate");
            if (!releasedate.contains("-")) {
                out.println("SYNTAX releasedate: X-Y");
                return;
            }
            String enginevolume = request.getParameter("enginevolume");
            if (!enginevolume.contains("-")) {
                out.println("SYNTAX enginevolume: X-Y");
                return;
            }
            String horsepower = request.getParameter("horsepower");
            if (!horsepower.contains("-")) {
                out.println("SYNTAX horsepower: X-Y");
                return;
            }
            String baseprice = request.getParameter("baseprice");
            if (!baseprice.contains("-")) {
                out.println("SYNTAX baseprice: X-Y");
                return;
            }
            out.println(GeneratorBackend.getJson(releasedate, enginevolume, horsepower, baseprice));
        }
        catch (Exception e) {
            out.println("Hiba! Valószínűleg hibásan átadott paramétereket kaptam, javítsd ki xdxdxxdddd " + e);
        }
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
