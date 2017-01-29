package com.example.matej.studis;

import android.util.Log;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Matej on 26.1.2017..
 */

public class LoginRequest extends StringRequest {

    private static final String LOGIN_URL = "http://10.0.2.2:42271/api/Login?";

    //email=zlatko.hrastic@fer.hr&passwordHash=ZwCX0wmOIr88iYKO8YYvWTPuZzg="

    private Map<String, String> param;

    public LoginRequest(String email, String pasword, Response.Listener<String> listener) {
        super(Method.GET, LOGIN_URL+"email="+email+"&"+"passwordHash="+pasword, listener, null);



        Log.d("MESSAGE", "MESSAGE");
        //param = new HashMap<>();
        //param.put("email", JMBAG);
        //param.put("passwordHash", pasword);

    }

    public Map<String , String> getParams(){
        return param;
    }
}