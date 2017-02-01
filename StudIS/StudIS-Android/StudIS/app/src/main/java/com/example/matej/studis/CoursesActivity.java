package com.example.matej.studis;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.ScrollView;
import android.widget.SimpleAdapter;
import android.widget.Space;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.RetryPolicy;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class CoursesActivity extends AppCompatActivity  {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_courses);

        final TextView tvIme = (TextView) findViewById(R.id.tvCourseStudentName);
        final TextView tvJMBAG = (TextView) findViewById(R.id.tvCourseStudentJMBAG);

        final Button bToLogin = (Button) findViewById(R.id.bGoToLogin);
        final Button bDeatails = (Button) findViewById(R.id.bDetails);

        final LinearLayout llcourses = (LinearLayout) findViewById(R.id.llPredmeti);


        Intent intent = getIntent();
        String name = intent.getStringExtra("FullName");
        final int id = intent.getIntExtra("Id", -1);
        String jmbag = intent.getStringExtra("StudentIdentificationNumber");

        tvIme.setText(name);
        tvJMBAG.setText(jmbag);

        final Button myButt = new Button(this);
        myButt.setText("Add me");

        final View.OnClickListener predmettraži = new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Integer x = v.getId();
                Response.Listener<String> scoreListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);



                            String name = jsonResponse.getString("Name");
                            JSONArray jsonArray = jsonResponse.getJSONArray("ScoreList");

                            Intent intent = new Intent(CoursesActivity.this, ScoreActivity.class);
                            intent.putExtra("CourseName", name);
                            intent.putExtra("Scores", jsonArray.toString());

                            CoursesActivity.this.startActivity(intent);




                        } catch (JSONException e) {
                            new AlertDialog.Builder(CoursesActivity.this)
                                    .setTitle("No information")
                                    .setMessage("No information, contact us")
                                    .setPositiveButton(android.R.string.ok, new DialogInterface.OnClickListener() {
                                        public void onClick(DialogInterface dialog, int which) {
                                            // continue with delete
                                        }
                                    })
                                    .setIcon(android.R.drawable.ic_dialog_alert)
                                    .show();
                        }
                    }
                };
                ScoreRequest scoreRequest = new ScoreRequest(id , x , scoreListener);
                RequestQueue queue = Volley.newRequestQueue(CoursesActivity.this);
                queue.add(scoreRequest);
            }
        };


        bToLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intentback=new Intent(CoursesActivity.this, LoginActivity.class);
                CoursesActivity.this.startActivity(intentback);
            }
        });

        Response.Listener<String> courseResonse = new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                try {
                    JSONArray jsonArray = new JSONArray(response);
                    ArrayList<Integer> listaId = new ArrayList<Integer>();
                    ArrayList<HashMap<String, String>> listaS = new ArrayList<HashMap<String, String>>();

                    for (int i = 0; i<jsonArray.length(); i++){
                        JSONObject jsonObject = jsonArray.getJSONObject(i);
                        String nameCourse = jsonObject.getString("Name");
                        Integer id = jsonObject.getInt("Id");
                        Space space = new Space(CoursesActivity.this);
                        space.setMinimumHeight(20);

                        Button cou = new Button(CoursesActivity.this);
                        cou.setText(nameCourse);
                        cou.setId(id);
                         cou.setOnClickListener(predmettraži);
                        cou.setBackgroundColor(Color.GREEN);

                        llcourses.addView(space);
                        llcourses.addView(cou);
                    }

                    //Log.d("Login", response);


                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }
        };
        final String ids = Integer.toString(id);
        CoursesRequest coursesRequest = new CoursesRequest(ids, courseResonse);
        RequestQueue queue = Volley.newRequestQueue(CoursesActivity.this);
        queue.add(coursesRequest);


        bDeatails.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intentdetails=new Intent(CoursesActivity.this, UserDataActivity.class);
                intentdetails.putExtra("Id", id);
                CoursesActivity.this.startActivity(intentdetails);
            }
        });


    }





}
