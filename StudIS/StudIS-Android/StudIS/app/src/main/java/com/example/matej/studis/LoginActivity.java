package com.example.matej.studis;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Base64;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;


import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

import retrofit.converter.Converter;

import static android.support.v7.appcompat.R.id.text;


public class LoginActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        final EditText etEmail = (EditText) findViewById(R.id.etEmail);
        final EditText etPasword = (EditText) findViewById(R.id.etPasword);

        final Button bLogin = (Button) findViewById(R.id.bLogin);

        bLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final String email = etEmail.getText().toString();
                final String pasword = etPasword.getText().toString();


                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean sucsses = true;

                            Log.d("Login", response);
                            Log.d("JSON", jsonResponse.toString());

                            if(jsonResponse.length()>0){
                                String name = jsonResponse.getString("FullName");
                                int id = jsonResponse.getInt("Id");
                                String jmbag = jsonResponse.getString("StudentIdentificationNumber");

                                Intent intent = new Intent(LoginActivity.this, CoursesActivity.class);
                                intent.putExtra("FullName", name);
                                intent.putExtra("Id", id);
                                intent.putExtra("StudentIdentificationNumber", jmbag);

                                LoginActivity.this.startActivity(intent);

                            }

                        } catch (JSONException e) {
                            new AlertDialog.Builder(LoginActivity.this)
                                    .setTitle("Login entry")
                                    .setMessage("Incorrect Information")
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


                String encryptedpassword = SHA1(pasword);



                LoginRequest loginRequest = new LoginRequest(email, encryptedpassword, responseListener);
                RequestQueue queue = Volley.newRequestQueue(LoginActivity.this);
                queue.add(loginRequest);
                //etJMBAG.setText("Kraj sam ovdje");

            }
        });



    }
    public String SHA1(String text) {

        try {

            MessageDigest md;
            md = MessageDigest.getInstance("SHA-1");
            md.update(text.getBytes("UTF-8"),
                    0, text.length());
            byte[] sha1hash = md.digest();

            return toHex(sha1hash);

        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }

        return null;
    }

    public static String toHex(byte[] buf) {

        if (buf == null) return "";

        int l = buf.length;
        StringBuffer result = new StringBuffer(2 * l);

        for (int i = 0; i < buf.length; i++) {
            appendHex(result, buf[i]);
        }

        return result.toString();

    }

    private final static String HEX = "0123456789ABCDEF";

    private static void appendHex(StringBuffer sb, byte b) {

        sb.append(HEX.charAt((b >> 4) & 0x0f))
                .append(HEX.charAt(b & 0x0f));

    }
}
