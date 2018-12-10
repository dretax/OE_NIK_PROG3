/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package me.dretax;

import java.util.Random;
import javax.json.Json;
import javax.json.JsonObject;
import javax.json.JsonObjectBuilder;

/**
 *
 * @author DreTaX
 */
public class GeneratorBackend 
{
    private static final Random _r = new Random();
    
    private static int GenerateRandom(String param) 
    {
        String[] spl = param.split("-");
        int min = Integer.parseInt(spl[0]);
        int max = Integer.parseInt(spl[1]);
        return _r.nextInt((max - min) + 1) + min;
    }
    
    public static String getJson(String releasedate, String enginevolume, String horsepower, String baseprice) 
    {
        JsonObjectBuilder jobj = Json.createObjectBuilder();
        jobj.add("RELEASEDATE", GenerateRandom(releasedate));
        jobj.add("ENGINEVOLUME", GenerateRandom(enginevolume));
        jobj.add("HORSEPOWER", GenerateRandom(horsepower));
        jobj.add("BASEPRICE", GenerateRandom(baseprice));
        JsonObject complete = jobj.build();
        return complete.toString();
    }
}
