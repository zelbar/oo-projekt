package com.example.matej.studis;

import android.util.Log;

import com.android.volley.Request;
import com.android.volley.Response;

import java.util.Map;
import android.util.Log;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import org.json.JSONObject;

import java.util.HashMap;
/**
 * Created by Matej on 28.1.2017..
 */

public class ScoreRequest extends StringRequest{
    //final String ids = Integer.toString(id);
    private static final String Courses_URL = "http://10.0.2.2:42271/api/StudentData/GetScoreData";


    public ScoreRequest(Integer StudentID, Integer CourseID, Response.Listener<String> listener) {
        super(Request.Method.GET, Courses_URL + "/" + StudentID.toString() + "/" + CourseID.toString() , listener, null);
    }
}

