package com.example.matej.studis;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class UserDataActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_data);


        final TextView tvIme = (TextView) findViewById(R.id.tvIme);
        final TextView tvPrezime = (TextView) findViewById(R.id.tvPrezime);
        final TextView tvEmail = (TextView) findViewById(R.id.tvEmail);
        final TextView tvJMBAG = (TextView) findViewById(R.id.tvJMBAG);
        final TextView tvOIB = (TextView) findViewById(R.id.tvOIBdan);


        Intent intent = getIntent();
        Integer id = intent.getIntExtra("Id", -1);


        Response.Listener<String> studentDetails = new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                try {
                    JSONObject jsonResponse = new JSONObject(response);

                    //Log.d("DETAILS",response);


                    String name = jsonResponse.getString("Name");
                    String surname = jsonResponse.getString("Surname");
                    String email = jsonResponse.getString("Email");
                    String jmbag = jsonResponse.getString("StudentIdentificationNumber");
                    String oib = jsonResponse.getString("NationalIdentificationNumber");

                    tvIme.setText(name);
                    tvPrezime.setText(surname);
                    tvEmail.setText(email);
                    tvJMBAG.setText(jmbag);
                    tvOIB.setText(oib);




                } catch (JSONException e) {
                    new AlertDialog.Builder(UserDataActivity.this)
                            .setTitle("No Data")
                            .setMessage("We have no information about you, we apoligize")
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
        UserRequest scoreRequest = new UserRequest(id , studentDetails);
        RequestQueue queue = Volley.newRequestQueue(UserDataActivity.this);
        queue.add(scoreRequest);



    }
}
