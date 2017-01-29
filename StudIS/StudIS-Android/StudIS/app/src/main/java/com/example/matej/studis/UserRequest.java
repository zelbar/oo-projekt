package com.example.matej.studis;

import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Matej on 26.1.2017..
 */

public class UserRequest extends StringRequest {


    private static final String USER_DATA_URL = "http://10.0.2.2:42271/api/StudentData/GetStudentData/";

    private Map<String, String> params;

    public UserRequest(Integer id, Response.Listener<String> listener){
        super(Method.GET, USER_DATA_URL + id.toString(), listener, null);

        params = new HashMap<>();

    }

}
