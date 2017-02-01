package com.example.matej.studis;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.RelativeLayout;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class ScoreActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_score);

        final TextView tvNaziv = (TextView) findViewById(R.id.tvNaziv);
        final TextView tvK = (TextView) findViewById(R.id.tvnazivKolegija);
        final TextView tvPrag = (TextView) findViewById(R.id.textView8);
        final TextView tvBodovi = (TextView) findViewById(R.id.textView7);
        final TextView tvUkupno = (TextView) findViewById(R.id.tvUkupno);

        final ViewGroup.LayoutParams paramNaziv = tvNaziv.getLayoutParams();
        final ViewGroup.LayoutParams paramBodovi = tvBodovi.getLayoutParams();
        final ViewGroup.LayoutParams paramPrag = tvPrag.getLayoutParams();
        final ViewGroup.LayoutParams paramUkupno = tvUkupno.getLayoutParams();

        TextView bodPrikz = new TextView(ScoreActivity.this);
        TextView pragPrikz = new TextView(ScoreActivity.this);
        final RelativeLayout ll = (RelativeLayout) findViewById(R.id.activity_score);

        tvBodovi.setMinimumWidth(100);
        tvBodovi.setMinimumHeight(50);
        tvPrag.setMinimumWidth(100);
        tvPrag.setMinHeight(50);

        Intent intent = getIntent();
        String name = intent.getStringExtra("CourseName");
        String jsonArray = intent.getStringExtra("Scores");
        tvK.setText(name);

        bodPrikz.setText("Bodovi");
        pragPrikz.setText("Prag");

        //ll.addView(bodPrikz, paramBodovi);
        //ll.addView(pragPrikz, paramPrag);

        try {
            JSONArray scoreArray = new JSONArray(jsonArray);

            for (int i=0; i<scoreArray.length(); i++){

                JSONObject komponenta = scoreArray.getJSONObject(i);

                RelativeLayout.LayoutParams lp = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MATCH_PARENT, RelativeLayout.LayoutParams.WRAP_CONTENT);

                TextView kompN = new TextView(ScoreActivity.this);
                kompN.setText(komponenta.getString("ComponentName"));
                kompN.setY(100 + 100*i);
                kompN.setLayoutParams(paramNaziv);
                ll.addView(kompN);

                float y =  kompN.getY();

                TextView bodoviN = new TextView(ScoreActivity.this);
                bodoviN.setText(komponenta.getString("Value"));
                //bodoviN.setY(40 + 100*i);
                //bodoviN.setLayoutParams(paramBodovi);
                bodoviN.setMinHeight(50);
                bodoviN.setMinimumWidth(50);
                bodoviN.setY(y);
                ll.addView(bodoviN, paramBodovi);


                TextView pragN = new TextView(ScoreActivity.this);
                pragN.setText(komponenta.getString("ComponentMinToPass"));
                //lp.addRule(RelativeLayout.ALIGN_RIGHT, tvNaziv.getId());
                //float x =  tvPrag.getX();
                pragN.setY(y);
                //pragN.setX(x);
                //pragN.setLayoutParams(paramPrag);
                pragN.setMinHeight(50);
                pragN.setMinimumWidth(50);
                //pragN.setY(40 + 100*i);
                ll.addView(pragN, paramPrag);


                TextView ukupnoN = new TextView(ScoreActivity.this);
                ukupnoN.setText(komponenta.getString("ComponentMax"));
                //lp.addRule(RelativeLayout.BELOW, tvUkupno.getId());
                ukupnoN.setY(100 + 100*i);
                ukupnoN.setLayoutParams(paramUkupno);
                ll.addView(ukupnoN);
            }

        } catch (JSONException e) {
            e.printStackTrace();
        }

        tvBodovi.setText("");
        tvPrag.setText("");

    }
}
